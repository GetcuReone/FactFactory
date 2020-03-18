using FactFactory.TestsCommon;
using FactFactory.VersionedTests.Version.Env;
using GetcuReone.GwtTestFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.Version
{
    [TestClass]
    public sealed class LongVersionTests : TestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The first version is less than the second.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void LongVersion_FirstVersionLessThanSecondTestCase()
        {
            LongVersion v1 = null;
            LongVersion v2 = null;

            Given("Create first version", () => v1 = new LongVersion(1))
                .And("Create second version", _ => v2 = new LongVersion(2))
                .When("Compare version", _ => v1.IsLessThan(v2))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not less than the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The second version is more than the first.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void LongVersion_SecondVersionMoreThanFirstTestCase()
        {
            LongVersion v1 = null;
            LongVersion v2 = null;

            Given("Create first version", () => v1 = new LongVersion(1))
                .And("Create second version", _ => v2 = new LongVersion(2))
                .When("Compare version", _ => v2.IsMoreThan(v1))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not more than the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The Long version is not less than the DateTime.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void LongVersionVersionNotLessThanDateTimeTestCase()
        {
            LongVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new LongVersion(1))
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.IsLessThan(v2))
                .Then("Check result", result => Assert.IsFalse(result, "The Long version is less than the DateTime"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The Long version is not more than the DateTime.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void LongVersionNotMoreThanDateTimeTestCase()
        {
            LongVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new LongVersion(1))
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.IsMoreThan(v2))
                .Then("Check result", result => Assert.IsFalse(result, "The Long version is more than the DateTime"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The second version is equal the first.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void LongVersion_SecondVersionEqualFirstTestCase()
        {
            LongVersion v1 = null;
            LongVersion v2 = null;

            Given("Create first version", () => v1 = new LongVersion(1))
                .And("Create second version", _ => v2 = new LongVersion(1))
                .When("Compare version", _ => v2.EqualVersion(v1))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not equal the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The Long version is not equal the DateTime.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void LongVersionNotEqualDateTimeTestCase()
        {
            LongVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new LongVersion(1))
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.Equals(v2))
                .Then("Check result", result => Assert.IsFalse(result, "The Long version is equal the DateTime"));
        }
    }
}
