using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GivenWhenThen.TestAdapter;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRuleCollection;

namespace FactFactory.VersionedTests.VersionedFactRuleCollection
{
    [TestClass]
    public sealed class VersionedFactRuleCollectionTests : CommonTestBase
    {
        private GivenBlock<Collection> GivenCreateCollection()
        {
            return Given("Create collection", () => new Collection());
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][fact_rule_collection][versioned_fact_rule_collection] add rule")]
        public void AddRuleTestCase()
        {
            GivenCreateCollection()
                .When("Add rule", collection => collection.Add((Fact1 fact) => new FactResult(fact.Value)))
                .Then("Check result", collection =>
                {
                    Assert.AreEqual(1, collection.Count, "a different number of elements was expected.");
                });
        }
    }
}
