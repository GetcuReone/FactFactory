﻿using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

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
                    GetFactRule((Version1 v, Fact1 _) => new FactResult(default)))
                .ThenGetVersionType()
                .And("Check result.", versionType =>
                {
                    Assert.IsTrue(GetFactType<Version1>().EqualsFactType(versionType), $"{nameof(versionType)} does not store version information");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create rule without version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateRuleWithoutVersionTestCase()
        {
            GivenEmpty()
                .When("Create rule with version.", _ =>
                    GetFactRule((Fact1 _) => new FactResult(default)))
                .ThenNotContainVersionType()
                .Run();
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
                    GetFactRule(() => new FactResult(default)))
                .When("Run calculate", rule => 
                    rule.Calculate(container))
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.FindVersionParameter(), null)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(TC.Objects.BuildNotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Return version fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ReturnVersiondFactTestCase()
        {
            string expectedReason = $"Parameter outputFactType should not be converted into {typeof(ISpecialFact).FullName}";

            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => GetFactRule((Fact1 _) => new Version1()));
                })
                .Then("Check error", ex =>
                {
                    Assert.AreEqual(expectedReason, ex.Message, "Another message expected");
                })
                .Run();
        }
    }
}
