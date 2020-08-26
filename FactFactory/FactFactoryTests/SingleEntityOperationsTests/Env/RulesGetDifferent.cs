﻿using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using Rules = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.SingleEntityOperationsTests.Env
{
    internal class RulesGetDifferent : Rules
    {
        public override IFactRuleCollection<Rule> Copy()
        {
            return new DifferenRules();
        }

        private class DifferenRules : FactRuleCollectionBase<Rule>
        {
            public override IFactRuleCollection<Rule> Copy()
            {
                throw new NotImplementedException();
            }

            protected override Rule CreateFactRule(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType)
            {
                throw new NotImplementedException();
            }
        }
    }
}