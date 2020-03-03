using FactFactory.TestsCommon;
using FactFactory.VersionedTests.Version.Env;
using GivenWhenThen.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.Version
{
    [TestClass]
    public sealed class UlongVersionTests : TestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The first version is less than the second")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void UlongVersion_FirstVersionLessThanSecondTestCase()
        {
            UlongVersion v1 = null;
            UlongVersion v2 = null;

            Given("Create first version", () => v1 = new UlongVersion(1))
                .And("Create second version", _ => v2 = new UlongVersion(2))
                .When("Compare version", _ => v1.IsLessThan(v2))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not less than the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The second version is more than the first")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void UlongVersion_SecondVersionMoreThanFirstTestCase()
        {
            UlongVersion v1 = null;
            UlongVersion v2 = null;

            Given("Create first version", () => v1 = new UlongVersion(1))
                .And("Create second version", _ => v2 = new UlongVersion(2))
                .When("Compare version", _ => v2.IsMoreThan(v1))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not more than the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The Ulong version is not less than the DateTime")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void UlongVersionVersionNotLessThanDateTimeTestCase()
        {
            UlongVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new UlongVersion(1))
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.IsLessThan(v2))
                .Then("Check result", result => Assert.IsFalse(result, "The Ulong version is less than the DateTime"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The Ulong version is not more than the DateTime")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void UlongVersionNotMoreThanDateTimeTestCase()
        {
            UlongVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new UlongVersion(1))
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.IsMoreThan(v2))
                .Then("Check result", result => Assert.IsFalse(result, "The Ulong version is more than the DateTime"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The second version is equal the first")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void UlongVersion_SecondVersionEqualFirstTestCase()
        {
            UlongVersion v1 = null;
            UlongVersion v2 = null;

            Given("Create first version", () => v1 = new UlongVersion(1))
                .And("Create second version", _ => v2 = new UlongVersion(1))
                .When("Compare version", _ => v2.EqualVersion(v1))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not equal the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The Ulong version is not equal the DateTime")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void UlongVersionNotEqualDateTimeTestCase()
        {
            UlongVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new UlongVersion(1))
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.Equals(v2))
                .Then("Check result", result => Assert.IsFalse(result, "The Ulong version is equal the DateTime"));
        }
    }
}
