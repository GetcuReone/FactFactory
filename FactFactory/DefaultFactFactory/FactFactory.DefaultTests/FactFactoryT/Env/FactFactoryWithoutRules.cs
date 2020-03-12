using GetcuReone.FactFactory.Default;
using GetcuReone.FactFactory.Entities;
using System.Collections.Generic;
using WAction = GetcuReone.FactFactory.Default.Entities.WantAction;
using Rule = GetcuReone.FactFactory.Default.Entities.FactRule;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryWithoutRules : GetcuReone.FactFactory.Default.FactFactory
    {
        protected override IList<Rule> GetRulesForWantAction(WAction wantAction, FactContainerBase<FactBase> container, FactRuleCollectionBase<FactBase, Rule> rules)
        {
            return default;
        }
    }
}
