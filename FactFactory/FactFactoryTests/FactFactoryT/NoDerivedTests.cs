using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Facts;
using GivenWhenThen.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class NoDerivedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.NoDerived), TestCategory(TC.Objects.Factory)]
        [Description("Derive the fact through the rule with the NoDerived fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DeriveUseRuleWithNoFactTestCase()
        {
            int value = 2;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .And("Add rule", factory =>
                {
                    factory.Rules.Add((NoDerived<Input3Fact> _) => new Input2Fact(value));
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
        [TestCategory(TC.Objects.NoDerived), TestCategory(TC.Objects.Factory)]
        [Description("Derive with NoDerived fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DeriveWithNoFactTestCase()
        {
            GivenCreateFactFactory()
                .AndRulesNotNul()
                .And("Add rules", factory => 
                {
                    factory.Rules.Add((Input12Fact fact) => new Input11Fact(fact.Value + 11));
                    factory.Rules.Add((Input14Fact fact, NoDerived<Input9Fact> no) => new Input12Fact(fact.Value + 12));
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
