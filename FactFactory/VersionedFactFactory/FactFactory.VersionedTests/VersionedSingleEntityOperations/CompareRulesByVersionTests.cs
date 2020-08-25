using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedSingleEntityOperations.Env;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.VersionedSingleEntityOperations
{
    [TestClass]
    public sealed class CompareRulesByVersionTests : VersionedSingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compare rules without version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithoutVersionTestCase()
        {
            var first = GetFactRule((Fact1 _, Fact2 __) => new FactResult(default));
            var second = GetFactRule((Fact1 _) => new FactResult(default));
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Comparison rules.", facade => 
                    facade.CompareRulesByVersion(first, second, GetWantActionContext((IWantAction)null, Container, facade)))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compare rule with version and rule without version (1).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRuleWithVersionAndRuleWihoutVersion_1_TestCase()
        {
            var first = GetFactRule((Fact1 _, Version1 __) => new FactResult(default));
            var second = GetFactRule((Fact1 _) => new FactResult(default));
            const int expectedValue = -1;

            GivenCreateFacade()
                .When("Comparison rules.", facade =>
                    facade.CompareRulesByVersion(first, second, GetWantActionContext((IWantAction)null, Container, facade)))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compare rule with version and rule without version (2).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRuleWithVersionAndRuleWihoutVersion_2_TestCase()
        {
            var first = GetFactRule((Fact1 _) => new FactResult(default));
            var second = GetFactRule((Fact1 _, Version1 __) => new FactResult(default));
            const int expectedValue = 1;

            GivenCreateFacade()
                .When("Comparison rules.", facade =>
                    facade.CompareRulesByVersion(first, second, GetWantActionContext((IWantAction)null, Container, facade)))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compare rules with version (1).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithVersion_1_TestCase()
        {
            var first = GetFactRule((Fact1 _, Fact2 __, Version1 ___) => new FactResult(default));
            var second = GetFactRule((Fact1 _, Version2 __) => new FactResult(default));
            const int expectedValue = -1;

            GivenCreateFacade()
                .When("Comparison rules.", facade =>
                    facade.CompareRulesByVersion(first, second, GetWantActionContext((IWantAction)null, Container, facade)))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compare rules with version (2).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithVersion_2_TestCase()
        {
            var first = GetFactRule((Fact1 _, Fact2 __, Version2 ___) => new FactResult(default));
            var second = GetFactRule((Fact1 _, Version1 __) => new FactResult(default));
            const int expectedValue = 1;

            GivenCreateFacade()
                .When("Comparison rules.", facade =>
                    facade.CompareRulesByVersion(first, second, GetWantActionContext((IWantAction)null, Container, facade)))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compare rules with version (3).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithVersion_3_TestCase()
        {
            var first = GetFactRule((Fact1 _, Fact2 __, Version2 ___) => new FactResult(default));
            var second = GetFactRule((Fact1 _, Version2 __) => new FactResult(default));
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Comparison rules.", facade =>
                    facade.CompareRulesByVersion(first, second, GetWantActionContext((IWantAction)null, Container, facade)))
                .ThenAreEqual(expectedValue);
        }
    }
}
