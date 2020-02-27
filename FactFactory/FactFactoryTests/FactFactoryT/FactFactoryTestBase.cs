using GivenWhenThen.TestAdapter;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public abstract class FactFactoryTestBase : TestBase
    {
        protected GivenBlock<GetcuReone.FactFactory.FactFactory> GivenCreateFactFactory()
        {
            return Given("Create fact factory", () => new GetcuReone.FactFactory.FactFactory());
        }
    }
}
