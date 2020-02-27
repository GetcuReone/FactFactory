﻿using FactFactory.VersionedTests.CommonFacts;
using FactFactoryTestsCommon;
using GetcuReone.FactFactory.Interfaces;
using GivenWhenThen.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;

namespace FactFactory.VersionedTests.VersionedFactRule
{
    [TestClass]
    public sealed class VersionedFactRuleTests : CommonTestBase
    {
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][rule] create rule with version")]
        public void CreateRuleWithVersionTestCase()
        {
            GivenEmpty()
                .When("Create rule with version", _ => VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Version1>(), GetFactType<Fact1>()))
                .Then("Check result", rule =>
                {
                    Assert.IsNotNull(rule.VersionType, "The rule does not contain version information");
                    Assert.IsTrue(GetFactType<Version1>().Compare(rule.VersionType), $"{nameof(Rule.VersionType)} does not store version information");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][rule] create rule without version")]
        public void CreateRuleWithoutVersionTestCase()
        {
            GivenEmpty()
                .When("Create rule with version", _ => VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Fact1>()))
                .Then("Check result", rule =>
                {
                    Assert.IsNull(rule.VersionType, "The rule contain version information");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][rule] compare the same rules without versions")]
        public void CompareSameRulesWithoutVersionsTestCase()
        {
            Rule firstRule = null;
            Rule secondRule = null;

            Given("Create first rule", () => firstRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Fact1>()))
                .And("Create second rule", _ => secondRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Fact1>()))
                .And("Compare rules", _ => Assert.IsTrue(firstRule.Compare(secondRule), "rules are not equal"))
                .When("Compare rules without version", _ => firstRule.CompareWithoutVersion(secondRule))
                .Then("Check result", result => Assert.IsTrue(result, "excluding versions, the rules are not equal"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][rule] compare the same rules with versions")]
        public void CompareSameRulesWithVersionsTestCase()
        {
            Rule firstRule = null;
            Rule secondRule = null;

            Given("Create first rule", () => firstRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Version1>(), GetFactType<Fact1>()))
                .And("Create second rule", _ => secondRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Version1>(), GetFactType<Fact1>()))
                .And("Compare rules", _ => Assert.IsTrue(firstRule.Compare(secondRule), "rules are not equal"))
                .When("Compare rules without version", _ => firstRule.CompareWithoutVersion(secondRule))
                .Then("Check result", result => Assert.IsTrue(result, "excluding versions, the rules are not equal"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][rule] compare the same rules with different versions")]
        public void CompareSameRulesWithDifferentVersionsTestCase()
        {
            Rule firstRule = null;
            Rule secondRule = null;

            Given("Create first rule", () => firstRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Version1>(), GetFactType<Fact1>()))
                .And("Create second rule", _ => secondRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Version2>(), GetFactType<Fact1>()))
                .And("Compare rules", _ => Assert.IsFalse(firstRule.Compare(secondRule), "rules are not equal"))
                .When("Compare rules without version", _ => firstRule.CompareWithoutVersion(secondRule))
                .Then("Check result", result => Assert.IsTrue(result, "excluding versions, the rules are not equal"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][rule] comparison of the same rules where one without version")]
        public void ComparisonSameRulesWhereOneWithoutVersionTestCase()
        {
            Rule firstRule = null;
            Rule secondRule = null;

            Given("Create first rule", () => firstRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Version1>(), GetFactType<Fact1>()))
                .And("Create second rule", _ => secondRule = VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Fact1>()))
                .And("Compare rules", _ => Assert.IsFalse(firstRule.Compare(secondRule), "rules are not equal"))
                .When("Compare rules without version", _ => firstRule.CompareWithoutVersion(secondRule))
                .Then("Check result", result => Assert.IsTrue(result, "excluding versions, the rules are not equal"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][rule] calculate fact")]
        public void VersionedFactRule_CalculateTestCase()
        {
            Container container = null;

            Given("Create container", () => container = new Container())
                .And("Added fact version", () => container.Add(new Version2()))
                .And("Create rule", () => new Rule(ct => new FactResult(1), new List<IFactType> { GetFactType<Version2>() }, GetFactType<FactResult>()))
                .And("Can calculate", rule => Assert.IsTrue(rule.CanCalculate(container), "cannot calculate"))
                .When("Run calculate", rule => rule.Calculate(container))
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact.Version, "Version cannot be null");
                    if (fact.Version is Version2 version2)
                        Assert.AreEqual((uint)2, version2.Value, "expected another version");
                    else
                        Assert.Fail("Version is not Version2");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][rule] calculate fact without version")]
        public void VersionedFactRule_CalculateWithoutVersionTestCase()
        {
            Container container = null;

            Given("Create container", () => container = new Container())
                .And("Create rule", () => new Rule(ct => new FactResult(1), new List<IFactType> { }, GetFactType<FactResult>()))
                .And("Can calculate", rule => Assert.IsTrue(rule.CanCalculate(container), "cannot calculate"))
                .When("Run calculate", rule => rule.Calculate(container))
                .Then("Check result", fact =>
                {
                    Assert.IsNull(fact.Version, "Version must be null");
                });
        }
    }
}
