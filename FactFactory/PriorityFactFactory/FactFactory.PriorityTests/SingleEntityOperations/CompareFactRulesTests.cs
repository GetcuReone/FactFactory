using FactFactory.PriorityTests.CommonFacts;
using FactFactory.PriorityTests.SingleEntityOperations.Env;
using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.PriorityTests.SingleEntityOperations
{
    [TestClass]
    public sealed class CompareFactRulesTests : PrioritySingleEntityOperationsTestBase
    {
        public IWantActionContext Context { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Context = GetWantActionContext(
                GetWantAction((FactResult _) => { }),
                new FactContainer
                {
                    new Priority1(),
                    new Priority2(),
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(TC.Projects.Priority), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules without priority.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithoutPriorityTestCase()
        {
            var firstRule = GetFactRule((Fact1 f) => new FactResult(f));
            var secondRule = GetFactRule((Fact2 f) => new FactResult(f));
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Check method compare.", facade =>
                    facade.CompareFactRules(firstRule, secondRule, Context))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(TC.Projects.Priority), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparing rules with the same priority.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparingRulesWithSamePriorityTestCase()
        {
            var firstRule = GetFactRule((Priority1 p, Fact1 f) => new FactResult(f));
            var secondRule = GetFactRule((Priority1 p, Fact2 f) => new FactResult(f));
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Check method compare.", facade =>
                    facade.CompareFactRules(firstRule, secondRule, Context))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(TC.Projects.Priority), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with first and second priority.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithFirstAndSecondPriorityTestCase()
        {
            var firstRule = GetFactRule((Priority1 p, Fact1 f) => new FactResult(f));
            var secondRule = GetFactRule((Priority2 p, Fact2 f) => new FactResult(f));
            const int expectedValue = 1;

            GivenCreateFacade()
                .When("Check method compare.", facade =>
                    facade.CompareFactRules(firstRule, secondRule, Context))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(TC.Projects.Priority), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with second and first priority.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithSecondAndFirstPriorityTestCase()
        {
            var firstRule = GetFactRule((Priority2 p, Fact1 f) => new FactResult(f));
            var secondRule = GetFactRule((Priority1 p, Fact2 f) => new FactResult(f));
            const int expectedValue = -1;

            GivenCreateFacade()
                .When("Check method compare.", facade =>
                    facade.CompareFactRules(firstRule, secondRule, Context))
                .ThenAreEqual(expectedValue)
                .Run();
        }
    }
}
