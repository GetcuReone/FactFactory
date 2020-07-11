using FactFactory.TestsCommon;
using GetcuReone.FactFactory;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Factory = GetcuReone.FactFactory.FactFactory;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public abstract class FactFactoryTestBase : CommonTestBase<FactBase>
    {
        protected GivenBlock<Factory> GivenCreateFactFactory()
        {
            return Given("Create fact factory.", () => new Factory());
        }
    }
}
