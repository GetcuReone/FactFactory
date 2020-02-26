using GetcuReone.FactFactory.Interfaces;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal class InvalidFact : IFact
    {
        public IFactType GetFactType()
        {
            throw new NotImplementedException();
        }
    }
}
