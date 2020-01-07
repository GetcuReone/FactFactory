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
    public abstract class FactFactoryBase : IFactFactory<FactRule, FactRuleCollection>
    {
        private readonly List<IFactInfo> _wantFacts = new List<IFactInfo>();
        private readonly List<Action<FactContainer>> _wantActions = new List<Action<FactContainer>>();


        /// <summary>
        /// Fact container
        /// </summary>
        public virtual IFactContainer Container { get; } = new FactContainer();

        /// <summary>
        /// Collection of rules for derive facts
        /// </summary>
        public FactRuleCollection Rules => _rules ?? (_rules = GetDefaultRules());
        private FactRuleCollection _rules;

        private void WantFact(List<IFactInfo> wantFacts, Action<IFactContainer> wantAction)
        {
            var canNotUse = GetFactInfosAvailableOnlyRules();

            foreach (var wantFact in wantFacts)
            {
                if (canNotUse.Any(f => f.Compare(wantFact)))
                    throw new ArgumentException($"You cannot request a {wantFact.FactName}. Only available for request in the rules");
                else if (_wantFacts.All(f => !f.Compare(wantFact)))
                    _wantFacts.Add(wantFact);
            }

            _wantActions.Add(wantAction);
        }

        /// <summary>
        /// Get facts available only in rules
        /// </summary>
        public virtual List<IFactInfo> GetFactInfosAvailableOnlyRules()
        {
            return new List<IFactInfo>()
            {
                new FactInfo<CurrentFactInfoFindingFact>(),
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
            var successedTrees = new List<FactRuleTree>();
            var container = new FactContainer(Container) 
            { 
                new DateOfDeriveFact(DateTime.Now),
                new DerivingCurrentFactsFact(new ReadOnlyCollection<IFactInfo>(_wantFacts))
            };

            var excludeFacts = GetFactInfosAvailableOnlyRules();

            foreach (IFactInfo wantFactInfo in _wantFacts)
            {
                // If fact already exists
                if (wantFactInfo.ContainsContainer(container))
                    continue;

                // find the rules that can calculate the fact
                List<FactRuleTree> factRuleTrees = Rules?.Where(rule => rule.OutputFactInfo.Compare(wantFactInfo))
                    .Select(rule => 
                    {
                        var node = new FactRuleNode { FactRule = rule };
                        var tree = new FactRuleTree { Root = node };
                        tree.CurrentLevel.Add(node);
                        return tree;
                    })
                    .ToList();

                if (factRuleTrees.IsNullOrEmpty())
                    throw new InvalidOperationException($"There is no rule that can deduce a {wantFactInfo.FactName}");

                // Check if we can already derive the fact
                IFactRule ruleDerive = factRuleTrees.FirstOrDefault(tree => tree.Root.FactRule.CanDerive(container))?.Root.FactRule;
                if (ruleDerive != null)
                {
                    container.Add(
                        CreateObject(ct => ruleDerive.Derive(ct), container));
                    break;
                }

                bool isDerive = false;
                // A set of fact sets for which no rules were found
                List<List<IFactInfo>> notFoundRuleForFactsSet = new List<List<IFactInfo>>();
                while (!isDerive)
                {
                    for(int i = factRuleTrees.Count - 1; i >= 0; i--)
                    {
                        FactRuleTree factRuleTree = factRuleTrees[i];
                        List<FactRuleNode> nextNodes = new List<FactRuleNode>();
                        // A set of facts for which no rules were found
                        List<IFactInfo> notFoundRuleForFacts = new List<IFactInfo>();
                        bool cannotDerived = false;

                        foreach (FactRuleNode node in factRuleTree.CurrentLevel)
                        {
                            List<IFactInfo> needFacts = node.FactRule.InputFactInfos
                                .Where(fact => !fact.ContainsContainer(container) && excludeFacts.All(exF => !exF.Compare(fact)))
                                .ToList();

                            if (needFacts.IsNullOrEmpty())
                                continue;

                            foreach (var needFact in needFacts)
                            {
                                var needRules = Rules
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
                            successedTrees.Add(factRuleTree);
                            isDerive = true;
                            break;
                        }
                        else
                        {
                            factRuleTree.CurrentLevel.Clear();
                            factRuleTree.CurrentLevel.AddRange(nextNodes);
                        }
                    }

                    if (factRuleTrees.IsNullOrEmpty())
                        throw new InvalidDeriveOperationException($"To derive a {wantFactInfo.FactName}, a set of facts is not enough", notFoundRuleForFactsSet);
                }
            }

            foreach (var tree in successedTrees)
            {
                container.Add(new CurrentFactInfoFindingFact(tree.Root.FactRule.OutputFactInfo));

                tree.Root.Derive(this, container);

                container.Remove<CurrentFactInfoFindingFact>();
            }

            foreach (var wantAction in _wantActions)
                wantAction(container);
        }

        /// <inheritdoc />
        public virtual TFact DeriveAndReturn<TFact>() where TFact : IFact
        {
            TFact fact = default;

            WantFact((TFact factInner) => fact = factInner);
            Derive();

            return fact;
        }

        /// <summary>
        /// Get default rules
        /// </summary>
        /// <returns>rules</returns>
        public virtual FactRuleCollection GetDefaultRules()
        {
            return new FactRuleCollection
            {

            };
        }

        /// <inheritdoc />
        public virtual void WantFact<TFact>(Action<TFact> wantFactAction) where TFact : IFact
        {
            WantFact(new List<IFactInfo> { new FactInfo<TFact>() }, container => wantFactAction(container.GetFact<TFact>()));
        }

        /// <inheritdoc />
        public void WantFact<TFact1, TFact2>(Action<TFact1, TFact2> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
        {
            WantFact(new List<IFactInfo> { new FactInfo<TFact1>(), new FactInfo<TFact2>() },
                container => wantFactAction(container.GetFact<TFact1>(), container.GetFact<TFact2>()));
        }
    }
}
