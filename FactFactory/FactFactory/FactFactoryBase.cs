using FactFactory.Entities;
using FactFactory.Exceptions;
using FactFactory.Facts;
using FactFactory.Helpers;
using FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FactFactory
{
    /// <summary>
    /// Base class for fact factory
    /// </summary>
    public abstract class FactFactoryBase<TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : IFactFactory<TFactContainer, TFactRule, TFactRuleCollection, TWantAction>
        where TFactContainer : IFactContainer
        where TFactRule : IFactRule
        where TFactRuleCollection : IList<TFactRule>
        where TWantAction : IWantAction
    {
        private readonly List<TWantAction> _wantActions = new List<TWantAction>();


        /// <summary>
        /// Fact container
        /// </summary>
        public abstract TFactContainer Container { get; }

        /// <summary>
        /// Collection of rules for derive facts
        /// </summary>
        public abstract TFactRuleCollection Rules { get; }

        /// <summary>
        /// Get facts available only in rules
        /// </summary>
        protected virtual IEnumerable<IFactInfo> GetFactInfosAvailableOnlyRules()
        {
            return new List<IFactInfo>()
            {
                new FactInfo<CurrentFactsFindingFact>(),
                new FactInfo<DateOfDeriveCurrentFact>(),
            };
        }

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

        /// <inheritdoc />
        public virtual void Derive()
        {
            TFactContainer container = GetCopyFactContainer();

            if (container.Equals(Container))
                throw new InvalidOperationException("method GetCopyFactContainer return original object");

            container.Add(new DateOfDeriveFact(DateTime.Now));
            container.Add(new DerivingCurrentFactsFact(
                new ReadOnlyCollection<IFactInfo>(
                    _wantActions.SelectMany(action => action.InputFacts).ToList())));

            var derivedTrees = new Dictionary<TWantAction, List<FactRuleTree>>();
            var excludeFacts = GetFactInfosAvailableOnlyRules();

            foreach (var wantAction in _wantActions)
                derivedTrees.Add(wantAction, DeriveTreesForWantAction(wantAction, container, excludeFacts));

            foreach(KeyValuePair<TWantAction, List<FactRuleTree>> derivedTree in derivedTrees)
            {
                container.Add(new DateOfDeriveCurrentFact(derivedTree.Key.DateOfDerive));
                container.Add(new CurrentFactsFindingFact(derivedTree.Key.InputFacts.ToList()));

                foreach(var tree in derivedTree.Value)
                    DeriveNode(tree.Root, container);

                derivedTree.Key.Invoke(container);

                container.Remove<CurrentFactsFindingFact>();
                container.Remove<DateOfDeriveCurrentFact>();
            }
        }

        /// <inheritdoc />
        public virtual void WantFact(TWantAction wantAction)
        {
            if (_wantActions.IndexOf(wantAction) != -1)
                throw new ArgumentException("Action already requested");

            var excludeFacts = GetFactInfosAvailableOnlyRules();

            var excludeFact = wantAction.InputFacts.FirstOrDefault(f => excludeFacts.Any(ef => ef.Compare(f)));
            if (excludeFact != null)
                throw new ArgumentException($"The {excludeFact.FactName} is available only for the rules.");

            _wantActions.Add(wantAction);
        }

        #region methods for derive

        /// <summary>
        /// Derive a fact from the rules and return it
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        public abstract TFact DeriveAndReturn<TFact>() where TFact : IFact;

        /// <summary>
        /// Return a list with the appropriate rules at the time of the derive of the facts
        /// </summary>
        /// <returns></returns>
        protected virtual IReadOnlyCollection<TFactRule> GetRulesForDerive(TWantAction wantAction)
        {
            return new ReadOnlyCollection<TFactRule>(Rules);
        }

        /// <summary>
        /// Get copy fact container
        /// </summary>
        /// <returns></returns>
        protected abstract TFactContainer GetCopyFactContainer();

        /// <summary>
        /// Derive fact
        /// </summary>
        /// <param name="rule">rule for calculating the fact</param>
        /// <param name="container">fact container</param>
        protected virtual void DeriveFact(TFactRule rule, TFactContainer container)
        {
            if (!rule.OutputFactInfo.ContainsContainer(container))
                container.Add(CreateObject(ct => rule.Derive(container), container));
        }

        private List<FactRuleTree> DeriveTreesForWantAction(TWantAction wantAction, TFactContainer container, IEnumerable<IFactInfo> excludeFacts)
        {
            IReadOnlyCollection<TFactRule> ruleCollection = GetRulesForDerive(wantAction);
            wantAction.DateOfDerive = DateTime.Now;
            var computedTrees = new List<FactRuleTree>();

            foreach (IFactInfo wantFact in wantAction.InputFacts)
            {
                // If fact already exists
                if (wantFact.ContainsContainer(container))
                    continue;

                // find the rules that can calculate the fact
                List<FactRuleTree> factRuleTrees = GetFactRuleTrees(wantFact, ruleCollection);

                // Check if we can already derive the fact
                FactRuleTree factRuleTreeComputed = factRuleTrees.FirstOrDefault(tree => tree.Root.FactRule.CanDerive(container));
                if (factRuleTreeComputed != null)
                {
                    computedTrees.Add(factRuleTreeComputed);
                    continue;
                }

                bool isDerive = false;
                // A set of fact sets for which no rules were found
                List<List<IFactInfo>> notFoundRuleForFactsSet = new List<List<IFactInfo>>();
                List<FactRuleNode> allCompletedNodes = new List<FactRuleNode>();

                while (!isDerive)
                {
                    for (int i = factRuleTrees.Count - 1; i >= 0; i--)
                    {
                        FactRuleTree factRuleTree = factRuleTrees[i];
                        int lastlevelNumber = factRuleTree.Levels.Count - 1;

                        if (SyncComputedNodeForLevelTreeAndCheckGoneRoot(factRuleTree, lastlevelNumber, allCompletedNodes))
                        {
                            computedTrees.Add(factRuleTree);
                            isDerive = true;
                            break;
                        }

                        List<FactRuleNode> lastLevel = factRuleTree.Levels[lastlevelNumber];

                        if (lastLevel.Count == 0)
                        {
                            computedTrees.Add(factRuleTree);
                            isDerive = true;
                            break;
                        }

                        List<FactRuleNode> nextNodes = new List<FactRuleNode>();
                        // A set of facts for which no rules were found
                        List<IFactInfo> notFoundRuleForFacts = new List<IFactInfo>();
                        List<FactRuleNode> currentLevelCompletedNodes = new List<FactRuleNode>();
                        bool cannotDerived = false;

                        for (int j = 0; j < lastLevel.Count; j++)
                        {
                            FactRuleNode node = lastLevel[j];

                            List<IFactInfo> needFacts = node.FactRule.InputFactInfos
                                .Where(fact => !fact.ContainsContainer(container) && excludeFacts.All(exF => !exF.Compare(fact)))
                                .ToList();

                            foreach (var notContainedFactInfo in needFacts.Where(fact => fact.IsFactType<INotContainedFact>()).ToList())
                            {
                                INotContainedFact notContainedFact = notContainedFactInfo.GetNotContainedFact();

                                if (container.All(fact => !notContainedFact.IsFactContained(container)))
                                {
                                    container.Add(notContainedFact);
                                    needFacts.Remove(notContainedFactInfo);
                                }

                            }

                            // If the rule can be calculated from the parameters in the container, then add the node to the list of complete
                            if (needFacts.IsNullOrEmpty())
                            {
                                allCompletedNodes.Add(node);
                                currentLevelCompletedNodes.Add(node);

                                continue;
                            }

                            var completedNodesForFact = allCompletedNodes
                                .Where(n => needFacts.Any(f => f.Compare(n.FactRule.OutputFactInfo)))
                                .ToList();

                            if (completedNodesForFact.Count > 0)
                            {
                                foreach (var completedNodeForFact in completedNodesForFact)
                                    node.Childs.Add(completedNodeForFact);

                                var foundFacts = completedNodesForFact.Select(n => n.FactRule.OutputFactInfo).ToList();
                                needFacts.RemoveAll(f => foundFacts.Any(ff => ff.Compare(f)));

                                if (needFacts.Count == 0)
                                    continue;
                            }

                            foreach (var needFact in needFacts)
                            {

                                var needRules = ruleCollection
                                    .Where(rule => rule.OutputFactInfo.Compare(needFact))
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

                                    notFoundRuleForFacts.Add(needFact);
                                }
                            }
                        }

                        if (cannotDerived)
                        {
                            notFoundRuleForFactsSet.Add(notFoundRuleForFacts);
                            factRuleTrees.Remove(factRuleTree);
                        }
                        else if (currentLevelCompletedNodes.Count > 0)
                        {
                            if (SyncComputedNodeForLevelTreeAndCheckGoneRoot(factRuleTree, lastlevelNumber, currentLevelCompletedNodes))
                            {
                                computedTrees.Add(factRuleTree);
                                isDerive = true;
                                break;
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
                            computedTrees.Add(factRuleTree);
                            isDerive = true;
                            break;
                        }
                    }

                    if (factRuleTrees.IsNullOrEmpty())
                        throw new InvalidDeriveOperationException($"To derive a {wantFact.FactName}, a set of facts is not enough", notFoundRuleForFactsSet);
                }
            }

            return computedTrees;
        }

        /// <summary>
        /// Returns trees. Their number is equal to the number of rules that can derive the necessary <paramref name="wantFact"/>.
        /// </summary>
        /// <param name="wantFact">derive fact</param>
        /// <param name="rules">rule set</param>
        /// <returns></returns>
        private List<FactRuleTree> GetFactRuleTrees(IFactInfo wantFact, IEnumerable<TFactRule> rules)
        {
            if (rules == null)
                throw new InvalidOperationException("Rules cannot be null");

            List<FactRuleTree> factRuleTrees = rules?.Where(rule => rule.OutputFactInfo.Compare(wantFact))
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
                throw new InvalidOperationException($"There is no rule that can deduce a {wantFact.FactName}");

            return factRuleTrees;
        }

        private void SyncComputedNodes(List<FactRuleNode> levelNodes, List<FactRuleNode> computedNodes)
        {
            // value - parents, key - node matching on child
            Dictionary<FactRuleNode, List<FactRuleNode>> keyValuePairs = new Dictionary<FactRuleNode, List<FactRuleNode>>();
            foreach (var computedNode in computedNodes.Distinct())
            {
                List<FactRuleNode> parentNodes = levelNodes
                    .Where(n => n.FactRule.OutputFactInfo.Compare(computedNode.FactRule.OutputFactInfo))
                    .Select(n => n.Parent).ToList();
                keyValuePairs.Add(computedNode, parentNodes);
            }

            foreach (KeyValuePair<FactRuleNode, List<FactRuleNode>> keyValuePair in keyValuePairs)
            {
                foreach (FactRuleNode parentNode in keyValuePair.Value)
                {
                    if (parentNode == null)
                        continue;

                    foreach (var removeNode in parentNode.Childs.Where(n => n.FactRule.OutputFactInfo.Compare(keyValuePair.Key.FactRule.OutputFactInfo)).ToList())
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
            if (parent.Childs.Any(node => node.FactRule.OutputFactInfo.Compare(removeNode.FactRule.OutputFactInfo)))
                return false;
            else
                return RemoveRuleNodeAndCheckGoneRoot(factRuleTree, level - 1, parent);
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
                if (node.FactRule.InputFactInfos.Count > 0 && node.FactRule.InputFactInfos.All(f => computedNodes.Any(n => n.FactRule.OutputFactInfo.Compare(f))))
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

        private void DeriveNode(FactRuleNode node, TFactContainer container)
        {
            foreach (FactRuleNode child in node.Childs)
                DeriveNode(child, container);

            DeriveFact((TFactRule)node.FactRule, container);
        }

        #endregion
    }

    /// <summary>
    /// Base class for fact factory
    /// </summary>
    public abstract class FactFactoryBase<TFactContainer, TFactRule, TFactRuleCollection> : FactFactoryBase<TFactContainer, TFactRule, TFactRuleCollection, WantAction>
        where TFactContainer : IFactContainer
        where TFactRule : IFactRule
        where TFactRuleCollection : IList<TFactRule>
    {
        /// <inheritdoc />
        public override TFact DeriveAndReturn<TFact>()
        {
            TFact fact = default;

            WantFact((TFact factInner) => fact = factInner);
            Derive();

            return fact;
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="wantFactAction"></param>
        public virtual void WantFact<TFact>(Action<TFact> wantFactAction) where TFact : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact>()),
                new List<IFactInfo> { new FactInfo<TFact>() }));
        }

        /// <summary>
        /// Requesting desired facts through action
        /// </summary>
        /// <typeparam name="TFact1"></typeparam>
        /// <typeparam name="TFact2"></typeparam>
        /// <param name="wantFactAction"></param>
        public virtual void WantFact<TFact1, TFact2>(Action<TFact1, TFact2> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
        {
            WantFact(new WantAction(
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>()),
                new List<IFactInfo> { new FactInfo<TFact1>(), new FactInfo<TFact2>() }));
        }
    }

}
