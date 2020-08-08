using FactFactory.TestsCommon;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests.Env
{
    [TestClass]
    public abstract class SingleEntityOperationsTestBase : CommonTestBase<FactBase>
    {
        protected GivenBlock<SingleEntityOperationsFacade> GivenCreateFacade()
        {
            return Given("Create SingleEntityOperationsFacade", () => GetFacade<SingleEntityOperationsFacade>());
        }
    }
}
