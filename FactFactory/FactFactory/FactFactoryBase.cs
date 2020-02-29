using GetcuReone.ComboPatterns.Factory;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.TreeEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Base class for fact factory
    /// </summary>
    public abstract class FactFactoryBase<TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : FactoryBase, IFactFactory<TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction>
        where TFact : class, IFact
        where TFactContainer : class, IFactContainer<TFact>
        where TFactRule : class, IFactRule<TFact>
        where TFactRuleCollection : FactRuleCollectionBase<TFact, TFactRule>
        where TWantAction : class, IWantAction<TFact>
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
        /// Derive the facts
        /// </summary>
        public virtual void Derive()
        {
            // Get a copy of the container
            IFactContainer<TFact> container = Container.Copy();
            if (container.Equals(Container))
                throw FactFactoryHelper.CreateDeriveException<TFact, TWantAction>(ErrorCode.InvalidData, "IFactContainer.Copy method return original container.");

            // Get a copy of the rules
            FactRuleCollectionBase<TFact, TFactRule> rules = Rules.Copy();
            if (rules.Equals(Rules))
                throw FactFactoryHelper.CreateDeriveException<TFact, TWantAction>(ErrorCode.InvalidData, "FactRuleCollectionBase.Copy method return original rule collection.");

            var forestry = new Dictionary<TWantAction, List<FactRuleTree<TFact, TFactRule>>>();
            var notFoundFactsTrees = new Dictionary<TWantAction, Dictionary<IFactType, List<List<IFactType>>>>();
            List<TWantAction> wantActions = new List<TWantAction>(WantActions);

            foreach (TWantAction wantAction in wantActions)
            {
                if (TryDeriveTreesForWantAction(out List<FactRuleTree<TFact, TFactRule>> result, wantAction, container, rules, out Dictionary<IFactType, List<List<IFactType>>> notFoundFacts))
                    forestry.Add(wantAction, result);
                else
                {
                    foreach (var key in notFoundFacts.Keys)
                        notFoundFactsTrees.Add(wantAction, notFoundFacts);
                }
            }

            if (notFoundFactsTrees.Count != 0)
                throw FactFactoryHelper.CreateDeriveException<TFact, TWantAction>(notFoundFactsTrees);

            foreach (var key in forestry.Keys)
            {
                foreach (var tree in forestry[key])
                    DeriveNode(tree.Root, container, key);

                key.Invoke(container);

                OnWantActionCalculated(key, container);
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
        protected virtual void OnWantActionCalculated(TWantAction wantAction, IFactContainer<TFact> container)
        {

        }

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
        protected virtual IList<TFactRule> GetRulesForWantAction(TWantAction wantAction, IFactContainer<TFact> container, FactRuleCollectionBase<TFact, TFactRule> rules)
        {
            return rules;
        }

        /// <summary>
        /// Calculate fact.
        /// </summary>
        /// <param name="rule">Rule for calculating the fact.</param>
        /// <param name="container">Fact container.</param>
        /// <param name="wantAction">The initial action for which the parameters are calculated.</param>
        /// <remarks>True - fact calculate. False - fact already exists</remarks>
        protected virtual bool CalculateFact(TFactRule rule, IFactContainer<TFact> container, TWantAction wantAction)
        {
            if (!rule.OutputFactType.ContainsContainer(container))
            {
                List<TFact> includeFacts = new List<TFact>(
                rule.InputFactTypes
                    .Where(factInfo => factInfo.IsFactType<INotContainedFact>())
                    .Select(factInfo => (TFact)factInfo.CreateNotContained()));

                includeFacts.AddRange(
                    rule.InputFactTypes
                        .Where(factInfo => factInfo.IsFactType<INoDerivedFact>())
                        .Select(factInfo => (TFact)factInfo.CreateNoDerived()));

                foreach (var includeFact in includeFacts)
                    container.Add(includeFact);

                container.Add(CreateObject(ct => rule.Calculate(container), container));

                foreach (var includeFact in includeFacts)
                    container.Remove(includeFact);

                return true;
            }

            return false;
        }

        /// <summary>
        /// We are trying to calculate a tree by which we find a fact
        /// </summary>
        /// <param name="treesResult">found trees</param>
        /// <param name="wantAction">desired action information</param>
        /// <param name="container">fact container</param>
        /// <param name="rules">rule collection</param>
        /// <param name="notFoundFacts"></param>
        /// <returns></returns>
        private bool TryDeriveTreesForWantAction(out List<FactRuleTree<TFact, TFactRule>> treesResult, TWantAction wantAction, IFactContainer<TFact> container, FactRuleCollectionBase<TFact, TFactRule> rules, out Dictionary<IFactType, List<List<IFactType>>> notFoundFacts)
        {
            IList<TFactRule> rulesForDerive = GetRulesForWantAction(wantAction, container.Copy(), rules.Copy());

            // We check that we were not slipped into the new rules
            List<TFactRule> addedRules = new List<TFactRule>();
            foreach (TFactRule rule in rulesForDerive)
            {
                if (rules.All(r => r != rule))
                    addedRules.Add(rule);
            }

            if (addedRules.Count != 0)
                throw FactFactoryHelper.CreateDeriveException<TFact, TWantAction>(addedRules
                    .Select(rule => new KeyValuePair<string, string>(ErrorCode.InvalidData, $"GetRulesForWantAction method returned a new rule {rule.ToString()}"))
                    .ToList());

            treesResult = new List<FactRuleTree<TFact, TFactRule>>();
            notFoundFacts = new Dictionary<IFactType, List<List<IFactType>>>();

            foreach (IFactType wantFact in wantAction.InputFactTypes)
            {
                // If fact already exists
                if (wantFact.ContainsContainer(container))
                    continue;

                if (TryDeriveTreeForFactInfo(out FactRuleTree<TFact, TFactRule> treeResult, wantFact, container, rulesForDerive, out List<List<IFactType>> notFoundFactSet))
                {
                    treesResult.Add(treeResult);
                }
                else
                {
                    notFoundFacts.Add(wantFact, notFoundFactSet);
                }
            }

            return notFoundFacts.Count == 0;
        }

        private bool TryDeriveTreeForFactInfo(out FactRuleTree<TFact, TFactRule> treeResult, IFactType wantFact, IFactContainer<TFact> container, IList<TFactRule> ruleCollection, out List<List<IFactType>> notFoundFactSet)
        {
            treeResult = null;
            notFoundFactSet = null;

            // find the rules that can calculate the fact
            List<FactRuleTree<TFact, TFactRule>> factRuleTrees = GetFactRuleTrees(wantFact, ruleCollection);

            // Check if we can already derive the fact
            FactRuleTree<TFact, TFactRule> factRuleTreeComputed = factRuleTrees.FirstOrDefault(tree => tree.Root.FactRule.CanCalculate(container));

            if (factRuleTreeComputed != null)
            {
                treeResult = factRuleTreeComputed;
                return true;
            }

            // create the necessary number of sets of missing facts
            notFoundFactSet = factRuleTrees.ConvertAll(item => new List<IFactType>());
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

                            // Check INotContainedFact fact
                            if (needFactType.IsFactType<INotContainedFact>())
                            {
                                INotContainedFact notContainedFact = needFactType.CreateNotContained();

                                if (container.All(fact => !notContainedFact.IsFactContained(container)))
                                    needRemove = true;
                            }

                            // Check INoDerivedFact fact
                            if (needFactType.IsFactType<INoDerivedFact>())
                            {
                                if (!TryDeriveNoFactInfo(needFactType, container, ruleCollection))
                                    needRemove = true;
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
                            if (needFact.IsFactType<INoDerivedFact>() || needFact.IsFactType<INotContainedFact>())
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
                throw FactFactoryHelper.CreateDeriveException<TFact, TWantAction>(ErrorCode.EmptyRuleCollection, "Rules cannot be null");

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
                throw FactFactoryHelper.CreateDeriveException<TFact, TWantAction>(ErrorCode.RuleNotFound, $"There is no rule that can deduce a {wantFact.FactName}");

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

        private void DeriveNode(FactRuleNode<TFact, TFactRule> node, IFactContainer<TFact> container, TWantAction wantAction)
        {
            foreach (FactRuleNode<TFact, TFactRule> child in node.Childs)
                DeriveNode(child, container, wantAction);

            CalculateFact(node.FactRule, container, wantAction);
        }

        private bool TryDeriveNoFactInfo(IFactType wantFact, IFactContainer<TFact> container, IList<TFactRule> ruleCollection)
        {
            try
            {
                return TryDeriveTreeForFactInfo(out FactRuleTree<TFact, TFactRule> _, wantFact.CreateNoDerived().Value, container, ruleCollection, out List<List<IFactType>> _);
            }
            catch (InvalidDeriveOperationException<TFact, TWantAction> ex)
            {
                if (ex.Details != null && ex.Details.Count == 1 && ex.Details[0].Code == ErrorCode.RuleNotFound)
                    return false;

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

            if (wantAction.InputFactTypes.Any(fact => fact.IsFactType<INoDerivedFact>() || fact.IsFactType<INotContainedFact>()))
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidData, $"Cannot derive for No and NotContained facts");

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
