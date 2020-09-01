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
    public sealed class LongVersionTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first version is less than the second.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void LongVersion_FirstVersionLessThanSecondTestCase()
        {
            const int expectedValue = -1;
            LongVersion v1 = null;
            LongVersion v2 = null;

            Given("Create first version.", () => v1 = new LongVersion(1))
                .And("Create second version.", _ =>
                    v2 = new LongVersion(2))
                .When("Compare version.", _ =>
                    v1.CompareTo(v2))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is more than the first.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void LongVersion_SecondVersionMoreThanFirstTestCase()
        {
            const int expectedValue = 1;
            LongVersion v1 = null;
            LongVersion v2 = null;

            Given("Create first version.", () => v1 = new LongVersion(1))
                .And("Create second version.", _ =>
                    v2 = new LongVersion(2))
                .When("Compare version.", _ =>
                    v2.CompareTo(v1))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is equal the first.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void LongVersion_SecondVersionEqualFirstTestCase()
        {
            const int expectedValue = 0;
            LongVersion v1 = null;
            LongVersion v2 = null;

            Given("Create first version.", () => v1 = new LongVersion(2))
                .And("Create second version.", _ =>
                    v2 = new LongVersion(2))
                .When("Compare version.", _ =>
                    v2.CompareTo(v1))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The Int version is not less than the DateTime.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void LongVersionVersionNotLessThanDateTimeTestCase()
        {
            const string expectedReason = "Unable to compare versions LongVersion and Version2020.";
            LongVersion v1 = null;
            Version2020 v2 = null;

            Given("Create first version.", () => v1 = new LongVersion(1))
                .And("Create second version.", _ =>
                    v2 = new Version2020())
                .When("Compare version.", _ =>
                    ExpectedFactFactoryException(() => v1.CompareTo(v2)))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }
    }
}
