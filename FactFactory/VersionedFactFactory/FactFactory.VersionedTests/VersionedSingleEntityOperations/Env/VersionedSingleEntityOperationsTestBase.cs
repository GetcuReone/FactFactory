using GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.VersionedSingleEntityOperations.Env
{
    [TestClass]
    public abstract class VersionedSingleEntityOperationsTestBase : VersionedFactFactoryTestBase
    {
        protected virtual GivenBlock<VersionedSingleEntityOperationsFacade> GivenCreateFacade()
        {
            return Given("Create SingleEntityOperationsFacade", () => GetFacade<VersionedSingleEntityOperationsFacade>());
        }
    }
}
