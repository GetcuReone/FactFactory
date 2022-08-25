using GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.VersionedSingleEntityOperations.Env
{
    [TestClass]
    public abstract class VersionedSingleEntityOperationsTestBase : BaseVersionedFactFactoryTests
    {
        protected virtual GivenBlock<object, VersionedSingleEntityOperationsFacade> GivenCreateFacade()
        {
            return Given("Create SingleEntityOperationsFacade", () => GetFacade<VersionedSingleEntityOperationsFacade>());
        }
    }
}
