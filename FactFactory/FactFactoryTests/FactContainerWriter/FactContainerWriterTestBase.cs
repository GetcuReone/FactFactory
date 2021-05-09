using FactFactory.TestsCommon;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.FactFactoryTests.FactContainerWriter
{
    [TestClass]
    public abstract class FactContainerWriterTestBase : CommonTestBase
    {
        protected GivenBlock<object, FactContainerWriter<TFactContainer>> GivenCreateWriter<TFactContainer>(TFactContainer container)
            where TFactContainer : IFactContainer
        {
            return Given("Create writer.", () => new FactContainerWriter<TFactContainer>(container));
        }
    }
}
