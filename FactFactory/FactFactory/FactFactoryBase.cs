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
    public abstract class FactFactoryBase<TFactBase, TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : FactoryBase, IFactFactory<TFactBase, TFactContainer, TFactRule, TFactRuleCollection, TWantAction>
        where TFactBase : class, IFact
        where TFactContainer : FactContainerBase<TFactBase>
        where TFactRule : FactRuleBase<TFactBase>
        where TFactRuleCollection : FactRuleCollectionBase<TFactBase, TFactRule>
        where TWantAction : WantActionBase<TFactBase>
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
        protected virtual IEnumerable<TFactBase> GetDefaultFacts(TFactContainer container)
        {
            return Enumerable.Empty<TFactBase>();
        }

        /// <summary>
        /// Derive the facts
        /// </summary>
        public virtual void Derive()
        {
            // Get a copy of the container
            if (Container == null)
                throw FactFactoryHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "Container cannot be null.");

            FactContainerBase<TFactBase> containerCopy = Container.Copy();
            if (containerCopy == null)
                throw FactFactoryHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "IFactContainer.Copy method return null.");
            if (Container.Equals(containerCopy))
                throw FactFactoryHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "IFactContainer.Copy method return original container.");
            if (!(containerCopy is TFactContainer))
                throw FactFactoryHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "IFactContainer.Copy method returned a different type of container.");

            TFactContainer container = (TFactContainer)containerCopy;
            container.IsReadOnly = true;

            List<IFactType> defaultFacts = new List<IFactType>();
            foreach(TFactBase fact in GetDefaultFacts(container) ?? Enumerable.Empty<TFactBase>())
            {
                IFactType type = fact.GetFactType();

                if (defaultFacts.Any(dType => dType.Compare(type)))
                    throw FactFactoryHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, $"GetDefaultFacts method return more than two {type.FactName} facts");

                if (!type.ContainsContainer(container))
                {
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Add(fact);

                    defaultFacts.Add(type);
                }
            }

            if (container.Any(fact => fact.IsSpecialFact()))
                throw FactFactoryHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, $"In the container there should be no facts realizing types {nameof(INotContainedFact)} and {nameof(INoDerivedFact)}");

            // Get a copy of the rules
            FactRuleCollectionBase<TFactBase, TFactRule> rules = Rules.Copy();
            if (rules.Equals(Rules))
                throw FactFactoryHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "FactRuleCollectionBase.Copy method return original rule collection.");
            rules.IsReadOnly = true;

            var forestry = new Dictionary<TWantAction, List<FactRuleTree<TFactBase, TFactRule>>>();
            List<DeriveErrorDetail<TFactBase>> deriveErrorDetails = new List<DeriveErrorDetail<TFactBase>>();
            var needSpecialFacts = new Dictionary<TWantAction, List<TFactBase>>();
            List<TWantAction> wantActions = new List<TWantAction>(WantActions);

            foreach (TWantAction wantAction in wantActions)
            {
                if (TryDeriveTreesForWantAction(out List<FactRuleTree<TFactBase, TFactRule>> result, wantAction, container, rules, out List<TFactBase> specialFacts, out DeriveErrorDetail<TFactBase> detail))
                {
                    forestry.Add(wantAction, result);
                    needSpecialFacts.Add(wantAction, specialFacts);
                }
                else
                    deriveErrorDetails.Add(detail);
            }

            if (deriveErrorDetails.Count != 0)
                throw FactFactoryHelper.CreateDeriveException(deriveErrorDetails);

            var calculatedFacts = new List<TFactBase>();
            foreach (var key in forestry.Keys)
            {
                foreach (TFactBase fact in needSpecialFacts[key])
                {
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Add(fact);
                }

                foreach (var tree in forestry[key])
                    DeriveNode(tree.Root, container, key, calculatedFacts);

                key.Invoke(container);

                OnWantActionCalculated(key, container);

                foreach (TFactBase fact in needSpecialFacts[key])
                {
                    using(container.CreateIgnoreReadOnlySpace())
                        container.Remove(fact);
                }
            }

            OnDeriveFinished(wantActions, container, calculatedFacts);

            foreach(var type in defaultFacts)
            {
                if (type.TryGetFact(container, out TFactBase fact))
                {
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Remove(fact);
                }
            }
        }

        /// <summary>
        /// Derive <typeparamref name="TFact"/>
        /// </summary>
        /// <typeparam name="TFact">Type of desired fact</typeparam>
        /// <returns></returns>
        public virtual TFact DeriveFact<TFact>() where TFact : TFactBase
        {
            TFact fact = default;

            var wantActions = new List<TWantAction>(WantActions);
            WantActions.Clear();

            var inputFacts = new List<IFactType> { GetFactType<TFact>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => fact = GetCorrectFact<TFact>(container, inputFacts),
                inputFacts));

            Derive();

            WantActions.AddRange(wantActions);

            return fact;
        }

        /// <summary>
        /// Action calculation completion handler
        /// </summary>
        /// <param name="wantAction"></param>
        /// <param name="container"></param>
        protected virtual void OnWantActionCalculated(TWantAction wantAction, TFactContainer container) { }

        /// <summary>
        /// Fact calculation event handler for an <paramref name="wantAction"/>.
        /// </summary>
        /// <param name="factType">Type calculated fact.</param>
        /// <param name="container">Container.</param>
        /// <param name="wantAction">The action for which the fact was calculated.</param>
        protected virtual void OnFactCalculatedForWantAction(IFactType factType, TFactContainer container, TWantAction wantAction) { }

        /// <summary>
        /// Event handler method 'derive finished'. It is executed at the end of the <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/> method.
        /// </summary>
        /// <param name="wantActions">List of desired actions.</param>
        /// <param name="container">Container.</param>
        /// <param name="calculatedFacts">List of all calculated facts.</param>
        protected virtual void OnDeriveFinished(List<TWantAction> wantActions, TFactContainer container, List<TFactBase> calculatedFacts) { }

        #region methods for derive

        /// <summary>
        /// creation method <typeparamref name="TWantAction"/>
        /// </summary>
        /// <param name="wantAction">action taken after deriving a fact</param>
        /// <param name="factTypes">facts required to launch an action</param>
        /// <returns></returns>
        protected abstract TWantAction CreateWantAction(Action<IFactContainer<TFactBase>> wantAction, IReadOnlyCollection<IFactType> factTypes);

        /// <summary>
        /// Return a list with the appropriate rules at the time of the derive of the facts.
        /// </summary>
        /// <param name="rules">Current set of rules.</param>
        /// <param name="container">Current fact set.</param>
        /// <param name="wantAction">Current wantAction</param>
        /// <returns></returns>
        protected virtual IList<TFactRule> GetRulesForWantAction(TWantAction wantAction, TFactContainer container, FactRuleCollectionBase<TFactBase, TFactRule> rules)
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
        protected virtual bool NeedRecalculateFact(TFactRule rule, TFactContainer container, TWantAction wantAction)
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
        private bool TryDeriveTreesForWantAction(out List<FactRuleTree<TFactBase, TFactRule>> treesResult, TWantAction wantAction, TFactContainer container, FactRuleCollectionBase<TFactBase, TFactRule> rules, out List<TFactBase> specialFacts, out DeriveErrorDetail<TFactBase> deriveErrorDetail)
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

            treesResult = new List<FactRuleTree<TFactBase, TFactRule>>();
            var deriveFactErrorDetails = new List<DeriveFactErrorDetail>();
            deriveErrorDetail = null;
            specialFacts = new List<TFactBase>();

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
                            TFactBase specialFact = notContainedFact.ConvertFact<TFactBase>();
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
                            TFactBase specialFact = containedFact.ConvertFact<TFactBase>();
                            specialFacts.Add(specialFact);
                            continue;
                        }
                    }
                    else if (wantFact.IsFactType<INoDerivedFact>())
                    {
                        INoDerivedFact noDerivedFact = wantFact.CreateSpecialFact<INoDerivedFact>();
                        if (!noDerivedFact.Value.ContainsContainer(container) && !TryDeriveNoFactInfo(noDerivedFact, wantAction, container, rules))
                        {
                            TFactBase specialFact = noDerivedFact.ConvertFact<TFactBase>();
                            specialFacts.Add(specialFact);
                            continue;
                        }

                        deriveFactErrorDetails.Add(new DeriveFactErrorDetail(wantFact, null));
                        continue;
                    }
                }

                if (TryDeriveTreeForFactInfo(out FactRuleTree<TFactBase, TFactRule> treeResult, wantFact, wantAction, container, rulesForDerive, specialFacts, out List<DeriveFactErrorDetail> details))
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
                deriveErrorDetail = new DeriveErrorDetail<TFactBase>(ErrorCode.FactCannotCalculated, $"Failed to calculate one or more facts for the action {wantAction.ToString()}.", wantAction, deriveFactErrorDetails);
                return false;
            }

            return true;
        }

        private bool TryDeriveTreeForFactInfo(out FactRuleTree<TFactBase, TFactRule> treeResult, IFactType wantFact, TWantAction wantAction, TFactContainer container, IList<TFactRule> ruleCollection, List<TFactBase> specialFacts, out List<DeriveFactErrorDetail> deriveFactErrorDetails)
        {
            treeResult = null;
            deriveFactErrorDetails = null;

            // find the rules that can calculate the fact
            List<FactRuleTree<TFactBase, TFactRule>> factRuleTrees = GetFactRuleTrees(wantFact, ruleCollection);

            // Check if we can already derive the fact
            FactRuleTree<TFactBase, TFactRule> factRuleTreeComputed = factRuleTrees.FirstOrDefault(tree => tree.Root.FactRule.CanCalculate(container, wantAction));

            if (factRuleTreeComputed != null)
            {
                treeResult = factRuleTreeComputed;
                return true;
            }

            List<List<IFactType>> notFoundFactSet = factRuleTrees.ConvertAll(item => new List<IFactType>());
            List<FactRuleNode<TFactBase, TFactRule>> allCompletedNodes = new List<FactRuleNode<TFactBase, TFactRule>>();

            while (true)
            {
                for (int i = factRuleTrees.Count - 1; i >= 0; i--)
                {
                    FactRuleTree<TFactBase, TFactRule> factRuleTree = factRuleTrees[i];

                    if (factRuleTree == null)
                        continue;

                    int lastlevelNumber = factRuleTree.Levels.Count - 1;

                    if (SyncComputedNodeForLevelTreeAndCheckGoneRoot(factRuleTree, lastlevelNumber, allCompletedNodes))
                    {
                        treeResult = factRuleTree;
                        return true;
                    }

                    List<FactRuleNode<TFactBase, TFactRule>> lastLevel = factRuleTree.Levels[lastlevelNumber];

                    if (lastLevel.Count == 0)
                    {
                        treeResult = factRuleTree;
                        return true;
                    }

                    List<FactRuleNode<TFactBase, TFactRule>> nextNodes = new List<FactRuleNode<TFactBase, TFactRule>>();
                    List<FactRuleNode<TFactBase, TFactRule>> currentLevelCompletedNodes = new List<FactRuleNode<TFactBase, TFactRule>>();
                    bool cannotDerived = false;

                    for (int j = 0; j < lastLevel.Count; j++)
                    {
                        FactRuleNode<TFactBase, TFactRule> node = lastLevel[j];

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
                                        specialFacts.Add(notContainedFact.ConvertFact<TFactBase>());
                                        needRemove = true;
                                    }
                                }

                                // Check IContainedFact fact
                                else if (isContained)
                                {
                                    IContainedFact containedFact = needFactType.CreateSpecialFact<IContainedFact>();

                                    if (container.Any(fact => containedFact.IsFactContained(container)))
                                    {
                                        specialFacts.Add(containedFact.ConvertFact<TFactBase>());
                                        needRemove = true;
                                    }
                                }

                                // Check INoDerivedFact fact
                                else if (needFactType.IsFactType<INoDerivedFact>())
                                {
                                    INoDerivedFact noDerivedFact = needFactType.CreateSpecialFact<INoDerivedFact>();

                                    if (!TryDeriveNoFactInfo(noDerivedFact, wantAction, container, ruleCollection))
                                    {
                                        specialFacts.Add(noDerivedFact.ConvertFact<TFactBase>());
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
                                var nodes = needRules.Select(rule => new FactRuleNode<TFactBase, TFactRule>
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
        private List<FactRuleTree<TFactBase, TFactRule>> GetFactRuleTrees(IFactType wantFact, IList<TFactRule> rules)
        {
            if (rules.IsNullOrEmpty())
                throw FactFactoryHelper.CreateDeriveException<TFactBase>(ErrorCode.EmptyRuleCollection, "Rules cannot be null.");

            List<FactRuleTree<TFactBase, TFactRule>> factRuleTrees = rules?.Where(rule => rule.OutputFactType.Compare(wantFact))
                    .Select(rule =>
                    {
                        var tree = new FactRuleTree<TFactBase, TFactRule>
                        {
                            Root = new FactRuleNode<TFactBase, TFactRule> { FactRule = rule }
                        };
                        tree.Levels.Add(new List<FactRuleNode<TFactBase, TFactRule>> { tree.Root });
                        return tree;
                    })
                    .ToList();

            if (factRuleTrees.IsNullOrEmpty())
                throw FactFactoryHelper.CreateDeriveException<TFactBase>(ErrorCode.RuleNotFound, $"No rules found able to calculate fact {wantFact.FactName}.");

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
        private bool SyncComputedNodeForLevelTreeAndCheckGoneRoot(FactRuleTree<TFactBase, TFactRule> factRuleTree, int level, List<FactRuleNode<TFactBase, TFactRule>> computedNodes)
        {
            if (level < 0)
                return true;

            List<FactRuleNode<TFactBase, TFactRule>> currentLevel = factRuleTree.Levels[level];
            List<FactRuleNode<TFactBase, TFactRule>> computedNodesInCurrentLevel = new List<FactRuleNode<TFactBase, TFactRule>>();

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

        private void SyncComputedNodes(List<FactRuleNode<TFactBase, TFactRule>> levelNodes, List<FactRuleNode<TFactBase, TFactRule>> computedNodes)
        {
            // value - parents, key - node matching on child
            Dictionary<FactRuleNode<TFactBase, TFactRule>, List<FactRuleNode<TFactBase, TFactRule>>> keyValuePairs = new Dictionary<FactRuleNode<TFactBase, TFactRule>, List<FactRuleNode<TFactBase, TFactRule>>>();
            foreach (var computedNode in computedNodes.Distinct())
            {
                List<FactRuleNode<TFactBase, TFactRule>> parentNodes = levelNodes
                    .Where(n => n.FactRule.OutputFactType.Compare(computedNode.FactRule.OutputFactType))
                    .Select(n => n.Parent).ToList();
                keyValuePairs.Add(computedNode, parentNodes);
            }

            foreach (KeyValuePair<FactRuleNode<TFactBase, TFactRule>, List<FactRuleNode<TFactBase, TFactRule>>> keyValuePair in keyValuePairs)
            {
                foreach (FactRuleNode<TFactBase, TFactRule> parentNode in keyValuePair.Value)
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

        private bool RemoveRuleNodeAndCheckGoneRoot(FactRuleTree<TFactBase, TFactRule> factRuleTree, int level, FactRuleNode<TFactBase, TFactRule> removeNode)
        {

            if (level == 0)
            {
                factRuleTree.Levels[level].Remove(removeNode);
                return true;
            }

            factRuleTree.Levels[level].Remove(removeNode);
            FactRuleNode<TFactBase, TFactRule> parent = removeNode.Parent;
            parent.Childs.Remove(removeNode);

            // If the node has a child node that can calculate this fact
            if (parent.Childs.Any(node => node.FactRule.OutputFactType.Compare(removeNode.FactRule.OutputFactType)))
                return false;
            else
                return RemoveRuleNodeAndCheckGoneRoot(factRuleTree, level - 1, parent);
        }

        private void DeriveNode(FactRuleNode<TFactBase, TFactRule> node, TFactContainer container, TWantAction wantAction, List<TFactBase> calculatedFacts)
        {
            foreach (FactRuleNode<TFactBase, TFactRule> child in node.Childs)
                DeriveNode(child, container, wantAction, calculatedFacts);

            TFactRule rule = node.FactRule;

            // 1. We decide whether the fact will be calculated at all
            if (rule.OutputFactType.TryGetFact(container, out TFactBase fact))
            {
                if (!NeedRecalculateFact(rule, container, wantAction))
                    return;

                using (container.CreateIgnoreReadOnlySpace())
                    container.Remove(fact);

                // We ask about recalculation for all facts of the current type, which we calculated
                foreach (TFactBase calculatedFact in calculatedFacts.Where(f => f.GetFactType().Compare(rule.OutputFactType) && f != fact))
                {
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Add(calculatedFact);

                    if (!NeedRecalculateFact(rule, container, wantAction))
                        return;
                }
            }

            // 2. Calculete fact
            TFactBase calculateFact = CreateObject(ct => rule.Calculate(ct, wantAction), container);

            if (calculateFact == null)
                throw FactFactoryHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidOperation, $"Rule {rule.ToString()} return null");

            using (container.CreateIgnoreReadOnlySpace())
                container.Add(calculateFact);
            calculatedFacts.Add(calculateFact);

            OnFactCalculatedForWantAction(rule.OutputFactType, container, wantAction);
        }

        private bool TryDeriveNoFactInfo(INoDerivedFact noDerivedFact, TWantAction wantAction, TFactContainer container, IList<TFactRule> ruleCollection)
        {
            try
            {
                return TryDeriveTreeForFactInfo(out FactRuleTree<TFactBase, TFactRule> _, noDerivedFact.Value, wantAction, container, ruleCollection, new List<TFactBase>(), out var _);
            }
            catch (InvalidDeriveOperationException<TFactBase> ex)
            {
                if (ex.Details != null && ex.Details.Count == 1)
                {
                    DeriveErrorDetail<TFactBase> detail = ex.Details.First();

                    if (detail.Code == ErrorCode.RuleNotFound || detail.Code == ErrorCode.EmptyRuleCollection)
                        return false;
                }

                throw;
            }
        }

        #endregion

        #region overloads method WantFact

        /// <summary>
        /// Return the correct fact.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="container"></param>
        /// <param name="inputFactTypes"></param>
        /// <returns></returns>
        protected virtual TFact GetCorrectFact<TFact>(IFactContainer<TFactBase> container, IReadOnlyCollection<IFactType> inputFactTypes)
            where TFact : TFactBase
        {
            return container.GetFact<TFact>();
        }

        /// <summary>
        /// Requesting a desired fact through action.
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
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1>(
            Action<TFact1> wantFactAction) where TFact1 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2>(
            Action<TFact1, TFact2> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3>(
            Action<TFact1, TFact2, TFact3> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4>(
            Action<TFact1, TFact2, TFact3, TFact4> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
            where TFact5 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
            where TFact5 : TFactBase
            where TFact6 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>()}
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
            where TFact5 : TFactBase
            where TFact6 : TFactBase
            where TFact7 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>() }
                 .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
            where TFact5 : TFactBase
            where TFact6 : TFactBase
            where TFact7 : TFactBase
            where TFact8 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
            where TFact5 : TFactBase
            where TFact6 : TFactBase
            where TFact7 : TFactBase
            where TFact8 : TFactBase
            where TFact9 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
            where TFact5 : TFactBase
            where TFact6 : TFactBase
            where TFact7 : TFactBase
            where TFact8 : TFactBase
            where TFact9 : TFactBase
            where TFact10 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <typeparam name="TFact11">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
            where TFact5 : TFactBase
            where TFact6 : TFactBase
            where TFact7 : TFactBase
            where TFact8 : TFactBase
            where TFact9 : TFactBase
            where TFact10 : TFactBase
            where TFact11 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts), GetCorrectFact<TFact11>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <typeparam name="TFact11">Type fact.</typeparam>
        /// <typeparam name="TFact12">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
            where TFact5 : TFactBase
            where TFact6 : TFactBase
            where TFact7 : TFactBase
            where TFact8 : TFactBase
            where TFact9 : TFactBase
            where TFact10 : TFactBase
            where TFact11 : TFactBase
            where TFact12 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts), GetCorrectFact<TFact11>(container, inputFacts), GetCorrectFact<TFact12>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <typeparam name="TFact11">Type fact.</typeparam>
        /// <typeparam name="TFact12">Type fact.</typeparam>
        /// <typeparam name="TFact13">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
            where TFact5 : TFactBase
            where TFact6 : TFactBase
            where TFact7 : TFactBase
            where TFact8 : TFactBase
            where TFact9 : TFactBase
            where TFact10 : TFactBase
            where TFact11 : TFactBase
            where TFact12 : TFactBase
            where TFact13 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>(), GetFactType<TFact13>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts), GetCorrectFact<TFact11>(container, inputFacts), GetCorrectFact<TFact12>(container, inputFacts), GetCorrectFact<TFact13>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <typeparam name="TFact11">Type fact.</typeparam>
        /// <typeparam name="TFact12">Type fact.</typeparam>
        /// <typeparam name="TFact13">Type fact.</typeparam>
        /// <typeparam name="TFact14">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
            where TFact5 : TFactBase
            where TFact6 : TFactBase
            where TFact7 : TFactBase
            where TFact8 : TFactBase
            where TFact9 : TFactBase
            where TFact10 : TFactBase
            where TFact11 : TFactBase
            where TFact12 : TFactBase
            where TFact13 : TFactBase
            where TFact14 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>(), GetFactType<TFact13>(), GetFactType<TFact14>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts), GetCorrectFact<TFact11>(container, inputFacts), GetCorrectFact<TFact12>(container, inputFacts), GetCorrectFact<TFact13>(container, inputFacts), GetCorrectFact<TFact14>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <typeparam name="TFact11">Type fact.</typeparam>
        /// <typeparam name="TFact12">Type fact.</typeparam>
        /// <typeparam name="TFact13">Type fact.</typeparam>
        /// <typeparam name="TFact14">Type fact.</typeparam>
        /// <typeparam name="TFact15">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
            where TFact5 : TFactBase
            where TFact6 : TFactBase
            where TFact7 : TFactBase
            where TFact8 : TFactBase
            where TFact9 : TFactBase
            where TFact10 : TFactBase
            where TFact11 : TFactBase
            where TFact12 : TFactBase
            where TFact13 : TFactBase
            where TFact14 : TFactBase
            where TFact15 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>(), GetFactType<TFact13>(), GetFactType<TFact14>(), GetFactType<TFact15>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts), GetCorrectFact<TFact11>(container, inputFacts), GetCorrectFact<TFact12>(container, inputFacts), GetCorrectFact<TFact13>(container, inputFacts), GetCorrectFact<TFact14>(container, inputFacts), GetCorrectFact<TFact15>(container, inputFacts)),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <typeparam name="TFact11">Type fact.</typeparam>
        /// <typeparam name="TFact12">Type fact.</typeparam>
        /// <typeparam name="TFact13">Type fact.</typeparam>
        /// <typeparam name="TFact14">Type fact.</typeparam>
        /// <typeparam name="TFact15">Type fact.</typeparam>
        /// <typeparam name="TFact16">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15, TFact16>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15, TFact16> wantFactAction)
            where TFact1 : TFactBase
            where TFact2 : TFactBase
            where TFact3 : TFactBase
            where TFact4 : TFactBase
            where TFact5 : TFactBase
            where TFact6 : TFactBase
            where TFact7 : TFactBase
            where TFact8 : TFactBase
            where TFact9 : TFactBase
            where TFact10 : TFactBase
            where TFact11 : TFactBase
            where TFact12 : TFactBase
            where TFact13 : TFactBase
            where TFact14 : TFactBase
            where TFact15 : TFactBase
            where TFact16 : TFactBase
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>(), GetFactType<TFact13>(), GetFactType<TFact14>(), GetFactType<TFact15>(), GetFactType<TFact16>() }
                .ToReadOnlyCollection();

            WantFact(CreateWantAction(
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts), GetCorrectFact<TFact11>(container, inputFacts), GetCorrectFact<TFact12>(container, inputFacts), GetCorrectFact<TFact13>(container, inputFacts), GetCorrectFact<TFact14>(container, inputFacts), GetCorrectFact<TFact15>(container, inputFacts), GetCorrectFact<TFact16>(container, inputFacts)),
                inputFacts));
        }

        #endregion
    }
}
