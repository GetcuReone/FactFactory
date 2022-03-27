using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.SingleEntityOperationsTests.Env
{
    [TestClass]
    public abstract class SingleEntityOperationsTestBase : CommonTestBase
    {
        public Container Container { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            Container = new Container
            {
                new Input1Fact(default),
            };
        }

        protected virtual GivenBlock<object, SingleEntityOperationsFacade> GivenCreateFacade()
        {
            return Given("Create SingleEntityOperationsFacade", () => GetFacade<SingleEntityOperationsFacade>());
        }
    }
}
