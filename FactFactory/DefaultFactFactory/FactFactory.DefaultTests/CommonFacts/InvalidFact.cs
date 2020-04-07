using GetcuReone.FactFactory.Interfaces;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal class InvalidFact : IFact
    {
        public bool CalculatedByRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IFactType GetFactType()
        {
            throw new NotImplementedException();
        }
    }
}
