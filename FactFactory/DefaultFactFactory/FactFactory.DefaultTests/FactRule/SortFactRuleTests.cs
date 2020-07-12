using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using System.Linq;
using FactFactory.DefaultTests.CommonFacts;

namespace FactFactory.DefaultTests.FactRule
{
    [TestClass]
    public sealed class SortFactRuleTests : FactRuleTestBase
    {
        
        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Sort by the minimum number of facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SortByMinimumNumberOfFactsTestCase()
        {
            Rule firstRule = GetFactRule((Input1Fact _, Input2Fact __, Input3Fact ___) => new ResultFact(default));
            Rule secondRule = GetFactRule((Input1Fact _) => new ResultFact(default));
            Rule thirdRule = GetFactRule((Input1Fact _, Input2Fact __) => new ResultFact(default));

            Given("Create rule collection.", () => new Collection { firstRule, secondRule, thirdRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check result.", collection =>
                {
                    Assert.AreEqual(secondRule, collection[0]);
                    Assert.AreEqual(thirdRule, collection[1]);
                    Assert.AreEqual(firstRule, collection[2]);
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first rule with conditon facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FirstRuleWithConditionFactsTestCase()
        {
            Rule firstRule = GetFactRule((Input1Fact _, Input2Fact __, Input3Fact ___) => new ResultFact(default));
            Rule secondRule = GetFactRule(() => new ResultFact(default));
            Rule thirdRule = GetFactRule((Input1Fact _, Condition_ContainedOtherFact __) => new ResultFact(default));

            Given("Create rule collection.", () => new Collection { firstRule, secondRule, thirdRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check result.", collection =>
                {
                    Assert.AreEqual(thirdRule, collection[0]);
                    Assert.AreEqual(secondRule, collection[1]);
                    Assert.AreEqual(firstRule, collection[2]);
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first and second rules with conditon facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FirstAndSecondRulesWithConditionFactsTestCase()
        {
            Rule firstRule = GetFactRule((Condition_ContainedOtherFact _, Input2Fact __, Input3Fact ___) => new ResultFact(default));
            Rule secondRule = GetFactRule(() => new ResultFact(default));
            Rule thirdRule = GetFactRule((Input1Fact _, Condition_ContainedOtherFact __) => new ResultFact(default));

            Given("Create rule collection.", () => new Collection { firstRule, secondRule, thirdRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check result.", collection =>
                {
                    Assert.AreEqual(thirdRule, collection[0]);
                    Assert.AreEqual(firstRule, collection[1]);
                    Assert.AreEqual(secondRule, collection[2]);
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first and second rules with conditon facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FirstAndSecondRulesWithConditionFacts_2_TestCase()
        {
            Rule firstRule = GetFactRule((Condition_ContainedOtherFact _, Condition_ContainedOtherFact __, Input3Fact ___) => new ResultFact(default));
            Rule secondRule = GetFactRule(() => new ResultFact(default));
            Rule thirdRule = GetFactRule((Input1Fact _, Condition_ContainedOtherFact __) => new ResultFact(default));

            Given("Create rule collection.", () => new Collection { firstRule, secondRule, thirdRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check result.", collection =>
                {
                    Assert.AreEqual(firstRule, collection[0]);
                    Assert.AreEqual(thirdRule, collection[1]);
                    Assert.AreEqual(secondRule, collection[2]);
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first rule with conditon facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FirstRuleWithSpecialFactsTestCase()
        {
            Rule firstRule = GetFactRule((Input1Fact _, Input2Fact __, Input3Fact ___) => new ResultFact(default));
            Rule secondRule = GetFactRule(() => new ResultFact(default));
            Rule thirdRule = GetFactRule((Input1Fact _, SpecialFact __) => new ResultFact(default));

            Given("Create rule collection.", () => new Collection { firstRule, secondRule, thirdRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check result.", collection =>
                {
                    Assert.AreEqual(thirdRule, collection[0]);
                    Assert.AreEqual(secondRule, collection[1]);
                    Assert.AreEqual(firstRule, collection[2]);
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first and second rules with conditon facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FirstAndSecondRulesWithSpecialFactsTestCase()
        {
            Rule firstRule = GetFactRule((SpecialFact _, Input2Fact __, Input3Fact ___) => new ResultFact(default));
            Rule secondRule = GetFactRule(() => new ResultFact(default));
            Rule thirdRule = GetFactRule((Input1Fact _, SpecialFact __) => new ResultFact(default));

            Given("Create rule collection.", () => new Collection { firstRule, secondRule, thirdRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check result.", collection =>
                {
                    Assert.AreEqual(thirdRule, collection[0]);
                    Assert.AreEqual(firstRule, collection[1]);
                    Assert.AreEqual(secondRule, collection[2]);
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first and second rules with special facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FirstAndSecondRulesWithSpecialFacts_2_TestCase()
        {
            Rule firstRule = GetFactRule((SpecialFact _, SpecialFact __, Input3Fact ___) => new ResultFact(default));
            Rule secondRule = GetFactRule(() => new ResultFact(default));
            Rule thirdRule = GetFactRule((Input1Fact _, SpecialFact __) => new ResultFact(default));

            Given("Create rule collection.", () => new Collection { firstRule, secondRule, thirdRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check result.", collection =>
                {
                    Assert.AreEqual(firstRule, collection[0]);
                    Assert.AreEqual(thirdRule, collection[1]);
                    Assert.AreEqual(secondRule, collection[2]);
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("The second with special facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SecondRuleWithSpecialFactsTestCase()
        {
            Rule firstRule = GetFactRule((Input1Fact _, Input2Fact __, SpecialFact ___) => new ResultFact(default));
            Rule secondRule = GetFactRule(() => new ResultFact(default));
            Rule thirdRule = GetFactRule((Input1Fact _, Condition_ContainedOtherFact __) => new ResultFact(default));

            Given("Create rule collection.", () => new Collection { firstRule, secondRule, thirdRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check result.", collection =>
                {
                    Assert.AreEqual(thirdRule, collection[0]);
                    Assert.AreEqual(firstRule, collection[1]);
                    Assert.AreEqual(secondRule, collection[2]);
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("The first rule without facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FirstRuleWithoutFactsTestCase()
        {
            Rule firstRule = GetFactRule((Input1Fact _, Input2Fact __, Input3Fact ___) => new ResultFact(default));
            Rule secondRule = GetFactRule(() => new ResultFact(default));
            Rule thirdRule = GetFactRule((Input1Fact _, Input2Fact __) => new ResultFact(default));

            Given("Create rule collection.", () => new Collection { firstRule, secondRule, thirdRule })
                .When("Sort.", collection =>
                    collection.OrderByDescending(r => r, Comparer).ToList())
                .Then("Check result.", collection =>
                {
                    Assert.AreEqual(secondRule, collection[0]);
                    Assert.AreEqual(thirdRule, collection[1]);
                    Assert.AreEqual(firstRule, collection[2]);
                });
        }
    }
}
