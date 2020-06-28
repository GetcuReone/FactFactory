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
    }
}
