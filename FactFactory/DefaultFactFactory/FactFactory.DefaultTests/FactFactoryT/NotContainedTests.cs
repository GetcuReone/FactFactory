using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class NotContainedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.NotContained), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rule challenge with facts NotContained.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void RunRuleWithTwoInputNotContainedFactTestCase()
        {
            int value = 24;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .And("Add rule with input NotContainedFact 1", factory => factory.Rules.Add((NotContained<Input1Fact> f) => new Input1Fact(value)))
                .And("Add rule with input NotContainedFact 2", factory => factory.Rules.Add((NotContained<Input2Fact> f) => new Input2Fact(value)))
                .And("Add rule result", factory => factory.Rules.Add((Input1Fact f1, Input2Fact f2) => new Input3Fact(f1.Value * f2.Value)))
                .When("Derive fact", factory => factory.DeriveFact<Input3Fact>())
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact, "fact cannot be null");
                    Assert.AreEqual(value * value, fact.Value, "The fact is derived incorrectly");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.NotContained), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rule challenge with fact NotContained.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void RunRuleWithInputNotContainedFactTestCase()
        {
            int value = 24;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .And("Add rule with input NotContainedFact", factory => factory.Rules.Add((NotContained<Input1Fact> f) => new Input1Fact(value)))
                .When("Derive fact", factory => factory.DeriveFact<Input1Fact>())
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact, "fact cannot be null");
                    Assert.AreEqual(value, fact.Value, "The fact is derived incorrectly");
                });
        }
    }
}
