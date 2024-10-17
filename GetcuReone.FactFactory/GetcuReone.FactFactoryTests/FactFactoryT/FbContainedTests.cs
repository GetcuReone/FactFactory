using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace GetcuReone.FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class FbContainedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.BuildContained), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a ResultFact if the Input1Fact is contained in the container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateResultFactIfInput1FactContainedTestCase()
        {
            const int expectedValue = 1;
            var container = new Container
            {
                new Input1Fact(expectedValue),
            };

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (FbContained<Input1Fact> _, Input1Fact fact) => new ResultFact(fact.Value),
                    (FbNotContained<Input1Fact> _) => new ResultFact(-1),
                })
                .When("Derive.", factFactory =>
                    factFactory.DeriveFact<ResultFact>(container))
                .ThenFactValueEquals(expectedValue)
                .Run();
        }
    }
}
