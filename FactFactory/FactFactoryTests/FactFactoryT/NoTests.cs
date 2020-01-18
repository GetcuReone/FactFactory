using FactFactory.Facts;
using FactFactoryTests.CommonFacts;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class NoTests : FactFactoryTestBase
    {
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] derive the fact through the rule with the NoFact")]
        public void DeriveUseRuleWithNoFactTestCase()
        {
            int value = 2;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .And("Add rule", factory =>
                {
                    factory.Rules.Add((No<Input3Fact> _) => new Input2Fact(value));
                    factory.Rules.Add((Input2Fact fact) => new Input1Fact(fact.Value + 1));
                })
                .When("Derive fact1", factory => factory.DeriveFact<Input1Fact>())
                .Then("Check fact", fact =>
                {
                    Assert.IsNotNull(fact, "fact cannot be null");
                    Assert.AreEqual(3, fact.Value, "fact have other value");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] derive with NoFact")]
        public void DeriveWithNoFactTestCase()
        {
            GivenCreateFactFactory()
                .AndRulesNotNul()
                .And("Add rules", factory => 
                {
                    factory.Rules.Add((Input12Fact fact) => new Input11Fact(fact.Value + 11));
                    factory.Rules.Add((Input14Fact fact, No<Input9Fact> no) => new Input12Fact(fact.Value + 12));
                    factory.Rules.Add((Input8Fact fact) => new Input9Fact(fact.Value + 12));
                })
                .And("Add container", factory => factory.Container.Add(new Input14Fact(14)))
                .When("Derive", factory => factory.DeriveFact<Input11Fact>())
                .Then("Check fact", fact =>
                {
                    Assert.IsNotNull(fact, "fact cannot be null");
                    Assert.AreEqual(37, fact.Value, "fact have other value");
                });
        }
    }
}
