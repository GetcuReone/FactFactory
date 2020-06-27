using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GwtTestFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.DefaultTests.Fact
{
    [TestClass]
    public sealed class SpecialFactTests : TestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.NotContained)]
        [Description("Get FactType for NotContained fact.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void Versioned_GetFactTypeForNotContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet", () => new NotContained<FactResult>())
                .Then("Check fact type", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<NotContained<FactResult>>, "Expected another FactType.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.Contained)]
        [Description("Get FactType for Contained fact.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void Versioned_GetFactTypeForContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet", () => new Contained<FactResult>())
                .Then("Check fact type", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<Contained<FactResult>>, "Expected another FactType.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.NoDerived)]
        [Description("Get FactType for NoDerived fact.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void Versioned_GetFactTypeForNoDerivedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet", () => new NoDerived<FactResult>())
                .Then("Check fact type", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<NoDerived<FactResult>>, "Expected another FactType.");
                });
        }
    }
}
