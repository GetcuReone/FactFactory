using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.SpecialFacts.RuntimeCondition;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace GetcuReone.FactFactoryTests.FactFactoryT
{
    /// <summary>
    /// <see cref="FrCanDerived{TFact}"/> testing class.
    /// </summary>
    [TestClass]
    public sealed class FrCanDerivedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive ResultFact if Input2Fact can derived.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RCanDerived_TestCase()
        {
            const int expectedValue = 1;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (FrCanDerived<Input2Fact> _, Input1Fact fact) => new ResultFact(fact),
                    () => new Input2Fact(default),
                })
                .When("Derive facts.", factory =>
                    factory.DeriveFact<ResultFact>(new Container()))
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .Run();
        }
    }
}
