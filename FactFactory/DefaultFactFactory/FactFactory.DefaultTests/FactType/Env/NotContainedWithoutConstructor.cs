﻿using GetcuReone.FactFactory.BaseEntities.SpecialFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;

namespace FactFactoryTests.FactType.Env
{
    internal class NotContainedWithoutConstructor : ConditionFactBase, IConditionFact
    {
        private NotContainedWithoutConstructor()
        {

        }

        public override bool Condition<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            throw new NotImplementedException();
        }

        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
        {
            throw new NotImplementedException();
        }

        public bool IsFactContained(IFactContainer container)
        {
            throw new NotImplementedException();
        }

        public override bool IsFactContained<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            throw new NotImplementedException();
        }
    }
}
