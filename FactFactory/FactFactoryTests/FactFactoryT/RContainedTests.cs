using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT;
using GetcuReone.FactFactory.SpecialFacts.RuntimeCondition;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace GetcuReone.FactFactoryTests.FactFactoryT
{
    /// <summary>
    /// <see cref="RContained{TFact}"/> testing class.
    /// </summary>
    [TestClass]
    public sealed class RContainedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive ResultFact if Input1Fact contain container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RContained_DeriveResultFactIfInput1FactContainedTestCase()
        {
            const int expectedValue = 1;
            ResultFact expectedFact = null;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (Input1Fact fact) => new ResultFact(fact),
                })
                .And("Want fact.", factory => factory.WantFacts((RContained<Input1Fact> _, ResultFact fact) =>
                {
                    expectedFact = fact;
                }, new Container()))
                .When("Derive facts.", factory => 
                {
                    factory.Derive();
                    return expectedFact;
                })
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive ResultFact if Input1Fact contain container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RContained_DeriveResultFactIfInput1FactContained_2_TestCase()
        {
            const int expectedValue = 1;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (RContained<Input1Fact> _, Input1Fact fact) => new ResultFact(fact)
                })
                .When("Derive facts.", factory =>
                    factory.DeriveFact<ResultFact>(new Container()))
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive fact by alternative solution.")]
        public void RContained_DeriveFactByAlternativeSolutionTestCase()
        {
            const int expectedValue = 1;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (RContained<Input2Fact> _, Input1Fact fact) => new ResultFact(fact),

                    (Input1Fact fact) => new Input3Fact(fact),
                    (Input3Fact fact) => new ResultFact(fact)
                })
                .When("Derive facts.", factory =>
                    factory.DeriveFact<ResultFact>(new Container()))
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .Run();
        }
    }
}
