using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedSingleEntityOperations.Env;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WAction = GetcuReone.FactFactory.Versioned.Entities.VersionedWantAction;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;
using GetcuReone.GwtTestFramework.Helpers;
using GetcuReone.FactFactory.Constants;

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
            var fact = new Fact1(default);
            fact.AddParameter(new FactParameter(VersionedFactParametersCodes.Version, new Version2()));
            Container.Add(fact);
            var rule = GetFactRule((Fact1 _) => new FactResult(default));
            var wantAction = GetWantAction((FactResult _) => { });

            GivenCreateFacade()
                .When("Check extract.", facade =>
                    facade.CanExtractFact(GetFactType<Fact1>(), rule, GetWantActionContext(wantAction, Container, facade)))
                .ThenIsTrue();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(TC.Projects.Versioned), TestCategory(GetcuReoneTC.Unit)]
        [Description("Cannot extract.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CannotExtractTestCase()
        {
            var fact = new Fact1(default);
            fact.AddParameter(new FactParameter(VersionedFactParametersCodes.Version, new Version2()));
            fact.AddParameter(new FactParameter(FactParametersCodes.CalculateByRule, true));
            Container.Add(fact);
            var rule = GetFactRule((Fact1 _, Version1 v) => new FactResult(default));
            var wantAction = GetWantAction((FactResult _) => { });

            GivenCreateFacade()
                .When("Check extract.", facade =>
                    facade.CanExtractFact(GetFactType<Fact1>(), rule, GetWantActionContext(wantAction, Container, facade)))
                .ThenIsFalse();
        }
    }
}
