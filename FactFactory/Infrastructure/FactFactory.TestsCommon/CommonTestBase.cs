using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GetcuTestAdapter;
using System;

namespace FactFactory.TestsCommon
{
    public abstract class CommonTestBase : GetcuReoneTestBase, IFactTypeCreation
    {
        public virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        protected FactFactoryException ExpectedFactFactoryException(Action action)
        {
            return ExpectedException<FactFactoryException>(action);
        }

        protected InvalidDeriveOperationException ExpectedDeriveException(Action action)
        {
            return ExpectedException<InvalidDeriveOperationException>(action);
        }
    }
}
