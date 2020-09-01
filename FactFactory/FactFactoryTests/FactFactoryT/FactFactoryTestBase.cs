using FactFactory.TestsCommon;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Factory = GetcuReone.FactFactory.FactFactory;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public abstract class FactFactoryTestBase : CommonTestBase
    {
        protected GivenBlock<Factory> GivenCreateFactFactory()
        {
            return Given("Create fact factory.", () => new Factory());
        }
    }
}
