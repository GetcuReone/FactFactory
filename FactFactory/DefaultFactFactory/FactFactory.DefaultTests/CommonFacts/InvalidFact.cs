using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace FactFactoryTests.CommonFacts
{
    internal class InvalidFact : IFact
    {
        public bool CalculatedByRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<IFactParameter> Parameters => throw new NotImplementedException();

        public void AddParameter(IFactParameter parameter)
        {
            throw new NotImplementedException();
        }

        public IFactType GetFactType()
        {
            throw new NotImplementedException();
        }
    }
}
