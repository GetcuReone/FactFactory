using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;

namespace FactFactory.VersionedTests.VersionedFactRule
{
    [TestClass]
    public sealed class VersionedFactRuleTests : TestBase
    {
        private IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][versioned][rule] create rule with version")]
        public void CreateRuleWithVersionTestCase()
        {
            GivenEmpty()
                .When("Create rule with version", _ => VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<V1>(), GetFactType<Fact1>()))
                .Then("Check result", rule =>
                {
                    Assert.IsNotNull(rule.TypeFactVersion, "The rule does not contain version information");
                    Assert.IsTrue(GetFactType<V1>().Compare(rule.TypeFactVersion), $"{nameof(Rule.TypeFactVersion)} does not store version information");
                });
        }

        //[Timeout(Timeouts.MilliSecond.Hundred)]
        //[TestMethod]
        //[Description("[fact][versioned][rule] create rule without version")]
        //public void CreateRuleWithoutVersionTestCase()
        //{
        //    GivenEmpty()
        //        .When("Create rule with version", _ => VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Fact1>()))
        //        .Then("Check result", rule =>
        //        {
        //            Assert.IsNull(rule.TypeFactVersion, "The rule contain version information");
        //        });
        //}

        //[Timeout(Timeouts.MilliSecond.Hundred)]
        //[TestMethod]
        //[Description("[fact][versioned][rule] compare the same rules without versions")]
        //public void CompareSameRulesWithoutVersionsTestCase()
        //{
        //    Rule firstRule = null;
        //    Rule secondRule = null;

        //    Given("Create first rule", () => firstRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Fact1>()))
        //        .And("Create second rule", _ => secondRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Fact1>()))
        //        .And("Compare rules", _ => Assert.IsTrue(firstRule.Compare(secondRule), "rules are not equal"))
        //        .When("Compare rules without version", _ => firstRule.CompareWithoutVersion(secondRule))
        //        .Then("Check result", result => Assert.IsTrue(result, "excluding versions, the rules are not equal"));
        //}

        //[Timeout(Timeouts.MilliSecond.Hundred)]
        //[TestMethod]
        //[Description("[fact][versioned][rule] compare the same rules with versions")]
        //public void CompareSameRulesWithVersionsTestCase()
        //{
        //    Rule firstRule = null;
        //    Rule secondRule = null;

        //    Given("Create first rule", () => firstRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<V1>(), GetFactType<Fact1>()))
        //        .And("Create second rule", _ => secondRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<V1>(), GetFactType<Fact1>()))
        //        .And("Compare rules", _ => Assert.IsTrue(firstRule.Compare(secondRule), "rules are not equal"))
        //        .When("Compare rules without version", _ => firstRule.CompareWithoutVersion(secondRule))
        //        .Then("Check result", result => Assert.IsTrue(result, "excluding versions, the rules are not equal"));
        //}

        //[Timeout(Timeouts.MilliSecond.Hundred)]
        //[TestMethod]
        //[Description("[fact][versioned][rule] compare the same rules with different versions")]
        //public void CompareSameRulesWithDifferentVersionsTestCase()
        //{
        //    Rule firstRule = null;
        //    Rule secondRule = null;

        //    Given("Create first rule", () => firstRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<V1>(), GetFactType<Fact1>()))
        //        .And("Create second rule", _ => secondRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<V2>(), GetFactType<Fact1>()))
        //        .And("Compare rules", _ => Assert.IsFalse(firstRule.Compare(secondRule), "rules are not equal"))
        //        .When("Compare rules without version", _ => firstRule.CompareWithoutVersion(secondRule))
        //        .Then("Check result", result => Assert.IsTrue(result, "excluding versions, the rules are not equal"));
        //}

        //[Timeout(Timeouts.MilliSecond.Hundred)]
        //[TestMethod]
        //[Description("[fact][versioned][rule] comparison of the same rules where one without version")]
        //public void ComparisonSameRulesWhereOneWithoutVersionTestCase()
        //{
        //    Rule firstRule = null;
        //    Rule secondRule = null;

        //    Given("Create first rule", () => firstRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<V1>(), GetFactType<Fact1>()))
        //        .And("Create second rule", _ => secondRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Fact1>()))
        //        .And("Compare rules", _ => Assert.IsFalse(firstRule.Compare(secondRule), "rules are not equal"))
        //        .When("Compare rules without version", _ => firstRule.CompareWithoutVersion(secondRule))
        //        .Then("Check result", result => Assert.IsTrue(result, "excluding versions, the rules are not equal"));
        //}
    }
}
