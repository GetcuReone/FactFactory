using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Action = GetcuReone.FactFactory.Versioned.Entities.VersionedWantAction;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;

namespace FactFactory.VersionedTests.VersionedFactRule
{
    [TestClass]
    [Ignore]
    public sealed class VersionedFactRuleTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create rule with version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateRuleWithVersionTestCase()
        {
            GivenEmpty()
                .When("Create rule with version.", _ => 
                    VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Version1>(), GetFactType<Fact1>()))
                .Then("Check result.", rule =>
                {
                    Assert.IsNotNull(rule.VersionType, "The rule does not contain version information");
                    Assert.IsTrue(GetFactType<Version1>().EqualsFactType(rule.VersionType), $"{nameof(Rule.VersionType)} does not store version information");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create rule without version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateRuleWithoutVersionTestCase()
        {
            GivenEmpty()
                .When("Create rule with version.", _ => 
                    VersionedFactRuleHelper.CreateRule(GetFactType<FactResult>(), GetFactType<Fact1>()))
                .Then("Check result.", rule =>
                {
                    Assert.IsNull(rule.VersionType, "The rule contain version information");
                });
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
                .And("Create rule", () => new Rule(facts => new FactResult(1), new List<IFactType> { GetFactType<Version2>() }, GetFactType<FactResult>()))
                .When("Run calculate", rule => rule.Calculate(container))
                .ThenIsNotNull()
                .And("Get version.", fact =>
                {
                    if (fact is VersionedFactBase versionedFact)
                        return versionedFact.GetVersionOrNull();

                    Assert.Fail("Invalid type.");
                    return null;
                })
                .AndIsNotNull()
                .And("Check result.", version =>
                {
                    if (version is Version2 version2)
                        Assert.AreEqual(2, version2, "expected another version.");
                    else
                        Assert.Fail("Version is not Version2.");
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
                .And("Create rule", () => 
                    new Rule(facts => new FactResult(1), new List<IFactType> { }, GetFactType<FactResult>()))
                .When("Run calculate", rule => 
                    rule.Calculate(container))
                .ThenIsNotNull()
                .And("Get version.", fact =>
                    fact.GetVersionOrNull())
                .AndIsNull();
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
                        () => new Rule(facts => { return default; }, new List<IFactType> { GetFactType<Fact1>() }, GetFactType<Version1>()));
                })
                .Then("Check error", ex =>
                {
                    Assert.AreEqual(expectedReason, ex.Message, "Another message expected");
                });
        }
    }
}
