using FactFactory.TestsCommon;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public abstract class FactFactoryTestBase : CommonTestBase
    {
        protected GivenBlock<GetcuReone.FactFactory.FactFactory> GivenCreateFactFactory()
        {
            return Given("Create fact factory", () => new GetcuReone.FactFactory.FactFactory());
        }
    }
}
