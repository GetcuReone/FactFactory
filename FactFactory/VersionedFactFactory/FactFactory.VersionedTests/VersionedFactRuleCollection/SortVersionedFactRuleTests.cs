using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Collection = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRuleCollection;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;

namespace FactFactory.VersionedTests.VersionedFactRuleCollection
{
    [TestClass]
    public sealed class SortVersionedFactRuleTests : VersionedFactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Sort the same rules with different versions.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SortSameRulesWithDifferentVersions_1_TestCase()
        {
            Rule firstRule = GetFactRule((Version1 _, Fact1 __) => new FactResult(default));
            Rule secondRule = GetFactRule((Version2 _, Fact1 __) => new FactResult(default));

            Given("Create collection.", () => new Collection { firstRule, secondRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check sort collection.", collection =>
                {
                    Assert.AreEqual(secondRule, collection[0]);
                    Assert.AreEqual(firstRule, collection[1]);
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Sort the same rules with different versions.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SortSameRulesWithDifferentVersions_2_TestCase()
        {
            Rule firstRule = GetFactRule((Version1 _, Fact1 __) => new FactResult(default));
            Rule secondRule = GetFactRule((Fact1 __) => new FactResult(default));

            Given("Create collection.", () => new Collection { firstRule, secondRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check sort collection.", collection =>
                {
                    Assert.AreEqual(secondRule, collection[0]);
                    Assert.AreEqual(firstRule, collection[1]);
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Sort rules with different versions.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SortRulesWithDifferentVersions_1_TestCase()
        {
            Rule firstRule = GetFactRule((Version1 _, Fact1 __) => new FactResult(default));
            Rule secondRule = GetFactRule((Version2 _, Fact2 __) => new FactResult(default));

            Given("Create collection.", () => new Collection { firstRule, secondRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check sort collection.", collection =>
                {
                    Assert.AreEqual(secondRule, collection[0]);
                    Assert.AreEqual(firstRule, collection[1]);
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Sort rules with different versions.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SortRulesWithDifferentVersions_2_TestCase()
        {
            Rule firstRule = GetFactRule((Version1 _, Fact1 __) => new FactResult(default));
            Rule secondRule = GetFactRule((Fact2 __) => new FactResult(default));

            Given("Create collection.", () => new Collection { firstRule, secondRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check sort collection.", collection =>
                {
                    Assert.AreEqual(secondRule, collection[0]);
                    Assert.AreEqual(firstRule, collection[1]);
                });
        }
    }
}
