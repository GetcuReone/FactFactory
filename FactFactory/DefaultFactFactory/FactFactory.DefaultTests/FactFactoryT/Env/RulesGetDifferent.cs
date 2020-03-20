using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using Rules = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal class RulesGetDifferent : Rules
    {
        public override FactRuleCollectionBase<FactBase, Rule> Copy()
        {
            return new DifferenRules();
        }

        private class DifferenRules : FactRuleCollectionBase<FactBase, Rule>
        {
            public override FactRuleCollectionBase<FactBase, Rule> Copy()
            {
                throw new System.NotImplementedException();
            }

            protected override Rule CreateFactRule(Func<IFactContainer<FactBase>, IWantAction<FactBase>, FactBase> func, List<IFactType> inputFactTypes, IFactType outputFactType)
            {
                throw new NotImplementedException();
            }

            protected override IFactType GetFactType<TGetFact>()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
