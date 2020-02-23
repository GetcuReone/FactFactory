using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.UintVersion.Env;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.UintVersion
{
    [TestClass]
    public class UintVersionTests : TestBase
    {
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][versioned] The first version is less than the second")]
        public void FirstVersionLessThanSecondTestCase()
        {
            Version1 v1 = null;
            Version2 v2 = null;

            Given("Create first version", () => v1 = new Version1())
                .And("Create second version", _ => v2 = new Version2())
                .When("Compare version", _ => v1.IsLessThan(v2))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not less than the second"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][versioned] The second version is more than the first")]
        public void SecondVersionMoreThanFirstTestCase()
        {
            Version1 v1 = null;
            Version2 v2 = null;

            Given("Create first version", () => v1 = new Version1())
                .And("Create second version", _ => v2 = new Version2())
                .When("Compare version", _ => v2.IsMoreThan(v1))
                .Then("Check result", result => Assert.IsTrue(result, "The first version is not more than the second"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][versioned] The uint version is not less than the int")]
        public void UintVersionNotLessThanIntTestCase()
        {
            Version1 v1 = null;
            IntVersion intVersion = null;

            Given("Create first version", () => v1 = new Version1())
                .And("Create second version", _ => intVersion = new IntVersion(2))
                .When("Compare version", _ => v1.IsLessThan(intVersion))
                .Then("Check result", result => Assert.IsFalse(result, "The uint version is less than the int"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][versioned] The uint version is not more than the int")]
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
