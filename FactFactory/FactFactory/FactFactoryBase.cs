using GetcuReone.ComboPatterns.Factory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.TreeEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Base class for fact factory
    /// </summary>
    public abstract class FactFactoryBase<TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : FactoryBase, IFactFactory<TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction>
        where TFact : class, IFact
        where TFactContainer : FactContainerBase<TFact>
        where TFactRule : FactRuleBase<TFact>
        where TFactRuleCollection : FactRuleCollectionBase<TFact, TFactRule>
        where TWantAction : WantActionBase<TFact>
    {
        /// <summary>
        /// Want actions
        /// </summary>
        protected List<TWantAction> WantActions { get; } = new List<TWantAction>();

        /// <summary>
        /// Fact container
        /// </summary>
        public abstract TFactContainer Container { get; }

        /// <summary>
        /// Collection of rules for derive facts
        /// </summary>
        public abstract TFactRuleCollection Rules { get; }

        /// <summary>
        /// Get fact type
        /// </summary>
        /// <typeparam name="TGetFact"></typeparam>
        /// <returns></returns>
        protected abstract IFactType GetFactType<TGetFact>() where TGetFact : IFact;

        /// <summary>
        /// Return the fact set that will be contained in the default container.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        protected virtual IEnumerable<TFact> GetDefaultFacts(FactContainerBase<TFact> container)
        {
            return Enumerable.Empty<TFact>();
        }

        /// <summary>
        /// Derive the facts
        /// </summary>
        public virtual void Derive()
        {
            // Get a copy of the container
            if (Container == null)
                throw FactFactoryHelper.CreateDeriveException<TFact>(ErrorCode.InvalidData, "Container cannot be null.");

            FactContainerBase<TFact> containerCopy = Container.Copy();
            if (containerCopy == null)
                throw FactFactoryHelper.CreateDeriveException<TFact>(ErrorCode.InvalidData, "IFactContainer.Copy method return null.");
            if (Container.Equals(containerCopy))
                throw FactFactoryHelper.CreateDeriveException<TFact>(ErrorCode.InvalidData, "IFactContainer.Copy method return original container.");
            if (!(containerCopy is TFactContainer))
                throw FactFactoryHelper.CreateDeriveException<TFact>(ErrorCode.InvalidData, "IFactContainer.Copy method returned a different type of container.");

            TFactContainer container = (TFactContainer)containerCopy;
            container.IsReadOnly = true;

            List<IFactType> defaultFacts = new List<IFactType>();
            foreach(TFact fact in GetDefaultFacts(container) ?? Enumerable.Empty<TFact>())
            {
                IFactType type = fact.GetFactType();

                if (defaultFacts.Any(dType => dType.Compare(type)))
                    throw FactFactoryHelper.CreateDeriveException<TFact>(ErrorCode.InvalidData, $"GetDefaultFacts method return more than two {type.FactName} facts");

                if (!type.ContainsContainer(container))
                {
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Add(fact);

                    defaultFacts.Add(type);
                }
            }

            if (container.Any(fact => fact.IsSpecialFact()))
                throw FactFactoryHelper.CreateDeriveException<TFact>(ErrorCode.InvalidData, $"In the container there should be no facts realizing types {nameof(INotContainedFact)} and {nameof(INoDerivedFact)}");

            // Get a copy of the rules
            FactRuleCollectionBase<TFact, TFactRule> rules = Rules.Copy();
            if (rules.Equals(Rules))
                throw FactFactoryHelper.CreateDeriveException<TFact>(ErrorCode.InvalidData, "FactRuleCollectionBase.Copy method return original rule collection.");
            rules.IsReadOnly = true;

            var forestry = new Dictionary<TWantAction, List<FactRuleTree<TFact, TFactRule>>>();
            List<DeriveErrorDetail<TFact>> deriveErrorDetails = new List<DeriveErrorDetail<TFact>>();
            var needSpecialFacts = new Dictionary<TWantAction, List<TFact>>();
            List<TWantAction> wantActions = new List<TWantAction>(WantActions);

            foreach (TWantAction wantAction in wantActions)
            {
                if (TryDeriveTreesForWantAction(out List<FactRuleTree<TFact, TFactRule>> result, wantAction, container, rules, out List<TFact> specialFacts, out DeriveErrorDetail<TFact> detail))
                {
                    forestry.Add(wantAction, result);
                    needSpecialFacts.Add(wantAction, specialFacts);
                }
                else
                    deriveErrorDetails.Add(detail);
            }

            if (deriveErrorDetails.Count != 0)
                throw FactFactoryHelper.CreateDeriveException(deriveErrorDetails);

            var calculatedFacts = new List<TFact>();
            foreach (var key in forestry.Keys)
            {
                foreach (TFact fact in needSpecialFacts[key])
                {
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Add(fact);
                }

                foreach (var tree in forestry[key])
                    DeriveNode(tree.Root, container, key, calculatedFacts);

                key.Invoke(container);

                OnWantActionCalculated(key, container);

                foreach (TFact fact in needSpecialFacts[key])
                {
                    using(container.CreateIgnoreReadOnlySpace())
                        container.Remove(fact);
                }
            }

            OnDeriveFinished(wantActions, container, calculatedFacts);

            foreach(var type in defaultFacts)
            {
                if (type.TryGetFact(container, out TFact fact))
                {
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Remove(fact);
                }
            }
        }

        /// <summary>
        /// Derive <typeparamref name="TWantFact"/>
        /// </summary>
        /// <typeparam name="TWantFact">Type of desired fact</typeparam>
        /// <returns></returns>
        public virtual TWantFact DeriveFact<TWantFact>() where TWantFact : TFact
        {
            TWantFact fact = default;

            var wantActions = new List<TWantAction>(WantActions);
            WantActions.Clear();

            WantFact(CreateWantAction(
                container => fact = container.GetFact<TWantFact>(),
                new List<IFactType> { GetFactType<TWantFact>() }));

            Derive();

            WantActions.AddRange(wantActions);

            return fact;
        }

        /// <summary>
        /// Action calculation completion handler
        /// </summary>
        /// <param name="wantAction"></param>
        /// <param name="container"></param>
        protected virtual void OnWantActionCalculated(TWantAction wantAction, FactContainerBase<TFact> container) { }

        /// <summary>
        /// Fact calculation event handler for an <paramref name="wantAction"/>.
        /// </summary>
        /// <param name="factType">Type calculated fact.</param>
        /// <param name="container">Container.</param>
        /// <param name="wantAction">The action for which the fact was calculated.</param>
        protected virtual void OnFactCalculatedForWantAction(IFactType factType, FactContainerBase<TFact> container, TWantAction wantAction) { }

        /// <summary>
        /// Event handler method 'derive finished'. It is executed at the end of the <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/> method.
        /// </summary>
        /// <param name="wantActions">List of desired actions.</param>
        /// <param name="container">Container.</param>
        /// <param name="calculatedFacts">List of all calculated facts.</param>
        protected virtual void OnDeriveFinished(List<TWantAction> wantActions, FactContainerBase<TFact> container, List<TFact> calculatedFacts) { }

        #region methods for derive

        /// <summary>
        /// creation method <typeparamref name="TWantAction"/>
        /// </summary>
        /// <param name="wantAction">action taken after deriving a fact</param>
        /// <param name="factTypes">facts required to launch an action</param>
        /// <returns></returns>
        protected abstract TWantAction CreateWantAction(Action<IFactContainer<TFact>> wantAction, IList<IFactType> factTypes);

        /// <summary>
        /// Return a list with the appropriate rules at the time of the derive of the facts.
        /// </summary>
        /// <param name="rules">Current set of rules.</param>
        /// <param name="container">Current fact set.</param>
        /// <param name="wantAction">Current wantAction</param>
        /// <returns></returns>
        protected virtual IList<TFactRule> GetRulesForWantAction(TWantAction wantAction, FactContainerBase<TFact> container, FactRuleCollectionBase<TFact, TFactRule> rules)
        {
            return rules;
        }

        /// <summary>
        /// The method determines whether the fact should be recounted.
        /// </summary>
        /// <param name="rule">Rule for calculating the fact.</param>
        /// <param name="container">Fact container.</param>
        /// <param name="wantAction">The initial action for which the parameters are calculated.</param>
        /// <returns>True - fact needs to be recalculated.</returns>
        protected virtual bool NeedRecalculateFact(TFactRule rule, FactContainerBase<TFact> container, TWantAction wantAction)
        {
            return false;
        }

        /// <summary>
        /// We are trying to calculate a tree by which we find a fact
        /// </summary>
        /// <param name="treesResult">found trees</param>
        /// <param name="wantAction">desired action information</param>
        /// <param name="container">fact container</param>
        /// <param name="rules">rule collection</param>
        /// <param name="deriveErrorDetail"></param>
        /// <param name="specialFacts"></param>
        /// <returns></returns>
        private bool TryDeriveTreesForWantAction(out List<FactRuleTree<TFact, TFactRule>> treesResult, TWantAction wantAction, FactContainerBase<TFact> container, FactRuleCollectionBase<TFact, TFactRule> rules, out List<TFact> specialFacts, out DeriveErrorDetail<TFact> deriveErrorDetail)
        {
            IList<TFactRule> rulesForDerive = GetRulesForWantAction(wantAction, container, rules);

            // We check that we were not slipped into the new rules
            List<TFactRule> addedRules = new List<TFactRule>();
            foreach (TFactRule rule in rulesForDerive)
            {
                if (rules.All(r => r != rule))
                    addedRules.Add(rule);
            }

            if (addedRules.Count != 0)
                throw FactFactoryHelper.CreateDeriveException(
                    addedRules
                        .Select(rule => new KeyValuePair<string, string>(ErrorCode.InvalidData, $"GetRulesForWantAction method returned a new rule {rule.ToString()}"))
                        .ToList(),
                    wantAction);

            treesResult = new List<FactRuleTree<TFact, TFactRule>>();
            var deriveFactErrorDetails = new List<DeriveFactErrorDetail>();
            deriveErrorDetail = null;
            specialFacts = new List<TFact>();

            foreach (IFactType wantFact in wantAction.InputFactTypes)
            {
                // If fact already exists
                if (wantFact.ContainsContainer(container))
                    continue;
                else if (wantFact.IsFactType<ISpecialFact>())
                {
                    if (wantFact.IsFactType<INotContainedFact>())
                    {
                        INotContainedFact notContainedFact = wantFact.CreateSpecialFact<INotContainedFact>();

                        if (!notContainedFact.IsFactContained(container))
                        {
                            TFact specialFact = notContainedFact.ConvertFact<TFact>();
                            specialFacts.Add(specialFact);
                            continue;
                        }

                        deriveFactErrorDetails.Add(new DeriveFactErrorDetail(wantFact, null));
                        continue;
                    }
                    else if (wantFact.IsFactType<IContainedFact>())
                    {
                        IContainedFact containedFact = wantFact.CreateSpecialFact<IContainedFact>();

                        if (containedFact.IsFactContained(container))
                        {
                            TFact specialFact = containedFact.ConvertFact<TFact>();
                            specialFacts.Add(specialFact);
                            continue;
                        }
                    }
                    else if (wantFact.IsFactType<INoDerivedFact>())
                    {
                        INoDerivedFact noDerivedFact = wantFact.CreateSpecialFact<INoDerivedFact>();
                        if (!noDerivedFact.Value.ContainsContainer(container) && !TryDeriveNoFactInfo(noDerivedFact, wantAction, container, rules))
                        {
                            TFact specialFact = noDerivedFact.ConvertFact<TFact>();
                            specialFacts.Add(specialFact);
                            continue;
                        }

                        deriveFactErrorDetails.Add(new DeriveFactErrorDetail(wantFact, null));
                        continue;
                    }
                }

                if (TryDeriveTreeForFactInfo(out FactRuleTree<TFact, TFactRule> treeResult, wantFact, wantAction, container, rulesForDerive, specialFacts, out List<DeriveFactErrorDetail> details))
                {
                    treesResult.Add(treeResult);
                }
                else
                {
                    deriveFactErrorDetails.AddRange(details);
                }
            }

            if (deriveFactErrorDetails.Count != 0)
            {
                deriveErrorDetail = new DeriveErrorDetail<TFact>(ErrorCode.FactCannotCalculated, $"Failed to calculate one or more facts for the action {wantAction.ToString()}.", wantAction, deriveFactErrorDetails);
                return false;
            }

            return true;
        }

        private bool TryDeriveTreeForFactInfo(out FactRuleTree<TFact, TFactRule> treeResult, IFactType wantFact, TWantAction wantAction, FactContainerBase<TFact> container, IList<TFactRule> ruleCollection, List<TFact> specialFacts, out List<DeriveFactErrorDetail> deriveFactErrorDetails)
        {
            treeResult = null;
            deriveFactErrorDetails = null;

            // find the rules that can calculate the fact
            List<FactRuleTree<TFact, TFactRule>> factRuleTrees = GetFactRuleTrees(wantFact, ruleCollection);

            // Check if we can already derive the fact
            FactRuleTree<TFact, TFactRule> factRuleTreeComputed = factRuleTrees.FirstOrDefault(tree => tree.Root.FactRule.CanCalculate(container, wantAction));

            if (factRuleTreeComputed != null)
            {
                treeResult = factRuleTreeComputed;
                return true;
            }

            List<List<IFactType>> notFoundFactSet = factRuleTrees.ConvertAll(item => new List<IFactType>());
            List<FactRuleNode<TFact, TFactRule>> allCompletedNodes = new List<FactRuleNode<TFact, TFactRule>>();

            while (true)
            {
                for (int i = factRuleTrees.Count - 1; i >= 0; i--)
                {
                    FactRuleTree<TFact, TFactRule> factRuleTree = factRuleTrees[i];

                    if (factRuleTree == null)
                        continue;

                    int lastlevelNumber = factRuleTree.Levels.Count - 1;

                    if (SyncComputedNodeForLevelTreeAndCheckGoneRoot(factRuleTree, lastlevelNumber, allCompletedNodes))
                    {
                        treeResult = factRuleTree;
                        return true;
                    }

                    List<FactRuleNode<TFact, TFactRule>> lastLevel = factRuleTree.Levels[lastlevelNumber];

                    if (lastLevel.Count == 0)
                    {
                        treeResult = factRuleTree;
                        return true;
                    }

                    List<FactRuleNode<TFact, TFactRule>> nextNodes = new List<FactRuleNode<TFact, TFactRule>>();
                    List<FactRuleNode<TFact, TFactRule>> currentLevelCompletedNodes = new List<FactRuleNode<TFact, TFactRule>>();
                    bool cannotDerived = false;

                    for (int j = 0; j < lastLevel.Count; j++)
                    {
                        FactRuleNode<TFact, TFactRule> node = lastLevel[j];

                        List<IFactType> needFacts = node.FactRule.InputFactTypes
                            .Where(fact => !fact.ContainsContainer(container))
                            .ToList();

                        // Exclude special facts
                        for (int factIndex = needFacts.Count - 1; factIndex >= 0; factIndex--)
                        {
                            IFactType needFactType = needFacts[factIndex];
                            bool needRemove = false;

                            if (needFactType.IsFactType<ISpecialFact>())
                            {
                                bool isNotContained = needFactType.IsFactType<INotContainedFact>();
                                bool isNoDerive = needFactType.IsFactType<INoDerivedFact>();
                                bool isContained = needFactType.IsFactType<IContainedFact>();

                                if (isNoDerive || isNotContained || isContained)
                                {
                                    if (specialFacts.Any(fact => fact.GetFactType().Compare(needFactType)))
                                    {
                                        needFacts.Remove(needFactType);
                                        continue;
                                    }
                                }

                                // Check INotContainedFact fact
                                if (isNotContained)
                                {
                                    INotContainedFact notContainedFact = needFactType.CreateSpecialFact<INotContainedFact>();

                                    if (container.All(fact => !notContainedFact.IsFactContained(container)))
                                    {
                                        specialFacts.Add(notContainedFact.ConvertFact<TFact>());
                                        needRemove = true;
                                    }
                                }

                                // Check IContainedFact fact
                                else if (isContained)
                                {
                                    IContainedFact containedFact = needFactType.CreateSpecialFact<IContainedFact>();

                                    if (container.Any(fact => containedFact.IsFactContained(container)))
                                    {
                                        specialFacts.Add(containedFact.ConvertFact<TFact>());
                                        needRemove = true;
                                    }
                                }

                                // Check INoDerivedFact fact
                                else if (needFactType.IsFactType<INoDerivedFact>())
                                {
                                    INoDerivedFact noDerivedFact = needFactType.CreateSpecialFact<INoDerivedFact>();

                                    if (!TryDeriveNoFactInfo(noDerivedFact, wantAction, container, ruleCollection))
                                    {
                                        specialFacts.Add(noDerivedFact.ConvertFact<TFact>());
                                        needRemove = true;
                                    }
                                }
                            }

                            if (needRemove)
                                needFacts.Remove(needFactType);
                        }

                        // If the rule can be calculated from the parameters in the container, then add the node to the list of complete
                        if (needFacts.IsNullOrEmpty())
                        {
                            allCompletedNodes.Add(node);
                            currentLevelCompletedNodes.Add(node);
                            continue;
                        }

                        var completedNodesForFact = allCompletedNodes
                            .Where(n => needFacts.Any(f => f.Compare(n.FactRule.OutputFactType)))
                            .ToList();

                        if (completedNodesForFact.Count > 0)
                        {
                            foreach (var completedNodeForFact in completedNodesForFact)
                                node.Childs.Add(completedNodeForFact);

                            var foundFacts = completedNodesForFact.Select(n => n.FactRule.OutputFactType).ToList();
                            needFacts.RemoveAll(f => foundFacts.Any(ff => ff.Compare(f)));

                            if (needFacts.Count == 0)
                                continue;
                        }

                        foreach (var needFact in needFacts)
                        {
                            if (needFact.IsFactType<ISpecialFact>())
                            {
                                cannotDerived = RemoveRuleNodeAndCheckGoneRoot(factRuleTree, lastlevelNumber, node);
                                j--;

                                notFoundFactSet[i].Add(needFact);
                                continue;
                            }

                            var needRules = ruleCollection
                                    .Where(rule => rule.OutputFactType.Compare(needFact))
                                    .Where(rule => !node.ExistsBranch(rule))
                                    .ToList();

                            if (needRules.Count > 0)
                            {
                                var nodes = needRules.Select(rule => new FactRuleNode<TFact, TFactRule>
                                {
                                    FactRule = rule,
                                    Parent = node,
                                }).ToList();
                                nextNodes.AddRange(nodes);
                                node.Childs.AddRange(nodes);
                            }
                            else
                            {
                                // Is there a neighboring node capable of deriving this fact
                                cannotDerived = RemoveRuleNodeAndCheckGoneRoot(factRuleTree, lastlevelNumber, node);
                                j--;

                                notFoundFactSet[i].Add(needFact);
                            }
                        }
                    }

                    if (cannotDerived)
                    {
                        factRuleTrees[i] = null;
                    }
                    else if (currentLevelCompletedNodes.Count > 0)
                    {
                        if (SyncComputedNodeForLevelTreeAndCheckGoneRoot(factRuleTree, lastlevelNumber, currentLevelCompletedNodes))
                        {
                            treeResult = factRuleTree;
                            return true;
                        }
                        else if (nextNodes.Count > 0)
                        {
                            SyncComputedNodes(nextNodes, currentLevelCompletedNodes);
                            factRuleTree.Levels.Add(nextNodes);
                        }
                    }
                    else if (nextNodes.Count > 0)
                    {
                        factRuleTree.Levels.Add(nextNodes);
                    }
                    else
                    {
                        treeResult = factRuleTree;
                        return true;
                    }
                }

                if (factRuleTrees.All(tree => tree == null))
                {
                    notFoundFactSet.RemoveAll(factSet => factSet.Count == 0);
                    break;
                }
            }

            deriveFactErrorDetails = new List<DeriveFactErrorDetail>();

            foreach (var factSet in notFoundFactSet)
                deriveFactErrorDetails.Add(new DeriveFactErrorDetail(wantFact, factSet.ToReadOnlyCollection()));

            return false;
        }

        /// <summary>
        /// Returns trees. Their number is equal to the number of rules that can derive the necessary <paramref name="wantFact"/>.
        /// </summary>
        /// <param name="wantFact">derive fact</param>
        /// <param name="rules">rule set</param>
        /// <returns></returns>
        private List<FactRuleTree<TFact, TFactRule>> GetFactRuleTrees(IFactType wantFact, IList<TFactRule> rules)
        {
            if (rules.IsNullOrEmpty())
                throw FactFactoryHelper.CreateDeriveException<TFact>(ErrorCode.EmptyRuleCollection, "Rules cannot be null.");

            List<FactRuleTree<TFact, TFactRule>> factRuleTrees = rules?.Where(rule => rule.OutputFactType.Compare(wantFact))
                    .Select(rule =>
                    {
                        var tree = new FactRuleTree<TFact, TFactRule>
                        {
                            Root = new FactRuleNode<TFact, TFactRule> { FactRule = rule }
                        };
                        tree.Levels.Add(new List<FactRuleNode<TFact, TFactRule>> { tree.Root });
                        return tree;
                    })
                    .ToList();

            if (factRuleTrees.IsNullOrEmpty())
                throw FactFactoryHelper.CreateDeriveException<TFact>(ErrorCode.RuleNotFound, $"No rules found able to calculate fact {wantFact.FactName}.");

            return factRuleTrees;
        }

        /// <summary>
        /// Synchronizes the level of nodes. Searches for finished nodes and removes them from the level. 
        /// Returns the truth if, invoking itself, the method has passed the root of the tree
        /// </summary>
        /// <param name="factRuleTree"></param>
        /// <param name="level"></param>
        /// <param name="computedNodes"></param>
        /// <returns></returns>
        private bool SyncComputedNodeForLevelTreeAndCheckGoneRoot(FactRuleTree<TFact, TFactRule> factRuleTree, int level, List<FactRuleNode<TFact, TFactRule>> computedNodes)
        {
            if (level < 0)
                return true;

            List<FactRuleNode<TFact, TFactRule>> currentLevel = factRuleTree.Levels[level];
            List<FactRuleNode<TFact, TFactRule>> computedNodesInCurrentLevel = new List<FactRuleNode<TFact, TFactRule>>();

            foreach (var node in currentLevel)
            {
                if (node.FactRule.InputFactTypes.Count > 0 && node.FactRule.InputFactTypes.All(f => computedNodes.Any(n => n.FactRule.OutputFactType.Compare(f))))
                    computedNodesInCurrentLevel.Add(node);
                else if (computedNodes.Any(n => n.FactRule.Compare(node.FactRule)))
                    computedNodesInCurrentLevel.Add(node);
            }

            if (!computedNodesInCurrentLevel.IsNullOrEmpty())
            {
                SyncComputedNodes(currentLevel, computedNodesInCurrentLevel);
                computedNodes.AddRange(computedNodesInCurrentLevel.Where(node => computedNodes.All(n => !n.FactRule.Compare(node.FactRule))));
                return SyncComputedNodeForLevelTreeAndCheckGoneRoot(factRuleTree, level - 1, computedNodes);
            }
            else
                return false;
        }

        private void SyncComputedNodes(List<FactRuleNode<TFact, TFactRule>> levelNodes, List<FactRuleNode<TFact, TFactRule>> computedNodes)
        {
            // value - parents, key - node matching on child
            Dictionary<FactRuleNode<TFact, TFactRule>, List<FactRuleNode<TFact, TFactRule>>> keyValuePairs = new Dictionary<FactRuleNode<TFact, TFactRule>, List<FactRuleNode<TFact, TFactRule>>>();
            foreach (var computedNode in computedNodes.Distinct())
            {
                List<FactRuleNode<TFact, TFactRule>> parentNodes = levelNodes
                    .Where(n => n.FactRule.OutputFactType.Compare(computedNode.FactRule.OutputFactType))
                    .Select(n => n.Parent).ToList();
                keyValuePairs.Add(computedNode, parentNodes);
            }

            foreach (KeyValuePair<FactRuleNode<TFact, TFactRule>, List<FactRuleNode<TFact, TFactRule>>> keyValuePair in keyValuePairs)
            {
                foreach (FactRuleNode<TFact, TFactRule> parentNode in keyValuePair.Value)
                {
                    if (parentNode == null)
                        continue;

                    foreach (var removeNode in parentNode.Childs.Where(n => n.FactRule.OutputFactType.Compare(keyValuePair.Key.FactRule.OutputFactType)).ToList())
                    {
                        parentNode.Childs.Remove(removeNode);
                        if (levelNodes.IndexOf(removeNode) != -1)
                            levelNodes.Remove(removeNode);
                    }
                    parentNode.Childs.Add(keyValuePair.Key);
                }
            }
        }

        private bool RemoveRuleNodeAndCheckGoneRoot(FactRuleTree<TFact, TFactRule> factRuleTree, int level, FactRuleNode<TFact, TFactRule> removeNode)
        {

            if (level == 0)
            {
                factRuleTree.Levels[level].Remove(removeNode);
                return true;
            }

            factRuleTree.Levels[level].Remove(removeNode);
            FactRuleNode<TFact, TFactRule> parent = removeNode.Parent;
            parent.Childs.Remove(removeNode);

            // If the node has a child node that can calculate this fact
            if (parent.Childs.Any(node => node.FactRule.OutputFactType.Compare(removeNode.FactRule.OutputFactType)))
                return false;
            else
                return RemoveRuleNodeAndCheckGoneRoot(factRuleTree, level - 1, parent);
        }

        private void DeriveNode(FactRuleNode<TFact, TFactRule> node, FactContainerBase<TFact> container, TWantAction wantAction, List<TFact> calculatedFacts)
        {
            foreach (FactRuleNode<TFact, TFactRule> child in node.Childs)
                DeriveNode(child, container, wantAction, calculatedFacts);

            TFactRule rule = node.FactRule;

            // 1. We decide whether the fact will be calculated at all
            if (rule.OutputFactType.TryGetFact(container, out TFact fact))
            {
                if (!NeedRecalculateFact(rule, container, wantAction))
                    return;

                using (container.CreateIgnoreReadOnlySpace())
                    container.Remove(fact);

                // We ask about recalculation for all facts of the current type, which we calculated
                foreach (TFact calculatedFact in calculatedFacts.Where(f => f.GetFactType().Compare(rule.OutputFactType) && f != fact))
                {
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Add(calculatedFact);

                    if (!NeedRecalculateFact(rule, container, wantAction))
                        return;

                    using (container.CreateIgnoreReadOnlySpace())
                        container.Remove(calculatedFact);
                }
            }

            // 2. Calculete fact
            TFact calculateFact = CreateObject(ct => rule.Calculate(ct), container);

            if (calculateFact == null)
                throw FactFactoryHelper.CreateDeriveException<TFact>(ErrorCode.InvalidOperation, $"Rule {rule.ToString()} return null");

            using (container.CreateIgnoreReadOnlySpace())
                container.Add(calculateFact);
            calculatedFacts.Add(calculateFact);

            OnFactCalculatedForWantAction(rule.OutputFactType, container, wantAction);
        }

        private bool TryDeriveNoFactInfo(INoDerivedFact noDerivedFact, TWantAction wantAction, FactContainerBase<TFact> container, IList<TFactRule> ruleCollection)
        {
            try
            {
                return TryDeriveTreeForFactInfo(out FactRuleTree<TFact, TFactRule> _, noDerivedFact.Value, wantAction, container, ruleCollection, new List<TFact>(), out var _);
            }
            catch (InvalidDeriveOperationException<TFact> ex)
            {
                if (ex.Details != null && ex.Details.Count == 1)
                {
                    DeriveErrorDetail<TFact> detail = ex.Details.First();

                    if (detail.Code == ErrorCode.RuleNotFound || detail.Code == ErrorCode.EmptyRuleCollection)
                        return false;
                }

                throw;
            }
        }

        #endregion

        #region overloads method WantFact

        /// <summary>
        /// Requesting a desired fact through action
        /// </summary>
        /// <param name="wantAction"></param>
        /// <exception cref="FactFactoryException">The action has already been requested before. Or facts requested <see cref="INoDerivedFact"/> or <see cref="INotContainedFact"/></exception>
        public virtual void WantFact(TWantAction wantAction)
        {
            if (WantActions.IndexOf(wantAction) != -1)
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidData, "Action already requested");

            WantActions.Add(wantAction);
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1"></typeparam>
        /// <param name="wantFactAction"></param>
        public virtual void WantFact<TFact1>(
            Action<TFact1> wantFactAction) where TFact1 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>()),
                new List<IFactType> { GetFactType<TFact1>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1"></typeparam>
        /// <typeparam name="TFact2"></typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2>(
            Action<TFact1, TFact2> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3>(
            Action<TFact1, TFact2, TFact3> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4>(
            Action<TFact1, TFact2, TFact3, TFact4> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <typeparam name="TFact5">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
            where TFact5 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <typeparam name="TFact5">type fact</typeparam>
        /// <typeparam name="TFact6">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
            where TFact5 : TFact
            where TFact6 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <typeparam name="TFact5">type fact</typeparam>
        /// <typeparam name="TFact6">type fact</typeparam>
        /// <typeparam name="TFact7">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
            where TFact5 : TFact
            where TFact6 : TFact
            where TFact7 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <typeparam name="TFact5">type fact</typeparam>
        /// <typeparam name="TFact6">type fact</typeparam>
        /// <typeparam name="TFact7">type fact</typeparam>
        /// <typeparam name="TFact8">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
            where TFact5 : TFact
            where TFact6 : TFact
            where TFact7 : TFact
            where TFact8 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <typeparam name="TFact5">type fact</typeparam>
        /// <typeparam name="TFact6">type fact</typeparam>
        /// <typeparam name="TFact7">type fact</typeparam>
        /// <typeparam name="TFact8">type fact</typeparam>
        /// <typeparam name="TFact9">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
            where TFact5 : TFact
            where TFact6 : TFact
            where TFact7 : TFact
            where TFact8 : TFact
            where TFact9 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <typeparam name="TFact5">type fact</typeparam>
        /// <typeparam name="TFact6">type fact</typeparam>
        /// <typeparam name="TFact7">type fact</typeparam>
        /// <typeparam name="TFact8">type fact</typeparam>
        /// <typeparam name="TFact9">type fact</typeparam>
        /// <typeparam name="TFact10">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
            where TFact5 : TFact
            where TFact6 : TFact
            where TFact7 : TFact
            where TFact8 : TFact
            where TFact9 : TFact
            where TFact10 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <typeparam name="TFact5">type fact</typeparam>
        /// <typeparam name="TFact6">type fact</typeparam>
        /// <typeparam name="TFact7">type fact</typeparam>
        /// <typeparam name="TFact8">type fact</typeparam>
        /// <typeparam name="TFact9">type fact</typeparam>
        /// <typeparam name="TFact10">type fact</typeparam>
        /// <typeparam name="TFact11">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
            where TFact5 : TFact
            where TFact6 : TFact
            where TFact7 : TFact
            where TFact8 : TFact
            where TFact9 : TFact
            where TFact10 : TFact
            where TFact11 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>(), container.GetFact<TFact11>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <typeparam name="TFact5">type fact</typeparam>
        /// <typeparam name="TFact6">type fact</typeparam>
        /// <typeparam name="TFact7">type fact</typeparam>
        /// <typeparam name="TFact8">type fact</typeparam>
        /// <typeparam name="TFact9">type fact</typeparam>
        /// <typeparam name="TFact10">type fact</typeparam>
        /// <typeparam name="TFact11">type fact</typeparam>
        /// <typeparam name="TFact12">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
            where TFact5 : TFact
            where TFact6 : TFact
            where TFact7 : TFact
            where TFact8 : TFact
            where TFact9 : TFact
            where TFact10 : TFact
            where TFact11 : TFact
            where TFact12 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>(), container.GetFact<TFact11>(), container.GetFact<TFact12>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <typeparam name="TFact5">type fact</typeparam>
        /// <typeparam name="TFact6">type fact</typeparam>
        /// <typeparam name="TFact7">type fact</typeparam>
        /// <typeparam name="TFact8">type fact</typeparam>
        /// <typeparam name="TFact9">type fact</typeparam>
        /// <typeparam name="TFact10">type fact</typeparam>
        /// <typeparam name="TFact11">type fact</typeparam>
        /// <typeparam name="TFact12">type fact</typeparam>
        /// <typeparam name="TFact13">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
            where TFact5 : TFact
            where TFact6 : TFact
            where TFact7 : TFact
            where TFact8 : TFact
            where TFact9 : TFact
            where TFact10 : TFact
            where TFact11 : TFact
            where TFact12 : TFact
            where TFact13 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>(), container.GetFact<TFact11>(), container.GetFact<TFact12>(), container.GetFact<TFact13>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>(), GetFactType<TFact13>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <typeparam name="TFact5">type fact</typeparam>
        /// <typeparam name="TFact6">type fact</typeparam>
        /// <typeparam name="TFact7">type fact</typeparam>
        /// <typeparam name="TFact8">type fact</typeparam>
        /// <typeparam name="TFact9">type fact</typeparam>
        /// <typeparam name="TFact10">type fact</typeparam>
        /// <typeparam name="TFact11">type fact</typeparam>
        /// <typeparam name="TFact12">type fact</typeparam>
        /// <typeparam name="TFact13">type fact</typeparam>
        /// <typeparam name="TFact14">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
            where TFact5 : TFact
            where TFact6 : TFact
            where TFact7 : TFact
            where TFact8 : TFact
            where TFact9 : TFact
            where TFact10 : TFact
            where TFact11 : TFact
            where TFact12 : TFact
            where TFact13 : TFact
            where TFact14 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>(), container.GetFact<TFact11>(), container.GetFact<TFact12>(), container.GetFact<TFact13>(), container.GetFact<TFact14>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>(), GetFactType<TFact13>(), GetFactType<TFact14>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <typeparam name="TFact5">type fact</typeparam>
        /// <typeparam name="TFact6">type fact</typeparam>
        /// <typeparam name="TFact7">type fact</typeparam>
        /// <typeparam name="TFact8">type fact</typeparam>
        /// <typeparam name="TFact9">type fact</typeparam>
        /// <typeparam name="TFact10">type fact</typeparam>
        /// <typeparam name="TFact11">type fact</typeparam>
        /// <typeparam name="TFact12">type fact</typeparam>
        /// <typeparam name="TFact13">type fact</typeparam>
        /// <typeparam name="TFact14">type fact</typeparam>
        /// <typeparam name="TFact15">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
            where TFact5 : TFact
            where TFact6 : TFact
            where TFact7 : TFact
            where TFact8 : TFact
            where TFact9 : TFact
            where TFact10 : TFact
            where TFact11 : TFact
            where TFact12 : TFact
            where TFact13 : TFact
            where TFact14 : TFact
            where TFact15 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>(), container.GetFact<TFact11>(), container.GetFact<TFact12>(), container.GetFact<TFact13>(), container.GetFact<TFact14>(), container.GetFact<TFact15>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>(), GetFactType<TFact13>(), GetFactType<TFact14>(), GetFactType<TFact15>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1">type fact</typeparam>
        /// <typeparam name="TFact2">type fact</typeparam>
        /// <typeparam name="TFact3">type fact</typeparam>
        /// <typeparam name="TFact4">type fact</typeparam>
        /// <typeparam name="TFact5">type fact</typeparam>
        /// <typeparam name="TFact6">type fact</typeparam>
        /// <typeparam name="TFact7">type fact</typeparam>
        /// <typeparam name="TFact8">type fact</typeparam>
        /// <typeparam name="TFact9">type fact</typeparam>
        /// <typeparam name="TFact10">type fact</typeparam>
        /// <typeparam name="TFact11">type fact</typeparam>
        /// <typeparam name="TFact12">type fact</typeparam>
        /// <typeparam name="TFact13">type fact</typeparam>
        /// <typeparam name="TFact14">type fact</typeparam>
        /// <typeparam name="TFact15">type fact</typeparam>
        /// <typeparam name="TFact16">type fact</typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15, TFact16>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15, TFact16> wantFactAction)
            where TFact1 : TFact
            where TFact2 : TFact
            where TFact3 : TFact
            where TFact4 : TFact
            where TFact5 : TFact
            where TFact6 : TFact
            where TFact7 : TFact
            where TFact8 : TFact
            where TFact9 : TFact
            where TFact10 : TFact
            where TFact11 : TFact
            where TFact12 : TFact
            where TFact13 : TFact
            where TFact14 : TFact
            where TFact15 : TFact
            where TFact16 : TFact
        {
            WantFact(CreateWantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>(), container.GetFact<TFact11>(), container.GetFact<TFact12>(), container.GetFact<TFact13>(), container.GetFact<TFact14>(), container.GetFact<TFact15>(), container.GetFact<TFact16>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>(), GetFactType<TFact13>(), GetFactType<TFact14>(), GetFactType<TFact15>(), GetFactType<TFact16>() }));
        }

        #endregion
    }
}
