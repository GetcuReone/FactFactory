using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.Version.Env;
using GetcuReone.FactFactory.Constants;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.Version
{
    [TestClass]
    public sealed class IntVersionTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first version is less than the second.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void IntVersion_FirstVersionLessThanSecondTestCase()
        {
            const int expectedValue = -1;
            IntVersion v1 = null;
            IntVersion v2 = null;

            Given("Create first version.", () => v1 = new IntVersion(1))
                .And("Create second version.", _ => 
                    v2 = new IntVersion(2))
                .When("Compare version.", _ => 
                    v1.CompareTo(v2))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is more than the first.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void IntVersion_SecondVersionMoreThanFirstTestCase()
        {
            const int expectedValue = 1;
            IntVersion v1 = null;
            IntVersion v2 = null;

            Given("Create first version.", () => v1 = new IntVersion(1))
                .And("Create second version.", _ => 
                    v2 = new IntVersion(2))
                .When("Compare version.", _ => 
                    v2.CompareTo(v1))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is equal the first.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void IntVersion_SecondVersionEqualFirstTestCase()
        {
            const int expectedValue = 0;
            IntVersion v1 = null;
            IntVersion v2 = null;

            Given("Create first version.", () => v1 = new IntVersion(2))
                .And("Create second version.", _ =>
                    v2 = new IntVersion(2))
                .When("Compare version.", _ =>
                    v2.CompareTo(v1))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The Int version is not less than the DateTime.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void IntVersionVersionNotLessThanDateTimeTestCase()
        {
            const string expectedReason = "Unable to compare versions IntVersion and Version2020.";
            IntVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version.", () => v1 = new IntVersion(1))
                .And("Create second version.", _ => 
                    v2 = new Version2020())
                .When("Compare version.", _ =>
                    ExpectedFactFactoryException(() => v1.CompareTo(v2)))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason)
                .Run();
        }
    }
}
