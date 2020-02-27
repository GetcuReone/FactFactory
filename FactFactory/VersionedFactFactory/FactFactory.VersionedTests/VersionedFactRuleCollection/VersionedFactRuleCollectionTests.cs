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

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.RuleCollection)]
        [Description("Add rule")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
