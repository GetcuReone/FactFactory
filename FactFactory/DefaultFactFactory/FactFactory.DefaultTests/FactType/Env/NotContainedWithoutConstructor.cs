﻿using GetcuReone.FactFactory.BaseEntities.SpecialFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;

namespace FactFactoryTests.FactType.Env
{
    internal class NotContainedWithoutConstructor : ConditionFactBase, IConditionFact
    {
        private NotContainedWithoutConstructor()
        {

        }

        public override bool Condition<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            throw new NotImplementedException();
        }

        public bool IsFactContained<TFact>(IFactContainer<TFact> container)
            where TFact : IFact
        {
            throw new NotImplementedException();
        }

        public override bool IsFactContained<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            throw new NotImplementedException();
        }
    }
}
