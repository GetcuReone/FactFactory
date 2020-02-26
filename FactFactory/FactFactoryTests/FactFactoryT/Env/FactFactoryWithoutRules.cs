﻿using GetcuReone.FactFactory.Facts;
using System.Collections.Generic;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryWithoutRules : GetcuReone.FactFactory.FactFactory
    {
        protected override IReadOnlyCollection<GetcuReone.FactFactory.Entities.FactRule> GetRulesForWantAction(WAction wantAction, IReadOnlyCollection<FactBase> rOC)
        {
            return default;
        }

        protected override GetcuReone.FactFactory.Entities.FactContainer GetContainerForDerive()
        {
            return Container;
        }
    }
}
