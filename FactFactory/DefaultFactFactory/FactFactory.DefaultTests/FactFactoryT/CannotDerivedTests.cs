using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class CannotDerivedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.CannotDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive the fact through the rule with the CannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveUseRuleWithNCannotDerivedTestCase()
        {
            int value = 2;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .And("Add rule", factory =>
                {
                    factory.Rules.Add((CannotDerived<Input3Fact> _) => new Input2Fact(value));
                    factory.Rules.Add((Input2Fact fact) => new Input1Fact(fact.Value + 1));
                })
                .When("Derive fact1", factory => factory.DeriveFact<Input1Fact>())
                .Then("Check fact", fact =>
                {
                    Assert.IsNotNull(fact, "fact cannot be null");
                    Assert.AreEqual(3, fact.Value, "fact have other value");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.CannotDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive with CannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveWithCannotDerivedTestCase()
        {
            GivenCreateFactFactory()
                .AndRulesNotNul()
                .And("Add rules", factory => 
                {
                    factory.Rules.Add((Input12Fact fact) => new Input11Fact(fact.Value + 11));
                    factory.Rules.Add((Input14Fact fact, CannotDerived<Input9Fact> no) => new Input12Fact(fact.Value + 12));
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
