using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Env;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public void SuccessfulDeriveNoDerivedTestCase()
        {
            Given("Create factory", () => new FactFactoryCustom())
                .AndAddRules(new Collection
                {
                    () => new OtherFact(DateTime.Now),
                })
                .When("Run Derive", factFactory => 
                    factFactory.DeriveFact<CanDerived<OtherFact>>())
                .Then("Check fact", fact => 
                    Assert.IsNotNull(fact, "Fact can be null"));
        }
    }
}
