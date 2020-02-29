using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facts;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public abstract class FactFactoryTestBase : CommonTestBase
    {
        protected GivenBlock<GetcuReone.FactFactory.FactFactory> GivenCreateFactFactory()
        {
            return Given("Create fact factory", () => new GetcuReone.FactFactory.FactFactory());
        }

        protected InvalidDeriveOperationException<FactBase, WAction> ExpectedDeriveException(Action action)
        {
            return ExpectedException<InvalidDeriveOperationException<FactBase, WAction>>(action);
        }
    }
}
