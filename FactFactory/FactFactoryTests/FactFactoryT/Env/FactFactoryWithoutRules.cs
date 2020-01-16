using System.Collections.Generic;
using WAction = FactFactory.Entities.WantAction;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryWithoutRules : FactFactory.FactFactory
    {
        protected override IReadOnlyCollection<FactFactory.Entities.FactRule> GetRulesForWantAction(WAction wantAction)
        {
            return default;
        }

        protected override FactFactory.Entities.FactContainer GetContainerForDerive()
        {
            return Container;
        }
    }
}
