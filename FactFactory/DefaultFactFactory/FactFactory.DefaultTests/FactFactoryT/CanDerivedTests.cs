using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Env;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class CanDerivedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Successful derive CanDerived with rule for calculate.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SuccessfulDeriveCanDerivedTestCase()
        {
            Given("Create factory", () => new FactFactoryCustom())
                .AndAddRules(new Collection
                {
                    () => new OtherFact(default),
                })
                .When("Run Derive", factFactory => 
                    factFactory.DeriveFact<CanDerived<OtherFact>>())
                .Then("Check fact", fact => 
                    Assert.IsNotNull(fact, "Fact can be null"));
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Unsuccessful derive CanDerived.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UnsuccessfulDeriveCanDerivedTestCase()
        {
            string expectedMessage = $"Failed to calculate one or more facts for the action ({typeof(CanDerived<OtherFact>).Name}).";

            Given("Create factory", () => new FactFactoryCustom())
                .When("Run Derive", factFactory 
                    => ExpectedDeriveException(() => factFactory.DeriveFact<CanDerived<OtherFact>>()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotCalculated, expectedMessage);
        }

        [TestMethod]
        [TestCategory(TC.Objects.CanDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive the fact through the rule with the CanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveUseRuleWithCanDerivedTestCase()
        {
            int value = 2;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddRules(new Collection 
                {
                    () => new Input3Fact(default),
                    (CanDerived<Input3Fact> _) => new Input2Fact(value),
                    (Input2Fact fact) => new Input1Fact(fact.Value + 1),
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
