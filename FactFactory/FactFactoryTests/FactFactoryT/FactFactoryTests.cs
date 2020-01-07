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
        public void DeriveTestCase()
        {
            Input16Fact fact16 = null;

            Given("Set rules", () => FactFactory.FactRuleCollection.AddRange(RuleCollectionHelper.GetInputFactRules()))
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
    }
}
