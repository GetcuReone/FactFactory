using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace GetcuReone.FactFactoryTests.FactContainerWriter
{
    [TestClass]
    public sealed class AddRangeTests : FactContainerWriterTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add fact without writer.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddFactsWithoutWriterTestCase()
        {
            var facts = new List<IFact>
            {
                new IntFact(default),
                new OtherFact(default),
            };
            var container = new Container();
            container.IsReadOnly = true;

            GivenEmpty()
                .When("Add fact.", () =>
                     ExpectedFactFactoryException(() => container.AddRange(facts)))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, $"Fact container is read-only.")
                .And("Check is read-only.", () => 
                    Assert.IsTrue(container.IsReadOnly))
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add fact with writer.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddFactsWithWriterTestCase()
        {
            var facts = new List<IFact>
            {
                new IntFact(default),
                new OtherFact(default),
            };
            var container = new Container();
            container.IsReadOnly = true;

            GivenCreateWriter(container)
                .When("Add fact.", writer =>
                {
                    using (writer)
                        writer.AddRange(facts);
                })
                .Then("Check container.", () =>
                    Assert.IsTrue(container.Contains<IntFact>()))
                .And("Check container.", () =>
                    Assert.IsTrue(container.Contains<OtherFact>()))
                .And("Check is read-only.", () =>
                    Assert.IsTrue(container.IsReadOnly))
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add facts after dispose writer.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddFactsAfterDispose()
        {
            var facts = new List<IFact>
            {
                new IntFact(default),
                new OtherFact(default),
            };
            var container = new Container();
            container.IsReadOnly = true;

            GivenCreateWriter(container)
                .And("Add fact.", writer =>
                {
                    using (writer)
                        writer.AddRange(facts);
                })
                .When("Add fact after dispose.", writer =>
                {
                    return ExpectedException<ObjectDisposedException>(() => writer.AddRange(facts));
                })
                .ThenIsNotNull(blockName: "Check message error.")
                .Run();
        }
    }
}
