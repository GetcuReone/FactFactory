using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using GivenWhenThen.TestAdapter;
using System;

namespace FactFactory.TestsCommon
{
    public abstract class CommonTestBase : TestBase
    {
        protected virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        protected FactFactoryException ExpectedFactFactoryException(Action action)
        {
            return ExpectedException<FactFactoryException>(action);
        }

        protected InvalidDeriveOperationException<TFact, TAction> ExpectedDeriveException<TFact, TAction>(Action action)
            where TFact : IFact
            where TAction : IWantAction<TFact>
        {
            return ExpectedException<InvalidDeriveOperationException<TFact, TAction>>(action);
        }
    }
}
