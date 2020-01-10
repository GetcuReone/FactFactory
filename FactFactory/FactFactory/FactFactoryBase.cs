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
        public virtual IEnumerable<IFactInfo> GetFactInfosAvailableOnlyRules()
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

        /// <summary>
        /// Return a list with the appropriate rules at the time of the derive of the facts
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TFactRule> GetRulesForDerive(TWantAction wantAction)
        {
            return new List<TFactRule>(Rules);
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

        private void SyncCompletedNode(List<FactRuleNode> levelNodes, FactRuleNode comletedNode)
        {
            var parentNodes = levelNodes
                .Where(n => n.FactRule.OutputFactInfo.Compare(comletedNode.FactRule.OutputFactInfo))
                .Select(n => n.Parent).ToList();

            foreach (FactRuleNode parentNode in parentNodes)
            {
                foreach (var removeNode in parentNode.Childs.Where(n => n.FactRule.OutputFactInfo.Compare(comletedNode.FactRule.OutputFactInfo)))
                {
                    if (removeNode.FactRule != comletedNode.FactRule)
                        parentNode.Childs.Remove(parentNode);
                    levelNodes.Remove(removeNode);
                }
            }
        }

        /// <inheritdoc />
        public virtual void Derive()
        {
            var container = new FactContainer(Container) 
            { 
                new DateOfDeriveFact(DateTime.Now),
                new DerivingCurrentFactsFact(
                    new ReadOnlyCollection<IFactInfo>(
                        _wantActions.SelectMany(action => action.InputFacts).ToList()))
            };

            var derivedTrees = new Dictionary<TWantAction, List<FactRuleTree>>();
            var excludeFacts = GetFactInfosAvailableOnlyRules();

            foreach (var wantAction in _wantActions)
                derivedTrees.Add(wantAction, DeriveTreesForWantAction(wantAction, container, excludeFacts));

            foreach(KeyValuePair<TWantAction, List<FactRuleTree>> derivedTree in derivedTrees)
            {
                container.Add(new DateOfDeriveCurrentFact(derivedTree.Key.DateOfDerive));
                container.Add(new CurrentFactsFindingFact(derivedTree.Key.InputFacts.ToList()));

                foreach(var tree in derivedTree.Value)
                    tree.Root.Derive(this, container);

                derivedTree.Key.Invoke(container);

                container.Remove<CurrentFactsFindingFact>();
                container.Remove<DateOfDeriveCurrentFact>();
            }
        }

        private List<FactRuleTree> DeriveTreesForWantAction(TWantAction wantAction, FactContainer container, IEnumerable<IFactInfo> excludeFacts)
        {
            IEnumerable<TFactRule> ruleCollection = GetRulesForDerive(wantAction);
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
                        List<FactRuleNode> lastLevel = factRuleTree.Levels[factRuleTree.Levels.Count - 1];

                        if (lastLevel.Count == 0)
                        {
                            computedTrees.Add(factRuleTree);
                            isDerive = true;
                            break;
                        }

                        List<FactRuleNode> nextNodes = new List<FactRuleNode>();
                        // A set of facts for which no rules were found
                        List<IFactInfo> notFoundRuleForFacts = new List<IFactInfo>();
                        bool cannotDerived = false;

                        for (int j = lastLevel.Count - 1; j >= 0; j--)
                        {
                            FactRuleNode node = lastLevel[j];


                            List<IFactInfo> needFacts = node.FactRule.InputFactInfos
                                .Where(fact => !fact.ContainsContainer(container) && excludeFacts.All(exF => !exF.Compare(fact)))
                                .ToList();

                            // If the rule can be calculated from the parameters in the container, then add the node to the list of complete
                            if (needFacts.IsNullOrEmpty())
                            {
                                lastLevel.RemoveAll(n => n.FactRule.OutputFactInfo.Compare(node.FactRule.OutputFactInfo));
                                allCompletedNodes.Add(node);

                                foreach (var tree in factRuleTrees)
                                    SyncCompletedNode(tree.Levels[tree.Levels.Count - 1], node);

                                SyncCompletedNode(nextNodes, node);
                                j = lastLevel.Count;
                                continue;
                            }

                            var completedNodesForFact = allCompletedNodes.Where(n => needFacts.Any(f => f.Compare(n.FactRule.OutputFactInfo)));
                            if (completedNodesForFact.IsNullOrEmpty())
                            {
                                foreach (var completedNodeForFact in completedNodesForFact)
                                    node.Childs.Add(completedNodeForFact);

                                var foundFacts = completedNodesForFact.Select(n => n.FactRule.OutputFactInfo).ToList();
                                needFacts.RemoveAll(foundFacts.Contains);

                                if (needFacts.Count == 0)
                                    continue;
                            }

                            foreach (var needFact in needFacts)
                            {

                                var needRules = ruleCollection
                                    .Where(rule => rule.OutputFactInfo.Compare(needFact))
                                    .Where(rule => !node.ExistsBranch(rule))
                                    .ToList();

                                if (!needRules.IsNullOrEmpty())
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
                                    if (node.Parent != null
                                        && node.Parent.Childs.Count(n => (n != node) && (n.FactRule.OutputFactInfo.Compare(node.FactRule.OutputFactInfo))) > 0)
                                    {
                                        node.Parent.Childs.Remove(node);
                                    }
                                    else
                                        cannotDerived = true;

                                    notFoundRuleForFacts.Add(needFact);
                                }
                            }
                        }

                        if (cannotDerived)
                        {
                            notFoundRuleForFactsSet.Add(notFoundRuleForFacts);
                            factRuleTrees.Remove(factRuleTree);
                        }
                        else if (nextNodes.IsNullOrEmpty())
                        {
                            computedTrees.Add(factRuleTree);
                            isDerive = true;
                            break;
                        }
                        else
                            factRuleTree.Levels.Add(nextNodes);
                    }

                    if (factRuleTrees.IsNullOrEmpty())
                        throw new InvalidDeriveOperationException($"To derive a {wantFact.FactName}, a set of facts is not enough", notFoundRuleForFactsSet);
                }
            }

            return computedTrees;
        }

        /// <inheritdoc />
        public abstract TFact DeriveAndReturn<TFact>() where TFact : IFact;

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
