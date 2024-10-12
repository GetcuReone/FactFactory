using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.FactFactory.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class BuildCannotDerivedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.BuildCannotDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive the fact through the rule with the BuildCannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveUseRuleWithBuildCannotDerivedTestCase()
        {
            const int value = 2;
            const int expectedValue = 3;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddRules(new Collection
                {
                    (BuildCannotDerived<Input3Fact> _) => new Input2Fact(value),
                    (Input2Fact fact) => new Input1Fact(fact.Value + 1),
                })
                .When("Derive fact1.", factory => factory.DeriveFact<Input1Fact>())
                .ThenFactValueEquals(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.BuildCannotDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive with BuildCannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveWithBuildCannotDerivedTestCase()
        {
            const int value = 14;
            const int expectedValue = 37;
            var container = new Container
            {
                new Input14Fact(value),
            };

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddRules(new Collection
                {
                    (Input12Fact fact) => new Input11Fact(fact.Value + 11),
                    (Input14Fact fact, BuildCannotDerived<Input9Fact> no) => new Input12Fact(fact.Value + 12),
                    (Input8Fact fact) => new Input9Fact(fact.Value + 12)
                })
                .When("Derive.", factory => 
                    factory.DeriveFact<Input11Fact>(container))
                .ThenFactValueEquals(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.BuildCannotDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("We derive a fact that is calculated on the basis of an uninduced fact that is in the container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFromRuleAndWithFactInContanierTestCase()
        {
            string expectedMessage = $"Failed to derive one or more facts for the action ({typeof(ResultFact).Name}).";
            var container = new Container
            {
                new Input1Fact(default),
            };

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (BuildCannotDerived<Input1Fact> _) => new ResultFact(default),
                })
                .When("Run Derive.", factFactory
                    => ExpectedDeriveException(() => factFactory.DeriveFact<ResultFact>(container)))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.BuildCannotDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive a fact using a recursive rules.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFactFromRecursiveRulesTestCase()
        {
            string expectedMessage = "Failed to derive one or more facts for the action (ResultFact).";

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (BuildCannotDerived<Input1Fact> _) => new ResultFact(default),
                    (BuildCannotDerived<ResultFact> _) => new Input1Fact(default),
                })
                .When("Derive.", factory => 
                    ExpectedDeriveException(() => factory.DeriveFact<ResultFact>()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedMessage)
                .Run();
        }
    }
}
