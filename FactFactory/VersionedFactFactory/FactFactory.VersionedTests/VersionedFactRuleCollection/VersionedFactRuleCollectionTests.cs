using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned;
using GivenWhenThen.TestAdapter;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Collection = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRuleCollection;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;

namespace FactFactory.VersionedTests.VersionedFactRuleCollection
{
    [TestClass]
    public sealed class VersionedFactRuleCollectionTests : CommonTestBase<VersionedFactBase>
    {
        private GivenBlock<Collection> GivenCreateCollection()
        {
            return Given("Create collection", () => new Collection());
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.RuleCollection)]
        [Description("Add rule.")]
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

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Get copied collection.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void Versioned_GetCopiedCollectionTestCase()
        {
            Collection originalsCollection = null;
            Rule factRule = null;

            Given("Create collection", () => originalsCollection = new Collection())
                .And("Create rule", () => factRule = new Rule(ct => default, new List<IFactType>(), GetFactType<Fact1>()))
                .And("Add rule", _ => originalsCollection.Add(factRule))
                .When("Get copied", _ => originalsCollection.Copy())
                .Then("Check result", copyCollection =>
                {
                    Assert.IsNotNull(copyCollection, "collection cannot be null");
                    Assert.AreNotEqual(originalsCollection, copyCollection, "Collections should not be equal");
                    Assert.AreEqual(originalsCollection.Count(), copyCollection.Count(), "Collections should have the same amount of rules");

                    Assert.AreEqual(factRule, copyCollection[0], "The collection contains another rule.");
                });
        }
    }
}
