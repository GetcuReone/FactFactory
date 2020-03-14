using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class InvalidSpecialFact : FactBase<int>, INoDerivedFact, IContainedFact
    {
        public InvalidSpecialFact() : base(0)
        {
        }

        IFactType INoDerivedFact.Value => throw new NotImplementedException();

        public bool IsFactContained<TFact>(IFactContainer<TFact> container) where TFact : IFact
        {
            throw new NotImplementedException();
        }
    }
}
