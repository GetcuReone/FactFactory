using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedSingleEntityOperations.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;

namespace FactFactory.VersionedTests.VersionedSingleEntityOperations
{
    [TestClass]
    public sealed class CanExtractFactTests : VersionedSingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(TC.Projects.Versioned), TestCategory(GetcuReoneTC.Unit)]
        [Description("Can extract.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CanExtractTestCase()
        {
            var fact = new Fact1(default)
                .SetCalculateByRuleParam()
                .SetVersionParam(new Version2());
            Container.Add(fact);
            var rule = GetFactRule((Fact1 _) => new FactResult(default));
            var wantAction = GetWantAction((FactResult _) => { });

            GivenCreateFacade()
                .When("Check extract.", facade =>
                    facade.CanExtractFact(GetFactType<Fact1>(), rule, GetWantActionContext(wantAction, Container, facade)))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(TC.Projects.Versioned), TestCategory(GetcuReoneTC.Unit)]
        [Description("Cannot extract.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CannotExtractTestCase()
        {
            var fact = new Fact1(default)
                .SetCalculateByRuleParam()
                .SetVersionParam(new Version2());
            Container.Add(fact);
            var rule = GetFactRule((Fact1 _, Version1 v) => new FactResult(default));
            var wantAction = GetWantAction((FactResult _, Version1 v) => { });

            GivenCreateFacade()
                .When("Check extract.", facade =>
                    facade.CanExtractFact(GetFactType<Fact1>(), rule, GetWantActionContext(wantAction, Container, facade)))
                .ThenIsFalse()
                .Run();
        }
    }
}
