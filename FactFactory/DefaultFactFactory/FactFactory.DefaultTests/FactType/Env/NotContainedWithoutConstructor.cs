using GetcuReone.FactFactory.BaseEntities.SpecialFacts;
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

        public override bool Condition<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
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
