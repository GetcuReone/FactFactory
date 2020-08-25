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
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;

namespace FactFactory.VersionedTests.VersionedFactRule
{
    [TestClass]
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
                .ThenGetVersionType()
                .And("Check result.", versionType =>
                {
                    Assert.IsTrue(GetFactType<Version1>().EqualsFactType(versionType), $"{nameof(versionType)} does not store version information");
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
                .ThenNotContainVersionType();
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
