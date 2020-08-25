using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedSingleEntityOperations.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FactFactory.VersionedTests.VersionedSingleEntityOperations
{
    [TestClass]
    public sealed class GetRequiredTypesOfFactsTests : VersionedSingleEntityOperationsTestBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();

            var fact = new Fact1(default).SetCalculateByRuleParam().SetVersionParam(new Version2());
            Container.Add(fact);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(TC.Projects.Versioned), TestCategory(GetcuReoneTC.Unit)]
        [Description("Not required fact 1.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void NotRequiredFact1TestCase()
        {
            var rule = GetFactRule((Fact1 _) => new FactResult(default));
            var wantAction = GetWantAction((FactResult _) => { });

            GivenCreateFacade()
                .When("Check method.", facade =>
                    facade.GetRequiredTypesOfFacts(rule, GetWantActionContext(wantAction, Container, facade)))
                .ThenIsNotNull()
                .And("Check result.", types =>
                {
                    Assert.AreEqual(0, types.Count());
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(TC.Projects.Versioned), TestCategory(GetcuReoneTC.Unit)]
        [Description("Required fact 1.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RequiredFact1TestCase()
        {
            var rule = GetFactRule((Fact1 _, Version1 v) => new FactResult(default));
            var wantAction = GetWantAction((FactResult _, Version1 v) => { });

            GivenCreateFacade()
                .When("Check method.", facade =>
                    facade.GetRequiredTypesOfFacts(rule, GetWantActionContext(wantAction, Container, facade)))
                .ThenIsNotNull()
                .And("Check result.", types =>
                {
                    Assert.AreEqual(1, types.Count());
                    Assert.IsTrue(types.First().IsFactType<Fact1>());
                });
        }
    }
}
