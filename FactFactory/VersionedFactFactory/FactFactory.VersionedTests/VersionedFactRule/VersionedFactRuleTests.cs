using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.FactFactory.Versioned.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;
using Action = GetcuReone.FactFactory.Versioned.Entities.VersionedWantAction;
using GetcuReone.GetcuTestAdapter;

namespace FactFactory.VersionedTests.VersionedFactRule
{
    [TestClass]
    public sealed class VersionedFactRuleTests : CommonTestBase<VersionedFactBase>
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create rule with version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create rule without version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateRuleWithoutVersionTestCase()
        {
            GivenEmpty()
                .When("Create rule with version", _ => VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Fact1>()))
                .Then("Check result", rule =>
                {
                    Assert.IsNull(rule.VersionType, "The rule contain version information");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compare the same rules without versions.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compare the same rules with versions.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compare the same rules with different versions.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of the same rules where one without version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Calculate fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void VersionedFactRule_CalculateTestCase()
        {
            Container container = null;

            Given("Create container", () => container = new Container())
                .And("Added fact version", () => container.Add(new Version2()))
                .And("Create rule", () => new Rule((ct, _) => new FactResult(1), new List<IFactType> { GetFactType<Version2>() }, GetFactType<FactResult>()))
                .And("Can calculate", rule => Assert.IsTrue(rule.CanCalculate(container, default(Action)), "cannot calculate"))
                .When("Run calculate", rule => rule.Calculate(container, default(Action)))
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact.Version, "Version cannot be null");
                    if (fact.Version is Version2 version2)
                        Assert.AreEqual(2, version2.Value, "expected another version");
                    else
                        Assert.Fail("Version is not Version2");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Calculate fact without version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void VersionedFactRule_CalculateWithoutVersionTestCase()
        {
            Container container = null;

            Given("Create container", () => container = new Container())
                .And("Create rule", () => new Rule((ct, _) => new FactResult(1), new List<IFactType> { }, GetFactType<FactResult>()))
                .And("Can calculate", rule => Assert.IsTrue(rule.CanCalculate(container, default(Action)), "cannot calculate"))
                .When("Run calculate", rule => rule.Calculate(container, default(Action)))
                .Then("Check result", fact =>
                {
                    Assert.IsNull(fact.Version, "Version must be null");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Return version fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ReturnVersiondFactTestCase()
        {
            string expectedReason = $"Parameter outputFactType should not be converted into {typeof(ISpecialFact).FullName}";

            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new Rule((ct, _) => { return default; }, new List<IFactType> { GetFactType<Fact1>() }, GetFactType<Version1>()));
                })
                .Then("Check error", ex =>
                {
                    Assert.AreEqual(expectedReason, ex.Message, "Another message expected");
                });
        }
    }
}
