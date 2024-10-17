using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.FactFactoryTests.FactContainerWriter
{
    [TestClass]
    public abstract class FactContainerWriterTestBase : CommonTestBase
    {
        protected GivenBlock<object, FactFactory.BaseEntities.FactContainerWriter> GivenCreateWriter(IFactContainer container)
        {
            return Given("Create writer.", () => new FactFactory.BaseEntities.FactContainerWriter(container));
        }
    }
}
