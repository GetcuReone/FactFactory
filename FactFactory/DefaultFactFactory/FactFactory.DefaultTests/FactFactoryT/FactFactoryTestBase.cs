using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Default;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Factory = GetcuReone.FactFactory.Default.FactFactory;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public abstract class FactFactoryTestBase : CommonTestBase<FactBase>
    {
        protected GivenBlock<Factory> GivenCreateFactFactory()
        {
            return Given("Create fact factory", () => new Factory());
        }
    }
}
