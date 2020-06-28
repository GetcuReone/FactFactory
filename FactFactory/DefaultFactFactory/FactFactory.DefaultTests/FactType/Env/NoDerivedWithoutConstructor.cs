using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;

namespace FactFactoryTests.FactType.Env
{
    internal class NoDerivedWithoutConstructor : IFact, INoDerivedFact
    {
        private NoDerivedWithoutConstructor()
        {

        }

        public IFactType Value => throw new NotImplementedException();

        public bool CalculatedByRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IFactType GetFactType()
        {
            throw new NotImplementedException();
        }

        public bool IsFactContained<TFact>(IFactContainer<TFact> container) where TFact : IFact
        {
            throw new NotImplementedException();
        }
    }
}
