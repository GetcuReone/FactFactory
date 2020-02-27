using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.UintVersion.Env;
using GivenWhenThen.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.UintVersion
{
    [TestClass]
    public class UintVersionTests : TestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The first version is less than the second")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void FirstVersionLessThanSecondTestCase()
        {
            Version1 v1 = null;
            Version2 v2 = null;

            Given("Create first version", () => v1 = new Version1())
                .And("Create second version", _ => v2 = new Version2())
                .When("Compare version", _ => v1.IsLessThan(v2))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not less than the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The second version is more than the first")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void SecondVersionMoreThanFirstTestCase()
        {
            Version1 v1 = null;
            Version2 v2 = null;

            Given("Create first version", () => v1 = new Version1())
                .And("Create second version", _ => v2 = new Version2())
                .When("Compare version", _ => v2.IsMoreThan(v1))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not more than the second"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The uint version is not less than the int")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void UintVersionNotLessThanIntTestCase()
        {
            Version1 v1 = null;
            IntVersion intVersion = null;

            Given("Create first version", () => v1 = new Version1())
                .And("Create second version", _ => intVersion = new IntVersion(2))
                .When("Compare version", _ => v1.IsLessThan(intVersion))
                .Then("Check result", result => Assert.IsFalse(result, "The uint version is less than the int"));
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact)]
        [Description("The uint version is not more than the int")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void UintVersionNotMoreThanIntTestCase()
        {
            Version1 v1 = null;
            IntVersion intVersion = null;

            Given("Create first version", () => v1 = new Version1())
                .And("Create second version", _ => intVersion = new IntVersion(0))
                .When("Compare version", _ => v1.IsMoreThan(intVersion))
                .Then("Check result", result => Assert.IsFalse(result, "The uint version is more than the int"));
        }
    }
}
