using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Constants;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace GetcuReone.FactFactoryTests.FactContainerWriter
{
    [TestClass]
    public sealed class AddTests : FactContainerWriterTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add fact without writer.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddFactWithoutWriterTestCase()
        {
            var container = new Container();
            container.IsReadOnly = true;

            GivenEmpty()
                .When("Add fact.", () =>
                     ExpectedFactFactoryException(() => container.Add(new IntFact(default))))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, $"Fact container is read-only.")
                .And("Check is read-only.", () =>
                    Assert.IsTrue(container.IsReadOnly))
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add fact with writer.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddFactWithWriterTestCase()
        {
            var container = new Container();
            container.IsReadOnly = true;

            GivenCreateWriter(container)
                .When("Add fact.", writer =>
                {
                    using (writer)
                        writer.Add(new IntFact(default));
                })
                .Then("Check container.", () =>
                    Assert.IsTrue(container.Contains<IntFact>()))
                .And("Check is read-only.", () =>
                    Assert.IsTrue(container.IsReadOnly))
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add fact after dispose writer.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddFactAfterDispose()
        {
            var container = new Container();
            container.IsReadOnly = true;

            GivenCreateWriter(container)
                .And("Add fact.", writer =>
                {
                    using (writer)
                        writer.Add(new IntFact(default));
                })
                .When("Add fact after dispose.", writer =>
                {
                    return ExpectedException<ObjectDisposedException>(() => writer.Add(new IntFact(default)));
                })
                .ThenIsNotNull(blockName: "Check message error.")
                .Run();
        }
    }
}
