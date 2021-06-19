using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Constants;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace GetcuReone.FactFactoryTests.FactContainerWriter
{
    [TestClass]
    public sealed class RemoveTests : FactContainerWriterTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add fact without writer.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RemoveFactWithoutWriterTestCase()
        {
            var container = new Container 
            {
                new IntFact(default),
            };
            container.IsReadOnly = true;

            GivenEmpty()
                .When("Add fact.", () =>
                     ExpectedFactFactoryException(() => container.Remove<IntFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, $"Fact container is read-only.")
                .And("Check is read-only.", () =>
                    Assert.IsTrue(container.IsReadOnly))
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add fact without writer.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RemoveFactWithoutWriter_2_TestCase()
        {
            var fact = new IntFact(default);
            var container = new Container
            {
                fact,
            };
            container.IsReadOnly = true;

            GivenEmpty()
                .When("Add fact.", () =>
                     ExpectedFactFactoryException(() => container.Remove(fact)))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, $"Fact container is read-only.")
                .And("Check is read-only.", () =>
                    Assert.IsTrue(container.IsReadOnly))
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add fact with writer.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RemoveFactWithWriterTestCase()
        {
            var container = new Container
            {
                new IntFact(default),
            };
            container.IsReadOnly = true;

            GivenCreateWriter(container)
                .When("Add fact.", writer =>
                {
                    using (writer)
                        writer.Remove<IntFact>();
                })
                .Then("Check container.", () =>
                    Assert.IsFalse(container.Contains<IntFact>()))
                .And("Check is read-only.", () =>
                    Assert.IsTrue(container.IsReadOnly))
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add fact with writer.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RemoveFactWithWriter_2_TestCase()
        {
            var fact = new IntFact(default);
            var container = new Container
            {
                fact,
            };
            container.IsReadOnly = true;

            GivenCreateWriter(container)
                .When("Add fact.", writer =>
                {
                    using (writer)
                        writer.Remove(fact);
                })
                .Then("Check container.", () =>
                    Assert.IsFalse(container.Contains<IntFact>()))
                .And("Check is read-only.", () =>
                    Assert.IsTrue(container.IsReadOnly))
                .Run();
        }
    }
}
