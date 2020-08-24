using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    [Ignore]
    public sealed class CannotDerivedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.CannotDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive the fact through the rule with the CannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveUseRuleWithNCannotDerivedTestCase()
        {
            const int value = 2;
            const int expectedValue = 3;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddRules(new Collection
                {
                    (CannotDerived<Input3Fact> _) => new Input2Fact(value),
                    (Input2Fact fact) => new Input1Fact(fact.Value + 1),
                })
                .When("Derive fact1.", factory => factory.DeriveFact<Input1Fact>())
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.CannotDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive with CannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveWithCannotDerivedTestCase()
        {
            const int value = 14;
            const int expectedValue = 37;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddRules(new Collection
                {
                    (Input12Fact fact) => new Input11Fact(fact.Value + 11),
                    (Input14Fact fact, CannotDerived<Input9Fact> no) => new Input12Fact(fact.Value + 12),
                    (Input8Fact fact) => new Input9Fact(fact.Value + 12)
                })
                .AndAddFact(new Input14Fact(value))
                .When("Derive.", factory => 
                    factory.DeriveFact<Input11Fact>())
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.CannotDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("We derive a fact that is calculated on the basis of an uninduced fact that is in the container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFromRuleAndWithFactInContanierTestCase()
        {
            string expectedMessage = $"Failed to derive one or more facts for the action ({typeof(ResultFact).Name}).";

            GivenCreateFactFactory()
                .AndAddFact(new Input1Fact(default))
                .AndAddRules(new Collection
                {
                    (CannotDerived<Input1Fact> _) => new ResultFact(default),
                })
                .When("Run Derive.", factFactory
                    => ExpectedDeriveException(() => factFactory.DeriveFact<ResultFact>()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedMessage);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.CannotDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive a fact using a recursive rules.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFactFromRecursiveRulesTestCase()
        {
            string expectedMessage = "Failed to derive one or more facts for the action (ResultFact).";

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (CannotDerived<Input1Fact> _) => new ResultFact(default),
                    (CannotDerived<ResultFact> _) => new Input1Fact(default),
                })
                .When("Derive.", factory => 
                    ExpectedDeriveException(() => factory.DeriveFact<ResultFact>()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedMessage);
        }
    }
}
