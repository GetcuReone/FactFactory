using System;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GetcuTestAdapter;

namespace FactFactory.TestsCommon
{
    public abstract class CommonTestBase<TFactBase> : GetcuReoneTestBase
        where TFactBase : IFact
    {
        protected virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        protected FactFactoryException ExpectedFactFactoryException(Action action)
        {
            return ExpectedException<FactFactoryException>(action);
        }

        protected InvalidDeriveOperationException<TFactBase> ExpectedDeriveException(Action action)
        {
            return ExpectedException<InvalidDeriveOperationException<TFactBase>>(action);
        }
    }
}
