using FactFactory.TestsCommon;
using FactFactory.VersionedTests.Version.Env;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.Version
{
    [TestClass]
    public sealed class UintVersionTests : CommonTestBase<VersionedFactBase>
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first version is less than the second.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void UintVersion_FirstVersionLessThanSecondTestCase()
        {
            UintVersion v1 = null;
            UintVersion v2 = null;

            Given("Create first version", () => v1 = new UintVersion(1))
                .And("Create second version", _ => v2 = new UintVersion(2))
                .When("Compare version", _ => v1.IsLessThan(v2))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not less than the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is more than the first.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void UintVersion_SecondVersionMoreThanFirstTestCase()
        {
            UintVersion v1 = null;
            UintVersion v2 = null;

            Given("Create first version", () => v1 = new UintVersion(1))
                .And("Create second version", _ => v2 = new UintVersion(2))
                .When("Compare version", _ => v2.IsMoreThan(v1))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not more than the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The Uint version is not less than the DateTime.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void UintVersionVersionNotLessThanDateTimeTestCase()
        {
            UintVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new UintVersion(1))
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.IsLessThan(v2))
                .Then("Check result", result => Assert.IsFalse(result, "The Uint version is less than the DateTime"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The Uint version is not more than the DateTime.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void UintVersionNotMoreThanDateTimeTestCase()
        {
            UintVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new UintVersion(1))
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.IsMoreThan(v2))
                .Then("Check result", result => Assert.IsFalse(result, "The Uint version is more than the DateTime"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is equal the first.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void UintVersion_SecondVersionEqualFirstTestCase()
        {
            UintVersion v1 = null;
            UintVersion v2 = null;

            Given("Create first version", () => v1 = new UintVersion(1))
                .And("Create second version", _ => v2 = new UintVersion(1))
                .When("Compare version", _ => v2.EqualVersion(v1))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not equal the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The Uint version is not equal the DateTime.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void UintVersionNotEqualDateTimeTestCase()
        {
            UintVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new UintVersion(1))
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.Equals(v2))
                .Then("Check result", result => Assert.IsFalse(result, "The Uint version is equal the DateTime"));
        }
    }
}
