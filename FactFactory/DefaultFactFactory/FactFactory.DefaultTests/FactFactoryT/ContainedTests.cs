using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class ContainedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Contained), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a ResultFact if the Input1Fact is contained in the container.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void CreateResultFactIfInput1FactContainedTestCase()
        {
            GivenCreateFactFactory()
                .AndAddRules(new Collection 
                {
                    (Contained<Input1Fact> _, Input1Fact fact) => new ResultFact(fact.Value),
                    (NotContained<Input1Fact> _) => new ResultFact(-1),
                })
                .AndAddFact(new Input1Fact(1))
                .When("Derive", factFactory => factFactory.DeriveFact<ResultFact>())
                .Then("Check result", fact => 
                {
                    Assert.AreEqual(1, fact.Value, "Expected another value");
                });
        }
    }
}
