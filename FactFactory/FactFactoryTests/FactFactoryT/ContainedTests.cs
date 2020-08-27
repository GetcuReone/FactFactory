using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
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
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateResultFactIfInput1FactContainedTestCase()
        {
            const int expectedValue = 1;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (Contained<Input1Fact> _, Input1Fact fact) => new ResultFact(fact.Value),
                    (NotContained<Input1Fact> _) => new ResultFact(-1),
                })
                .AndAddFact(new Input1Fact(expectedValue))
                .When("Derive.", factFactory => 
                    factFactory.DeriveFact<ResultFact>())
                .ThenFactEquals(expectedValue);
        }
    }
}
