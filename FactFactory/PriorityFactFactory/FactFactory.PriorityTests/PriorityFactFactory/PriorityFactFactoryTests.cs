using FactFactory.PriorityTests.CommonFacts;
using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactory.PriorityTests.PriorityFactFactory
{
    [TestClass]
    public sealed class PriorityFactFactoryTests : Env.PriorityFactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Projects.Priority), TestCategory(GetcuReoneTC.Unit)]
        [Description("Calculate fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UsePriorityRuleTestCase()
        {
            const long expectedValue = 2;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (Fact1 f) => new FactResult(f),
                    (Priority1 p, Fact1 f) => new FactResult(f + p),
                })
                .AndAddFact(new Fact1(1))
                .When("Derive fact.", factory =>
                    factory.DeriveFact<FactResult>())
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Projects.Priority), TestCategory(GetcuReoneTC.Unit)]
        [Description("Use a higher priority right.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UseHigherPriorityRightTestCase()
        {
            const long expectedValue = 2;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (Priority2 p, Fact1 f) => new FactResult(f),
                    (Priority1 p, Fact1 f) => new FactResult(f + p),
                })
                .AndAddFact(new Fact1(1))
                .When("Derive fact.", factory =>
                    factory.DeriveFact<FactResult>())
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue);
        }
    }
}
