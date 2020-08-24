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
    [Ignore]
    public sealed class UlongVersionTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first version is less than the second.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UlongVersion_FirstVersionLessThanSecondTestCase()
        {
            const int expectedValue = -1;
            UlongVersion v1 = null;
            UlongVersion v2 = null;

            Given("Create first version.", () => v1 = new UlongVersion(1))
                .And("Create second version.", _ =>
                    v2 = new UlongVersion(2))
                .When("Compare version.", _ =>
                    v1.CompareTo(v2))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is more than the first.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UlongVersion_SecondVersionMoreThanFirstTestCase()
        {
            const int expectedValue = 1;
            UlongVersion v1 = null;
            UlongVersion v2 = null;

            Given("Create first version.", () => v1 = new UlongVersion(1))
                .And("Create second version.", _ =>
                    v2 = new UlongVersion(2))
                .When("Compare version.", _ =>
                    v2.CompareTo(v1))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is equal the first.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UlongVersion_SecondVersionEqualFirstTestCase()
        {
            const int expectedValue = 0;
            UlongVersion v1 = null;
            UlongVersion v2 = null;

            Given("Create first version.", () => v1 = new UlongVersion(2))
                .And("Create second version.", _ =>
                    v2 = new UlongVersion(2))
                .When("Compare version.", _ =>
                    v2.CompareTo(v1))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The Int version is not less than the DateTime.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UlongVersionVersionNotLessThanDateTimeTestCase()
        {
            const string expectedReason = "Unable to compare versions UlongVersion and Version2020.";
            UlongVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version.", () => v1 = new UlongVersion(1))
                .And("Create second version.", _ =>
                    v2 = new Version2020())
                .When("Compare version.", _ =>
                    ExpectedFactFactoryException(() => v1.CompareTo(v2)))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }
    }
}
