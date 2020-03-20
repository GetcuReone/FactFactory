using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;

namespace FactFactory.VersionedTests.VersionedFactContainer.Env
{
    [TestClass]
    public abstract class VersionedFactContrainerTestBase : CommonTestBase<VersionedFactBase>
    {
        protected GivenBlock<Container> GivenCreateContainer()
        {
            return Given("Create container", () => new Container());
        }
    }
}
