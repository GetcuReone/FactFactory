using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Default;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;
using Action = GetcuReone.FactFactory.Default.Entities.WantAction;
using Rule = GetcuReone.FactFactory.Default.Entities.FactRule;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal class FactFactoryAddRule : GetcuReone.FactFactory.Default.FactFactory
    {
        internal Rule NewRule { get; } = new Rule(ct => default, new List<IFactType>(), new FactType<Input1Fact>());
        protected override IList<Rule> GetRulesForWantAction(Action wantAction, FactContainerBase<FactBase> container, FactRuleCollectionBase<FactBase, Rule> rules)
        {
            rules.Add(NewRule);
            return rules;
        }
    }
}
