using GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.PriorityTests.SingleEntityOperations.Env
{
    [TestClass]
    public abstract class PrioritySingleEntityOperationsTestBase : PriorityFactFactoryTestBase
    {
        protected GivenBlock<PrioritySingleEntityOperationsFacade> GivenCreateFacade()
        {
            return Given("Create PrioritySingleEntityOperationsFacade facade.", () => GetFacade<PrioritySingleEntityOperationsFacade>());
        }
    }
}
