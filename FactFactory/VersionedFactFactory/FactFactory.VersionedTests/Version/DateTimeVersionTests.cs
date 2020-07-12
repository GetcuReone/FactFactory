using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.Version.Env;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.Version
{
    [TestClass]
    public sealed class DateTimeVersionTests : CommonTestBase<VersionedFactBase>
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first version is less than the second.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DateTimeVersion_FirstVersionLessThanSecondTestCase()
        {
            const int expectedValue = -1;
            Version2019 v1 = null;
            Version2020 v2 = null;

            Given("Create first version.", () => v1 = new Version2019())
                .And("Create second version.", _ => 
                    v2 = new Version2020())
                .When("Compare version.", _ => 
                    v1.CompareTo(v2))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is more than the first.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DateTimeVersion_SecondVersionMoreThanFirstTestCase()
        {
            const int expectedValue = 1;
            Version2019 v1 = null;
            Version2020 v2 = null;

            Given("Create first version.", () => v1 = new Version2019())
                .And("Create second version.", _ =>
                    v2 = new Version2020())
                .When("Compare version.", _ =>
                    v2.CompareTo(v1))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second version is equal the first.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DateTimeVersion_SecondVersionEqualFirstTestCase()
        {
            const int expectedValue = 0;
            Version2020 v1 = null;
            Version2020 v2 = null;

            Given("Create first version.", () => v1 = new Version2020())
                .And("Create second version.", _ =>
                    v2 = new Version2020())
                .When("Compare version.", _ =>
                    v2.CompareTo(v1))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("The DateTime version is not less than the unit.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DateTimeVersionVersionNotLessThanUintTestCase()
        {
            const string expectedReason = "Unable to compare versions Version2019 and Version1.";
            Version2019 v1 = null;
            Version1 uintVersion = null;

            Given("Create first version.", () => v1 = new Version2019())
                .And("Create second version.", _ =>
                    uintVersion = new Version1())
                .When("Compare version.", _ =>
                    ExpectedFactFactoryException(() => v1.CompareTo(uintVersion)))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }
    }
}
