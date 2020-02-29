using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.Version.Env;
using GivenWhenThen.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.Version
{
    [TestClass]
    public sealed class DateTimeVersionTests : TestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The first version is less than the second")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DateTimeVersion_FirstVersionLessThanSecondTestCase()
        {
            Version2019 v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new Version2019())
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v1.IsLessThan(v2))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not less than the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The second version is more than the first")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void SecondVersionMoreThanFirstTestCase()
        {
            Version2019 v1 = null;
            Version2020 v2 = null;

            Given("Create first version", () => v1 = new Version2019())
                .And("Create second version", _ => v2 = new Version2020())
                .When("Compare version", _ => v2.IsMoreThan(v1))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not more than the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The DateTime version is not less than the unit")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DateTimeVersionVersionNotLessThanUintTestCase()
        {
            Version2019 v1 = null;
            Version1 uintVersion = null;

            Given("Create first version", () => v1 = new Version2019())
                .And("Create second version", _ => uintVersion = new Version1())
                .When("Compare version", _ => v1.IsLessThan(uintVersion))
                .Then("Check result", result => Assert.IsFalse(result, "The Datetime version is less than the Uint"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The Datetime version is not more than the Uint")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DateTimeVersionVersionNotMoreThanUintTestCase()
        {
            Version2019 v1 = null;
            Version1 uintVersion = null;

            Given("Create first version", () => v1 = new Version2019())
                .And("Create second version", _ => uintVersion = new Version1())
                .When("Compare version", _ => v1.IsMoreThan(uintVersion))
                .Then("Check result", result => Assert.IsFalse(result, "The Datetime version is more than the Uint"));
        }
    }
}
