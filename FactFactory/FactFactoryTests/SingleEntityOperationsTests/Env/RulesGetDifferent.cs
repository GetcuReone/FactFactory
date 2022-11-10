using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using Rules = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.SingleEntityOperationsTests.Env
{
    internal class RulesGetDifferent : Rules
    {
        public override IFactRuleCollection Copy()
        {
            return new DifferenRules();
        }

        private class DifferenRules : BaseFactRuleCollection
        {
            public override IFactRuleCollection Copy()
            {
                throw new NotImplementedException();
            }

            protected override IFactRule CreateFactRule(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType, FactWorkOption option)
            {
                throw new NotImplementedException();
            }

            protected override IFactRule CreateFactRule(Func<IEnumerable<IFact>, ValueTask<IFact>> func, List<IFactType> inputFactTypes, IFactType outputFactType, FactWorkOption option)
            {
                throw new NotImplementedException();
            }

            protected override IFactRuleCollection Empty()
            {
                throw new NotImplementedException();
            }
        }
    }
}
