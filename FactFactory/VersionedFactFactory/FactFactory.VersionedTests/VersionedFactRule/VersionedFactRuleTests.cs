﻿using FactFactory.VersionedTests.CommonFacts;
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
        private IFactType GetFactType<TFact>()
            where TFact : IFact
        {
            return new FactType<TFact>();
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][versioned][rule] create rule with version")]
        public void CreateRuleWithVersionTestCase()
        {
            GivenEmpty()
                .When("Create rule with version", _ => VersionedFactRuleHelper.CreateRule(GetFactType<V1>(), GetFactType<Fact1>()))
                .Then("Check result", rule =>
                {
                    Assert.IsNotNull(rule.TypeFactVersion, "The rule does not contain version information");
                    Assert.IsTrue(GetFactType<V1>().Compare(rule.TypeFactVersion), $"{nameof(Rule.TypeFactVersion)} does not store version information");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][versioned][rule] create rule without version")]
        public void CreateRuleWithoutVersionTestCase()
        {
            GivenEmpty()
                .When("Create rule with version", _ => VersionedFactRuleHelper.CreateRule(GetFactType<Fact1>()))
                .Then("Check result", rule =>
                {
                    Assert.IsNull(rule.TypeFactVersion, "The rule contain version information");
                });
        }
    }
}