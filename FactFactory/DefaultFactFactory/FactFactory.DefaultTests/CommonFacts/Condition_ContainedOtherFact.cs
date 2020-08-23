﻿using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.BaseEntities.SpecialFacts;
using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace FactFactory.DefaultTests.CommonFacts
{
    internal sealed class Condition_ContainedOtherFact : ConditionFactBase<OtherFact>
    {
        public override bool Condition<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            return container.Contains<OtherFact>();
        }

        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
        {
            return context.Container.Contains<OtherFact>();
        }
    }
}
