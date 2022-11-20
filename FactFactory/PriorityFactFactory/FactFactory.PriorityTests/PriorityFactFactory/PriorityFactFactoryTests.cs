using FactFactory.PriorityTests.CommonFacts;
using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

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
            var container = new Container
            {
                new Fact1(1),
            };

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (Fact1 f) => new FactResult(f),
                    (Priority1 p, Fact1 f) => new FactResult(f + p),
                })
                .When("Derive fact.", factory =>
                    factory.DeriveFact<FactResult>(container))
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Projects.Priority), TestCategory(GetcuReoneTC.Unit)]
        [Description("Use a higher priority right.")]
        //[Timeout(Timeouts.Second.One)]
        public void UseHigherPriorityRightTestCase()
        {
            const long expectedValue = 2;
            var container = new Container
            {
                new Fact1(1),
            };

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (Priority2 p, Fact1 f) => new FactResult(f),
                    (Priority1 p, Fact1 f) => new FactResult(f + p),
                })
                .When("Derive fact.", factory =>
                    factory.DeriveFact<FactResult>(container))
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .Run();
        }
    }
}
