﻿using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class BuildCondition_ContainedOtherFact : BaseBuildConditionFact<OtherFact>
    {
        public override bool Condition<TFactWork, TFactRule>(
            TFactWork factWork, IWantActionContext context,
            Func<IWantActionContext, IFactRuleCollection<TFactRule>> getCompatibleRules)
        {
            return context.Container.Contains<OtherFact>();
        }
    }
}
