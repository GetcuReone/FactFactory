using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Base class for fact factory
    /// </summary>
    public abstract class FactFactoryBase<TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : IFactFactory<TFactContainer, TFactRule, TFactRuleCollection, TWantAction>
        where TFactContainer : class, IFactContainer
        where TFactRule : class, IFactRule
        where TFactRuleCollection : class, IList<TFactRule>
        where TWantAction : class, IWantAction
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
        /// Object creation method
        /// </summary>
        /// <typeparam name="TParameters"></typeparam>
        /// <typeparam name="TObj"></typeparam>
        /// <param name="factoryFunc"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual TObj CreateObject<TParameters, TObj>(Func<TParameters, TObj> factoryFunc, TParameters parameters)
        {
            return factoryFunc != null
                ? factoryFunc(parameters)
                : throw new ArgumentNullException(nameof(factoryFunc));
        }

        /// <summary>
        /// Derive the facts
        /// </summary>
        public virtual void Derive()
        {
            TFactContainer container = GetContainerForDerive();

            if (container.Equals(Container))
                throw FactFactoryHelper.CreateDeriveException(ErrorCode.InvalidData, "method GetCopyContainer return original container");

            container.Add(new DateOfDeriveFact(DateTime.Now));
            container.Add(new DerivingCurrentFactsFact(
                new ReadOnlyCollection<IFactType>(
                    WantActions.SelectMany(action => action.InputFactTypes).ToList())));

            var derivedTrees = new Dictionary<TWantAction, List<FactRuleTree>>();
            var notFoundFactsTrees = new Dictionary<IWantAction, Dictionary<IFactType, List<List<IFactType>>>>();
            IReadOnlyCollection<IFactType> excludeFacts = GeTFactTypesAvailableOnlyRules();
            List<TWantAction> wantActions = new List<TWantAction>(WantActions);

            foreach (TWantAction wantAction in wantActions)
            {

                if (TryDeriveTreesForWantAction(out List<FactRuleTree> result, wantAction, container, excludeFacts, out Dictionary<IFactType, List<List<IFactType>>> notFoundFacts))
                    derivedTrees.Add(wantAction, result);
                else
                {
                    foreach (var key in notFoundFacts.Keys)
                        notFoundFactsTrees.Add(wantAction, notFoundFacts);
                }
            }

            if (notFoundFactsTrees.Count != 0)
                throw FactFactoryHelper.CreateDeriveException(notFoundFactsTrees);

            foreach (var key in derivedTrees.Keys)
            {
                container.Add(new DateOfDeriveCurrentFact(key.DateOfDerive));
                container.Add(new CurrentFactsFindingFact(key.InputFactTypes.ToList()));

                foreach (var tree in derivedTrees[key])
                    DeriveNode(tree.Root, container);

                key.Invoke(container);

                container.Remove<CurrentFactsFindingFact>();
                container.Remove<DateOfDeriveCurrentFact>();
            }
        }

        /// <summary>
        /// Derive <typeparamref name="TFact"/>
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        public abstract TFact DeriveFact<TFact>() where TFact : IFact;

        /// <summary>
        /// Requesting a desired fact through action
        /// </summary>
        /// <param name="wantAction"></param>
        public virtual void WantFact(TWantAction wantAction)
        {
            if (WantActions.IndexOf(wantAction) != -1)
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidData, "Action already requested");

            var excludeFacts = GeTFactTypesAvailableOnlyRules();

            var excludeFact = wantAction.InputFactTypes.FirstOrDefault(f => excludeFacts.Any(ef => ef.Compare(f)));

            if (excludeFact != null)
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidData, $"The {excludeFact.FactName} is available only for the rules");
            if (wantAction.InputFactTypes.Any(fact => fact.IsFactType<INoFact>() || fact.IsFactType<INotContainedFact>()))
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidData, $"Cannot derive for No and NotContained facts");

            WantActions.Add(wantAction);
        }

        /// <summary>
        /// Get facts available only in rules
        /// </summary>
        protected virtual IReadOnlyCollection<IFactType> GetFactTypesAvailableOnlyRules()
        {
            return new ReadOnlyCollection<IFactType>(new List<IFactType> 
            {
                new FactInfo<CurrentFactsFindingFact>(),
                new FactInfo<DateOfDeriveCurrentFact>(),
            });
        }

        #region methods for derive

        /// <summary>
        /// Return a list with the appropriate rules at the time of the derive of the facts
        /// </summary>
        /// <returns></returns>
        protected virtual IReadOnlyCollection<TFactRule> GetRulesForWantAction(TWantAction wantAction)
        {
            return new ReadOnlyCollection<TFactRule>(Rules);
        }

        /// <summary>
        /// Calculate fact
        /// </summary>
        /// <param name="rule">rule for calculating the fact</param>
        /// <param name="container">fact container</param>
        protected virtual void CalculateFact(TFactRule rule, TFactContainer container)
        {
            if (!rule.OutputFactType.ContainsContainer(container))
                container.Add(CreateObject(ct => rule.Derive(container), container));
        }

        /// <summary>
        /// Get container for derive
        /// </summary>
        /// <returns></returns>
        protected abstract TFactContainer GetContainerForDerive();

        /// <summary>
        /// We are trying to calculate a tree by which we find a fact
        /// </summary>
        /// <param name="treesResult">found trees</param>
        /// <param name="wantAction">desired action information</param>
        /// <param name="container">fact container</param>
        /// <param name="excludeFacts">facts that should not be calculated</param>
        /// <param name="notFoundFacts"></param>
        /// <returns></returns>
        private bool TryDeriveTreesForWantAction(out List<FactRuleTree> treesResult, TWantAction wantAction, TFactContainer container, IReadOnlyCollection<IFactType> excludeFacts, out Dictionary<IFactType, List<List<IFactType>>> notFoundFacts)
        {
            IReadOnlyCollection<TFactRule> ruleCollection = GetRulesForWantAction(wantAction);
            wantAction.DateOfDerive = DateTime.Now;
            treesResult = new List<FactRuleTree>();
            notFoundFacts = new Dictionary<IFactType, List<List<IFactType>>>();

            foreach (IFactType wantFact in wantAction.InputFactTypes)
            {
                // If fact already exists
                if (wantFact.ContainsContainer(container))
                    continue;

                if (TryDeriveTreeForFactInfo(out FactRuleTree treeResult, wantFact, container, ruleCollection, excludeFacts, out List<List<IFactType>> notFoundFactSet))
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

        private bool TryDeriveTreeForFactInfo(out FactRuleTree treeResult, IFactType wantFact, TFactContainer container, IReadOnlyCollection<TFactRule> ruleCollection, IReadOnlyCollection<IFactType> excludeFacts, out List<List<IFactType>> notFoundFactSet)
        {
            treeResult = null;
            notFoundFactSet = null;

            // find the rules that can calculate the fact
            List<FactRuleTree> factRuleTrees = GetFactRuleTrees(wantFact, ruleCollection);

            // Check if we can already derive the fact
            FactRuleTree factRuleTreeComputed = factRuleTrees.FirstOrDefault(tree => tree.Root.FactRule.CanDerive(container));

            if (factRuleTreeComputed != null)
            {
                treeResult = factRuleTreeComputed;
                return true;
            }

            // create the necessary number of sets of missing facts
            notFoundFactSet = factRuleTrees.ConvertAll(item => new List<IFactType>());
            List<FactRuleNode> allCompletedNodes = new List<FactRuleNode>();

            while (true)
            {
                for (int i = factRuleTrees.Count - 1; i >= 0; i--)
                {
                    FactRuleTree factRuleTree = factRuleTrees[i];

                    if (factRuleTree == null)
                        continue;

                    int lastlevelNumber = factRuleTree.Levels.Count - 1;

                    if (SyncComputedNodeForLevelTreeAndCheckGoneRoot(factRuleTree, lastlevelNumber, allCompletedNodes))
                    {
                        treeResult = factRuleTree;
                        return true;
                    }

                    List<FactRuleNode> lastLevel = factRuleTree.Levels[lastlevelNumber];

                    if (lastLevel.Count == 0)
                    {
                        treeResult = factRuleTree;
                        return true;
                    }

                    List<FactRuleNode> nextNodes = new List<FactRuleNode>();
                    List<FactRuleNode> currentLevelCompletedNodes = new List<FactRuleNode>();
                    bool cannotDerived = false;

                    for (int j = 0; j < lastLevel.Count; j++)
                    {
                        FactRuleNode node = lastLevel[j];

                        List<IFactType> needFacts = node.FactRule.InputFactTypes
                            .Where(fact => !fact.ContainsContainer(container) && excludeFacts.All(exF => !exF.Compare(fact)))
                            .ToList();

                        // Exclude NotContained facts
                        foreach (var notContainedFactInfo in needFacts.Where(fact => fact.IsFactType<INotContainedFact>()).ToList())
                        {
                            INotContainedFact notContainedFact = notContainedFactInfo.GetNotContainedInstance();

                            if (container.All(fact => !notContainedFact.IsFactContained(container))) 
                                needFacts.Remove(notContainedFactInfo);
                        }

                        // Exclude No facts
                        foreach (var noFactInfo in needFacts.Where(fact => fact.IsFactType<INoFact>()).ToList())
                        {
                            if (!TryDeriveNoFactInfo(noFactInfo, container, ruleCollection, excludeFacts))
                                needFacts.Remove(noFactInfo);
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
                            if (needFact.IsFactType<INoFact>() || needFact.IsFactType<INotContainedFact>())
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
                                var nodes = needRules.Select(rule => new FactRuleNode
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
        private List<FactRuleTree> GetFactRuleTrees(IFactType wantFact, IReadOnlyCollection<TFactRule> rules)
        {
            if (rules.IsNullOrEmpty())
                throw FactFactoryHelper.CreateDeriveException(ErrorCode.EmptyRuleCollection, "Rules cannot be null");

            List<FactRuleTree> factRuleTrees = rules?.Where(rule => rule.OutputFactType.Compare(wantFact))
                    .Select(rule =>
                    {
                        var tree = new FactRuleTree
                        {
                            Root = new FactRuleNode { FactRule = rule }
                        };
                        tree.Levels.Add(new List<FactRuleNode> { tree.Root });
                        return tree;
                    })
                    .ToList();

            if (factRuleTrees.IsNullOrEmpty())
                throw FactFactoryHelper.CreateDeriveException(ErrorCode.RuleNotFound, $"There is no rule that can deduce a {wantFact.FactName}");

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
        private bool SyncComputedNodeForLevelTreeAndCheckGoneRoot(FactRuleTree factRuleTree, int level, List<FactRuleNode> computedNodes)
        {
            if (level < 0)
                return true;

            List<FactRuleNode> currentLevel = factRuleTree.Levels[level];
            List<FactRuleNode> computedNodesInCurrentLevel = new List<FactRuleNode>();

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

        private void SyncComputedNodes(List<FactRuleNode> levelNodes, List<FactRuleNode> computedNodes)
        {
            // value - parents, key - node matching on child
            Dictionary<FactRuleNode, List<FactRuleNode>> keyValuePairs = new Dictionary<FactRuleNode, List<FactRuleNode>>();
            foreach (var computedNode in computedNodes.Distinct())
            {
                List<FactRuleNode> parentNodes = levelNodes
                    .Where(n => n.FactRule.OutputFactType.Compare(computedNode.FactRule.OutputFactType))
                    .Select(n => n.Parent).ToList();
                keyValuePairs.Add(computedNode, parentNodes);
            }

            foreach (KeyValuePair<FactRuleNode, List<FactRuleNode>> keyValuePair in keyValuePairs)
            {
                foreach (FactRuleNode parentNode in keyValuePair.Value)
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

        private bool RemoveRuleNodeAndCheckGoneRoot(FactRuleTree factRuleTree, int level, FactRuleNode removeNode)
        {

            if (level == 0)
            {
                factRuleTree.Levels[level].Remove(removeNode);
                return true;
            }

            factRuleTree.Levels[level].Remove(removeNode);
            FactRuleNode parent = removeNode.Parent;
            parent.Childs.Remove(removeNode);

            // If the node has a child node that can calculate this fact
            if (parent.Childs.Any(node => node.FactRule.OutputFactType.Compare(removeNode.FactRule.OutputFactType)))
                return false;
            else
                return RemoveRuleNodeAndCheckGoneRoot(factRuleTree, level - 1, parent);
        }

        private void DeriveNode(FactRuleNode node, TFactContainer container)
        {
            foreach (FactRuleNode child in node.Childs)
                DeriveNode(child, container);

            CalculateFact((TFactRule)node.FactRule, container);
        }

        private bool TryDeriveNoFactInfo(IFactType wantFact, TFactContainer container, IReadOnlyCollection<TFactRule> ruleCollection, IReadOnlyCollection<IFactType> excludeFacts)
        {
            try
            {
                return TryDeriveTreeForFactInfo(out FactRuleTree _, wantFact.GetNoInstance().Value, container, ruleCollection, excludeFacts, out List<List<IFactType>> _);
            }
            catch (InvalidDeriveOperationException ex)
            {
                if (ex.Details != null && ex.Details.Count == 1 && ex.Details[0].Code == ErrorCode.RuleNotFound)
                    return false;

                throw;
            }
        }

        #endregion
    }

    /// <summary>
    /// Base class for fact factory
    /// </summary>
    public abstract class FactFactoryBase<TFactContainer, TFactRule, TFactRuleCollection> : FactFactoryBase<TFactContainer, TFactRule, TFactRuleCollection, WantAction>
        where TFactContainer : class, IFactContainer
        where TFactRule : class, IFactRule
        where TFactRuleCollection : class, IList<TFactRule>
    {
        /// <summary>
        /// Derive <typeparamref name="TFact"/>
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        public override TFact DeriveFact<TFact>()
        {
            TFact fact = default;

            var wantActions = new List<WantAction>(WantActions);
            WantActions.Clear();

            WantFact((TFact factInner) => fact = factInner);
            Derive();

            WantActions.AddRange(wantActions);

            return fact;
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="wantFactAction"></param>
        public virtual void WantFact<TFact>(
            Action<TFact> wantFactAction) where TFact : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact>()),
                new List<IFactType> { new FactInfo<TFact>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1"></typeparam>
        /// <typeparam name="TFact2"></typeparam>
        /// <param name="wantFactAction">Desired action</param>
        public virtual void WantFact<TFact1, TFact2>(
            Action<TFact1, TFact2> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>() }));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>() }));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>() }));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>(), new FactInfo<TFact5>() }));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>(), new FactInfo<TFact5>(), new FactInfo<TFact6>() }));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>(), new FactInfo<TFact5>(), new FactInfo<TFact6>(), new FactInfo<TFact7>() }));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>(), new FactInfo<TFact5>(), new FactInfo<TFact6>(), new FactInfo<TFact7>(), new FactInfo<TFact8>() }));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>(), new FactInfo<TFact5>(), new FactInfo<TFact6>(), new FactInfo<TFact7>(), new FactInfo<TFact8>(), new FactInfo<TFact9>() }));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>(), new FactInfo<TFact5>(), new FactInfo<TFact6>(), new FactInfo<TFact7>(), new FactInfo<TFact8>(), new FactInfo<TFact9>(), new FactInfo<TFact10>()}));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
            where TFact11 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>(), container.GetFact<TFact11>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>(), new FactInfo<TFact5>(), new FactInfo<TFact6>(), new FactInfo<TFact7>(), new FactInfo<TFact8>(), new FactInfo<TFact9>(), new FactInfo<TFact10>(), new FactInfo<TFact11>() }));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
            where TFact11 : IFact
            where TFact12 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>(), container.GetFact<TFact11>(), container.GetFact<TFact12>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>(), new FactInfo<TFact5>(), new FactInfo<TFact6>(), new FactInfo<TFact7>(), new FactInfo<TFact8>(), new FactInfo<TFact9>(), new FactInfo<TFact10>(), new FactInfo<TFact11>(), new FactInfo<TFact12>()}));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
            where TFact11 : IFact
            where TFact12 : IFact
            where TFact13 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>(), container.GetFact<TFact11>(), container.GetFact<TFact12>(), container.GetFact<TFact13>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>(), new FactInfo<TFact5>(), new FactInfo<TFact6>(), new FactInfo<TFact7>(), new FactInfo<TFact8>(), new FactInfo<TFact9>(), new FactInfo<TFact10>(), new FactInfo<TFact11>(), new FactInfo<TFact12>(), new FactInfo<TFact13>()}));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
            where TFact11 : IFact
            where TFact12 : IFact
            where TFact13 : IFact
            where TFact14 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>(), container.GetFact<TFact11>(), container.GetFact<TFact12>(), container.GetFact<TFact13>(), container.GetFact<TFact14>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>(), new FactInfo<TFact5>(), new FactInfo<TFact6>(), new FactInfo<TFact7>(), new FactInfo<TFact8>(), new FactInfo<TFact9>(), new FactInfo<TFact10>(), new FactInfo<TFact11>(), new FactInfo<TFact12>(), new FactInfo<TFact13>(), new FactInfo<TFact14>()}));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
            where TFact11 : IFact
            where TFact12 : IFact
            where TFact13 : IFact
            where TFact14 : IFact
            where TFact15 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>(), container.GetFact<TFact11>(), container.GetFact<TFact12>(), container.GetFact<TFact13>(), container.GetFact<TFact14>(), container.GetFact<TFact15>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>(), new FactInfo<TFact5>(), new FactInfo<TFact6>(), new FactInfo<TFact7>(), new FactInfo<TFact8>(), new FactInfo<TFact9>(), new FactInfo<TFact10>(), new FactInfo<TFact11>(), new FactInfo<TFact12>(), new FactInfo<TFact13>(), new FactInfo<TFact14>(), new FactInfo<TFact15>() }));
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
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
            where TFact11 : IFact
            where TFact12 : IFact
            where TFact13 : IFact
            where TFact14 : IFact
            where TFact15 : IFact
            where TFact16 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>(), container.GetFact<TFact4>(), container.GetFact<TFact5>(), container.GetFact<TFact6>(), container.GetFact<TFact7>(), container.GetFact<TFact8>(), container.GetFact<TFact9>(), container.GetFact<TFact10>(), container.GetFact<TFact11>(), container.GetFact<TFact12>(), container.GetFact<TFact13>(), container.GetFact<TFact14>(), container.GetFact<TFact15>(), container.GetFact<TFact16>()),
                new List<IFactType> { new FactInfo<TFact1>(), new FactInfo<TFact2>(), new FactInfo<TFact3>(), new FactInfo<TFact4>(), new FactInfo<TFact5>(), new FactInfo<TFact6>(), new FactInfo<TFact7>(), new FactInfo<TFact8>(), new FactInfo<TFact9>(), new FactInfo<TFact10>(), new FactInfo<TFact11>(), new FactInfo<TFact12>(), new FactInfo<TFact13>(), new FactInfo<TFact14>(), new FactInfo<TFact15>(), new FactInfo<TFact16>() }));
        }
    }
}
