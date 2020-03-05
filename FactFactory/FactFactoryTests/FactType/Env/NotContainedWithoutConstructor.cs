using GetcuReone.FactFactory.Interfaces;
using System;

namespace FactFactoryTests.FactType.Env
{
    internal class NotContainedWithoutConstructor : IFact, INotContainedFact
    {
        private NotContainedWithoutConstructor()
        {

        }

        public IFactType GetFactType()
        {
            throw new NotImplementedException();
        }

        public bool IsFactContained<TFact>(IFactContainer<TFact> container)
            where TFact : IFact
        {
            throw new NotImplementedException();
        }
    }
}
