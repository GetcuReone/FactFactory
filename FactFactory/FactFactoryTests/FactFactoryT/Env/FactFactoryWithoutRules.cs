using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryWithoutRules : GetcuReone.FactFactory.FactFactory
    {
        protected override IList<GetcuReone.FactFactory.Entities.FactRule> GetRulesForWantAction(WAction wantAction, IFactContainer<FactBase> container, FactRuleCollectionBase<FactBase, GetcuReone.FactFactory.Entities.FactRule> rules)
        {
            return default;
        }
    }
}
