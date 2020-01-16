using FactFactory.Facts;
using FactFactoryTests.CommonFacts;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class FactFactoryNoTests : FactFactoryTestBase
    {
        //[Timeout(Timeouits.MilliSecond.Hundred)]
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
    }
}
