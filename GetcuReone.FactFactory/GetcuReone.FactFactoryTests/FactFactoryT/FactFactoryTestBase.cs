using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Factory = GetcuReone.FactFactory.FactFactory;

namespace GetcuReone.FactFactoryTests.FactFactoryT
{
    [TestClass]
    public abstract class FactFactoryTestBase : CommonTestBase
    {
        protected GivenBlock<object, IFactFactory> GivenCreateFactFactory()
        {
            return Given("Create fact factory.", () => (IFactFactory)new Factory());
        }
    }
}
