using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactory.VersionedTests.VersionedFactContainer.Env
{
    [TestClass]
    public abstract class VersionedFactContrainerTestBase : CommonTestBase
    {
        protected GivenBlock<Container, Container> GivenCreateContainer()
        {
            return Given("Create container.", () => new Container())
                .And("Add comparer.", container => 
                {
                    container.Comparer = new VersionedSingleEntityOperationsFacade().GetFactComparer(null);
                });
        }
    }
}
