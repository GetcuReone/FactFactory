using FactFactory.Facts;
using FactFactoryTests.CommonFacts;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class FactFactoryTests : TestBase
    {
        private FactFactoryT FactFactory { get; set; }

        [TestInitialize]
        public void Initialaze()
        {
            FactFactory = new FactFactoryT();
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] check method Derive")]
        public void DeriveFactFactoryTestCase()
        {
            Input16Fact fact16 = null;

            Given("Set rules", () => FactFactory.Rules.AddRange(RuleCollectionHelper.GetInputFactRules()))
                .And("Ask for a fact", _ =>
                {
                    FactFactory.WantFact((Input16Fact fact) =>
                    {
                        fact16 = fact;
                    });
                })
                .When("Derive facts", _ => FactFactory.Derive())
                .Then("Check derive facts", _ =>
                {
                    Assert.IsNotNull(fact16, "fact16 is not derived");
                    Assert.AreEqual(16, fact16.Value, "unexpected value");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] Checking for facts when deriving")]
        public void FactsWhenDeducingTestCase()
        {
            DateOfDeriveFact dateOfDeriveFact = null;

            Given("Want fact DateOfDeriveFact", () => 
            {
                FactFactory.WantFact((DateOfDeriveFact fact) => 
                {
                    dateOfDeriveFact = fact;
                });
            })
                .When("Derive facts", _ => FactFactory.Derive())
                .Then("Check derive facts", _ =>
                {
                    Assert.IsNotNull(dateOfDeriveFact, "dateOfDeriveFact is not derived");
                });
        }
    }
}
