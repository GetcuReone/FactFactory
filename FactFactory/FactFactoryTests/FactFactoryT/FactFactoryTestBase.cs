using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Facts;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public abstract class FactFactoryTestBase : CommonTestBase<FactBase>
    {
        protected GivenBlock<GetcuReone.FactFactory.FactFactory> GivenCreateFactFactory()
        {
            return Given("Create fact factory", () => new GetcuReone.FactFactory.FactFactory());
        }
    }
}
