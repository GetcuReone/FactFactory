using FactFactory.Entities;
using System.Collections.Generic;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryWithoutRules : FactFactory.FactFactory
    {
        public override IEnumerable<FactFactory.Entities.FactRule> GetRulesForDerive(WantAction wantAction)
        {
            return default;
        }
    }
}
