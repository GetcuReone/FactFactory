using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedSingleEntityOperations.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.VersionedSingleEntityOperations
{
    [TestClass]
    public sealed class CompatibleRuleTests : VersionedSingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compatible rules.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CompatibleRulesTestCase()
        {
            var first = GetFactRule((Fact1 _) => new FactResult(default));
            var second = GetFactRule((Fact2 _, Version1 v) => new FactResult(default));
            var wantAction = GetWantAction((FactResult _) => { });

            GivenCreateFacade()
                .When("Check compatible.", facade => 
                    facade.CompatibleRule(first, second, GetWantActionContext(wantAction, Container, facade)))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Not compatible rules.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void NotCompatibleRulesTestCase()
        {
            var first = GetFactRule((Fact1 _) => new FactResult(default));
            var second = GetFactRule((Fact2 _, Version1 v) => new FactResult(default));
            var wantAction = GetWantAction((FactResult _, Version1 v) => { });

            GivenCreateFacade()
                .When("Check compatible.", facade =>
                    facade.CompatibleRule(second, first, GetWantActionContext(wantAction, Container, facade)))
                .ThenIsFalse()
                .Run();
        }
    }
}
