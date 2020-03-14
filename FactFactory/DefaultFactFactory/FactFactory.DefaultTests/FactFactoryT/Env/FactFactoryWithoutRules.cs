using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Default;
using System.Collections.Generic;
using Rule = GetcuReone.FactFactory.Default.Entities.FactRule;
using WAction = GetcuReone.FactFactory.Default.Entities.WantAction;

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
