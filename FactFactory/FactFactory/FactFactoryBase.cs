using FactFactory.Entities;
using FactFactory.Facts;
using FactFactory.Helpers;
using FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FactFactory
{
    /// <summary>
    /// Base class for fact factory
    /// </summary>
    public abstract class FactFactoryBase : IFactFactory<FactRule>
    {
        private readonly List<IFactInfo> _wantFacts = new List<IFactInfo>();
        private readonly List<Action<FactContainer>> _wantActions = new List<Action<FactContainer>>();

        /// <summary>
        /// Fact container
        /// </summary>
        public virtual IFactContainer FactContainer { get; } = new FactContainer();

        /// <summary>
        /// Collection of rules for derive facts
        /// </summary>
        public virtual IList<FactRule> FactRuleCollection => throw new NotImplementedException();

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
        public virtual void WantFact<TFact>(Action<TFact> wantFactAction) where TFact : IFact
        {
            IFactInfo factInfo = new FactInfo<TFact>();

            if (_wantFacts.All(f => !f.Compare(factInfo)))
                _wantFacts.Add(factInfo);

            _wantActions.Add(container => wantFactAction(container.GetFact<TFact>()));
        }

        /// <inheritdoc />
        public virtual void Derive()
        {
            foreach (IFactInfo wantFactInfo in _wantFacts)
            {
                var container = new FactContainer(FactContainer)
                {
                    new DateOfDeriveFact(DateTime.Now),
                };

                // find the rules that can calculate the fact
                List<FactRuleTree> factRuleTrees = FactRuleCollection?.Where(rule => rule.OutputFactInfo.Compare(wantFactInfo))
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

                        foreach (FactRuleNode node in factRuleTree.CurrentLevel)
                        {
                            List<IFactInfo> needFacts = node.FactRule.InputFactInfos.Where(fact => !fact.ContainsContainer(container)).ToList();

                            if (needFacts.IsNullOrEmpty())
                                continue;

                            foreach (var needFact in needFacts)
                            {
                                var needRules = FactRuleCollection
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
                                    notFoundRuleForFacts.Add(needFact);
                            }
                        }

                        if (!notFoundRuleForFacts.IsNullOrEmpty())
                        {
                            notFoundRuleForFactsSet.Add(notFoundRuleForFacts);
                            factRuleTrees.Remove(factRuleTree);
                        }
                        else if (nextNodes.IsNullOrEmpty())
                        {
                            factRuleTree.Root.Derive(this, container);
                            isDerive = true;
                            break;
                        }
                        else
                        {
                            factRuleTree.CurrentLevel.Clear();
                            factRuleTree.CurrentLevel.AddRange(nextNodes);
                        }
                    }
                }


            }
        }
    }
}
