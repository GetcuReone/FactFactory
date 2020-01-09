using System;
using System.Collections.Generic;
using System.Text;
using FactFactory.Entities;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryWithoutRules : FactFactory.FactFactory
    {
        public override IEnumerable<FactFactory.Entities.FactRule> GetRulesForDerive()
        {
            return default;
        }
    }
}
