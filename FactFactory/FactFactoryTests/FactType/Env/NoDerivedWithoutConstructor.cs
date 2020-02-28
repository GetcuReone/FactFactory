using GetcuReone.FactFactory.Interfaces;
using System;

namespace FactFactoryTests.FactType.Env
{
    internal class NoDerivedWithoutConstructor : IFact, INoDerivedFact
    {
        private NoDerivedWithoutConstructor()
        {

        }

        public IFactType Value => throw new NotImplementedException();

        public IFactType GetFactType()
        {
            throw new NotImplementedException();
        }
    }
}
