using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.Version.Env;
using GetcuReone.FactFactory.Constants;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.Version
{
    [TestClass]
    public sealed class MajorMinorPatchVersionTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first version is less than the second.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void MajorMinorPatchVersion_FirstVersionLessThanSecondTestCase()
        {
            const int expectedValue = -1;
            Version1_0 v1 = null;
            Version1_1 v2 = null;

            Given("Create first version.", () => v1 = new Version1_0())
                .And("Create second version.", _ =>
                    v2 = new Version1_1())
                .When("Compare version.", _ =>
                    v1.CompareTo(v2))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is more than the first.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void MajorMinorPatchVersion_SecondVersionMoreThanFirstTestCase()
        {
            const int expectedValue = 1;
            Version1_0 v1 = null;
            Version1_1 v2 = null;

            Given("Create first version.", () => v1 = new Version1_0())
                .And("Create second version.", _ =>
                    v2 = new Version1_1())
                .When("Compare version.", _ =>
                    v2.CompareTo(v1))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is equal the first.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void MajorMinorPatchVersion_SecondVersionEqualFirstTestCase()
        {
            const int expectedValue = 0;
            Version1_1 v1 = null;
            Version1_1 v2 = null;

            Given("Create first version.", () => v1 = new Version1_1())
                .And("Create second version.", _ =>
                    v2 = new Version1_1())
                .When("Compare version.", _ =>
                    v2.CompareTo(v1))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The DateTime version is not less than the unit.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void MajorMinorPatchVersionVersionNotLessThanUintTestCase()
        {
            const string expectedReason = "Unable to compare versions Version1_1 and Version1.";
            Version1_1 v1 = null;
            Version1 uintVersion = null;

            Given("Create first version.", () => v1 = new Version1_1())
                .And("Create second version.", _ =>
                    uintVersion = new Version1())
                .When("Compare version.", _ =>
                    ExpectedFactFactoryException(() => v1.CompareTo(uintVersion)))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason)
                .Run();
        }
    }
}
