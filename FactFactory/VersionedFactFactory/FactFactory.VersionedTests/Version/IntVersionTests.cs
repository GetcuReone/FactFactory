using FactFactory.TestsCommon;
using FactFactory.VersionedTests.Version.Env;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.Version
{
    [TestClass]
    public sealed class IntVersionTests : CommonTestBase<VersionedFactBase>
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first version is less than the second.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void IntVersion_FirstVersionLessThanSecondTestCase()
        {
            IntVersion v1 = null;
            IntVersion v2 = null;

            Given("Create first version", () => v1 = new IntVersion(1))
                .And("Create second version", _ => v2 = new IntVersion(2))
                .When("Compare version", _ => v1.IsLessThan(v2))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not less than the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is more than the first.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void IntVersion_SecondVersionMoreThanFirstTestCase()
        {
            IntVersion v1 = null;
            IntVersion v2 = null;

            Given("Create first version", () => v1 = new IntVersion(1))
                .And("Create second version", _ => v2 = new IntVersion(2))
                .When("Compare version", _ => v2.IsMoreThan(v1))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not more than the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The Int version is not less than the DateTime.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void IntVersionVersionNotLessThanDateTimeTestCase()
        {
            IntVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new IntVersion(1))
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.IsLessThan(v2))
                .Then("Check result", result => Assert.IsFalse(result, "The Int version is less than the DateTime"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The Int version is not more than the DateTime.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void IntVersionNotMoreThanDateTimeTestCase()
        {
            IntVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new IntVersion(1))
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.IsMoreThan(v2))
                .Then("Check result", result => Assert.IsFalse(result, "The Int version is more than the DateTime"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is equal the first.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void IntVersion_SecondVersionEqualFirstTestCase()
        {
            IntVersion v1 = null;
            IntVersion v2 = null;

            Given("Create first version", () => v1 = new IntVersion(1))
                .And("Create second version", _ => v2 = new IntVersion(1))
                .When("Compare version", _ => v2.EqualVersion(v1))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not equal the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The Int version is not equal the DateTime.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void IntVersionNotEqualDateTimeTestCase()
        {
            IntVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new IntVersion(1))
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.Equals(v2))
                .Then("Check result", result => Assert.IsFalse(result, "The Int version is equal the DateTime"));
        }
    }
}
