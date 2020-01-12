using FactFactory.Entities;
using System.Collections.Generic;
using WAction = FactFactory.Entities.WantAction;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryWithoutRules : FactFactory.FactFactory
    {
        protected override IReadOnlyCollection<FactFactory.Entities.FactRule> GetRulesForDerive(WAction wantAction)
        {
            return default;
        }
    }
}
