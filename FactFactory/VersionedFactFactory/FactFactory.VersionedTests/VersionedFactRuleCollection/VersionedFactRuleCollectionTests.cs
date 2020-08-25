using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactRuleCollection.Env;
using GetcuReone.FactFactory.Entities;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactory.VersionedTests.VersionedFactRuleCollection
{
    [TestClass]
    public sealed class VersionedFactRuleCollectionTests : VersionedFactRuleCollectionTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add rule.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleTestCase()
        {
            GivenCreateCollection()
                .When("Add rule.", collection => 
                    collection.Add((Fact1 fact) => new FactResult(fact.Value)))
                .Then("Check result.", collection =>
                {
                    Assert.AreEqual(1, collection.Count, "a different number of elements was expected.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get copied collection.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Versioned_GetCopiedCollectionTestCase()
        {
            Collection originalsCollection = null;
            FactRule factRule = null;

            Given("Create collection.", () => originalsCollection = new Collection())
                .And("Create rule", () => 
                    factRule = GetFactRule(() => new Fact1(default)))
                .And("Add rule.", _ => 
                    originalsCollection.Add(factRule))
                .When("Get copied.", _ => 
                    originalsCollection.Copy())
                .ThenIsNotNull()
                .AndAreNotEqual(originalsCollection)
                .And("Check result.", copyCollection =>
                {
                    Assert.AreEqual(originalsCollection.Count(), copyCollection.Count(), "Collections should have the same amount of rules");

                    Assert.AreEqual(factRule, copyCollection[0], "The collection contains another rule.");
                });
        }
    }
}
