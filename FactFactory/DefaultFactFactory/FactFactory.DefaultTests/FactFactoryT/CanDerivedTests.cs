using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Env;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    [Ignore]
    public sealed class CanDerivedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Successful derive CanDerived with rule for calculate.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SuccessfulDeriveCanDerivedTestCase()
        {
            Given("Create factory.", () => new FactFactoryCustom())
                .AndAddRules(new Collection
                {
                    () => new OtherFact(default),
                })
                .When("Run Derive.", factFactory => 
                    factFactory.DeriveFact<CanDerived<OtherFact>>())
                .ThenIsNotNull();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Unsuccessful derive CanDerived.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UnsuccessfulDeriveCanDerivedTestCase()
        {
            string expectedMessage = $"Failed to derive one or more facts for the action ({typeof(CanDerived<OtherFact>).Name}).";

            Given("Create factory.", () => new FactFactoryCustom())
                .When("Run Derive.", factFactory => 
                    ExpectedDeriveException(() => factFactory.DeriveFact<CanDerived<OtherFact>>()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedMessage);
        }

        [TestMethod]
        [TestCategory(TC.Objects.CanDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive the fact through the rule with the CanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveUseRuleWithCanDerivedTestCase()
        {
            const int value = 2;
            const int expectedValue = 3;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddRules(new Collection
                {
                    () => new Input3Fact(default),
                    (CanDerived<Input3Fact> _) => new Input2Fact(value),
                    (Input2Fact fact) => new Input1Fact(fact.Value + 1),
                })
                .When("Derive fact1.", factory => factory.DeriveFact<Input1Fact>())
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.CanDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive with CanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveWithCanDerivedTestCase()
        {
            const int value = 14;
            const int expectedValue = 37;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddFact(new Input14Fact(value))
                .AndAddRules(new Collection
                {
                    () => new Input9Fact(default),
                    (Input12Fact fact) => new Input11Fact(fact.Value + 11),
                    (Input14Fact fact, CanDerived<Input9Fact> no) => new Input12Fact(fact.Value + 12),
                    (Input8Fact fact) => new Input9Fact(fact.Value + 12),
                })
                .When("Derive.", factory =>
                    factory.DeriveFact<Input11Fact>())
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.CanDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive a fact using a recursive rules.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFactFromRecursiveRulesTestCase()
        {
            string expectedMessage = "Failed to derive one or more facts for the action (ResultFact).";

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (CanDerived<Input1Fact> _) => new ResultFact(default),
                    (CanDerived<ResultFact> _) => new Input1Fact(default),
                })
                .When("Derive.", factory => 
                    ExpectedDeriveException(() => factory.DeriveFact<ResultFact>()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedMessage);
        }
    }
}
