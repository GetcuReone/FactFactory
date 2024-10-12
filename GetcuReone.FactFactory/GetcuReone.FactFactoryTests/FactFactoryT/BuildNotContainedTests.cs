using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class BuildNotContainedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.BuildNotContained), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rule challenge with facts BuildNotContained.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RunRuleWithTwoInputBuildNotContainedFactTestCase()
        {
            const int value = 24;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddRules(new Collection
                {
                    (BuildNotContained<Input1Fact> f) => new Input1Fact(value),
                    (BuildNotContained<Input2Fact> f) => new Input2Fact(value),
                    (Input1Fact f1, Input2Fact f2) => new Input3Fact(f1 * f2),
                })
                .When("Derive fact.", factory =>
                    factory.DeriveFact<Input3Fact>())
                .ThenFactValueEquals(value * value)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.BuildNotContained), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rule challenge with fact BuildNotContained.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RunRuleWithInputBuildNotContainedFactTestCase()
        {
            const int expectedValue = 24;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddRules(new Collection
                {
                    (BuildNotContained<Input1Fact> f) => new Input1Fact(expectedValue),
                })
                .When("Derive fact", factory => 
                    factory.DeriveFact<Input1Fact>())
                .ThenFactValueEquals(expectedValue)
                .Run();
        }
    }
}
