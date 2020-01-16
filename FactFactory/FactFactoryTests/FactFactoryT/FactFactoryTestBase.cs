using JwtTestAdapter;
using JwtTestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public abstract class FactFactoryTestBase : TestBase
    {
        protected GivenBlock<FactFactory.FactFactory> GivenCreateFactFactory()
        {
            return Given("Create fact factory", () => new FactFactory.FactFactory());
        }
    }
}
