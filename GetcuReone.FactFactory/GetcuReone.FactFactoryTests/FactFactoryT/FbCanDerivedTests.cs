using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Env;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace GetcuReone.FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class FbCanDerivedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.BuildCanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Successful derive BuildCanDerived with rule for calculate.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SuccessfulDeriveBuildCanDerivedTestCase()
        {
            Given("Create factory.", () => (IFactFactory)new FactFactoryCustom())
                .AndAddRules(new Collection
                {
                    () => new OtherFact(default),
                })
                .When("Run Derive.", factFactory =>
                    factFactory.DeriveFact<FbCanDerived<OtherFact>>())
                .ThenIsNotNull()
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.BuildCanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Unsuccessful derive BuildCanDerived.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UnsuccessfulDeriveBuildCanDerivedTestCase()
        {
            string expectedMessage = $"Failed to derive one or more facts for the action ({typeof(FbCanDerived<OtherFact>).Name}).";

            Given("Create factory.", () => (IFactFactory)new FactFactoryCustom())
                .When("Run Derive.", factFactory =>
                    ExpectedDeriveException(() => factFactory.DeriveFact<FbCanDerived<OtherFact>>()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.BuildCanDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive the fact through the rule with the BuildCanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveUseRuleWithBuildCanDerivedTestCase()
        {
            const int value = 2;
            const int expectedValue = 3;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddRules(new Collection
                {
                    () => new Input3Fact(default),
                    (FbCanDerived<Input3Fact> _) => new Input2Fact(value),
                    (Input2Fact fact) => new Input1Fact(fact.Value + 1),
                })
                .When("Derive fact1.", factory => factory.DeriveFact<Input1Fact>())
                .ThenFactValueEquals(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.BuildCanDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive with BuildCanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveWithBuildCanDerivedTestCase()
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
                    () => new Input9Fact(default),
                    (Input12Fact fact) => new Input11Fact(fact.Value + 11),
                    (Input14Fact fact, FbCanDerived<Input9Fact> no) => new Input12Fact(fact.Value + 12),
                    (Input8Fact fact) => new Input9Fact(fact.Value + 12),
                })
                .When("Derive.", factory =>
                    factory.DeriveFact<Input11Fact>(container))
                .ThenFactValueEquals(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.BuildCanDerived), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive a fact using a recursive rules.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFactFromRecursiveRulesTestCase()
        {
            string expectedMessage = "Failed to derive one or more facts for the action (ResultFact).";

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (FbCanDerived<Input1Fact> _) => new ResultFact(default),
                    (FbCanDerived<ResultFact> _) => new Input1Fact(default),
                })
                .When("Derive.", factory =>
                    ExpectedDeriveException(() => factory.DeriveFact<ResultFact>()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedMessage)
                .Run();
        }
    }
}
