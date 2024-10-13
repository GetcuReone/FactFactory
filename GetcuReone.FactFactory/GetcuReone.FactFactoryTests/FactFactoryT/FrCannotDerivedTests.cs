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
    /// <see cref="FrCannotDerived{TFact}"/> testing class.
    /// </summary>
    [TestClass]
    public sealed class FrCannotDerivedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive ResultFact if Input2Fact cannot derived.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RCannotDerived_TestCase()
        {
            const int expectedValue = 1;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (FrCannotDerived<Input2Fact> _, Input1Fact fact) => new ResultFact(fact)
                })
                .When("Derive facts.", factory =>
                    factory.DeriveFact<ResultFact>(new Container()))
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .Run();
        }
    }
}
