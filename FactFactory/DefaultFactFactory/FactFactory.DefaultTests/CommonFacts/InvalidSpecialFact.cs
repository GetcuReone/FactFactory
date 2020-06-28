using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class InvalidSpecialFact : FactBase<int>, INoDerivedFact, IContainedFact
    {
        public InvalidSpecialFact() : base(0)
        {
        }

        public IFactType FactType => throw new NotImplementedException();

        public bool IsFactContained<TFact>(IFactContainer<TFact> container) where TFact : IFact
        {
            throw new NotImplementedException();
        }
    }
}
