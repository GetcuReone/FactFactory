using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory;
using System.Collections.Generic;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryWithoutRules : GetcuReone.FactFactory.FactFactory
    {
        protected override IList<Rule> GetRulesForWantAction(WAction wantAction, FactContainerBase<FactBase> container, FactRuleCollectionBase<FactBase, Rule> rules)
        {
            return default;
        }
    }
}
