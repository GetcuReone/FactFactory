using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class NotContainedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.NotContained), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rule challenge with facts NotContained.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RunRuleWithTwoInputNotContainedFactTestCase()
        {
            const int value = 24;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddRules(new Collection
                {
                    (NotContained<Input1Fact> f) => new Input1Fact(value),
                    (NotContained<Input2Fact> f) => new Input2Fact(value),
                    (Input1Fact f1, Input2Fact f2) => new Input3Fact(f1 * f2),
                })
                .When("Derive fact.", factory =>
                    factory.DeriveFact<Input3Fact>())
                .ThenFactEquals(value * value);
        }

        [TestMethod]
        [TestCategory(TC.Objects.NotContained), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rule challenge with fact NotContained.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RunRuleWithInputNotContainedFactTestCase()
        {
            const int expectedValue = 24;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddRules(new Collection
                {
                    (NotContained<Input1Fact> f) => new Input1Fact(expectedValue),
                })
                .When("Derive fact", factory => 
                    factory.DeriveFact<Input1Fact>())
                .ThenFactEquals(expectedValue);
        }
    }
}
