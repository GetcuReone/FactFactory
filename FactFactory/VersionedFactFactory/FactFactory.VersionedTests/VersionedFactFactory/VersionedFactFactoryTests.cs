using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactFactory.Env;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using GivenWhenThen.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using V_Collection = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRuleCollection;

namespace FactFactory.VersionedTests.VersionedFactFactory
{
    [TestClass]
    public sealed class VersionedFactFactoryTests : VersionedFactFactoryTestBase
    {
        private List<IVersionFact> GetVersionFacts()
        {
            return new List<IVersionFact>
            {
                new Version1(),
                new Version2(),
            };
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory)]
        [Description("Create wantAction without version")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DeriveFactWithoutVersionedRuleTestCase()
        {
            GivenCreateVersionedFactFactory(GetVersionFacts())
                .And("Added rule", factFactory =>
                {
                    factFactory.Rules.AddRange(new V_Collection
                    {
                        //without version
                        () => new Fact1(1_000),
                        (Fact1 fact) => new FactResult(fact.Value),
                        // version 1
                        (Version1 version) => new Fact1(10),
                        (Version1 version, Fact1 fact) => new FactResult(fact.Value * version.Value),
                        // version 1
                        (Version2 version) => new Fact1(10),
                        (Version2 version, Fact1 fact) => new FactResult(fact.Value * version.Value),
                    });
                })
                .When("Derive fact", factFactory => factFactory.DeriveFact<FactResult>())
                .Then("Check result", fact =>
                {
                    Assert.AreEqual(1_000, fact.Value, "expecten another fact value");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory)]
        [Description("Create wantAction with version")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DeriveFactWithtVersionedRuleTestCase()
        {
            GivenCreateVersionedFactFactory(GetVersionFacts())
                .And("Added rule", factFactory =>
                {
                    factFactory.Rules.AddRange(new V_Collection
                    {
                        //without version
                        () => new Fact1(1_000),
                        (Fact1 fact) => new FactResult(fact.Value + 1),
                        // version 1
                        (Version1 version) => new Fact1(10),
                        (Version1 version, Fact1 fact) => new FactResult(fact.Value * version.Value),
                        // version 2
                        (Version2 version) => new Fact1(100),
                        (Version2 version, Fact1 fact) => new FactResult(fact.Value * version.Value),
                    });
                })
                .When("Derive fact", factFactory => factFactory.DeriveFact<FactResult, Version1>())
                .Then("Check result", fact =>
                {
                    Assert.AreEqual(10, fact.Value, "expecten another fact value");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory)]
        [Description("Derive with invalid version")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DeriveWihtInvalidVersion_1_TestCase()
        {
            string expectedReason = $"For versions {GetFactType<CastumVersion>().FactName} and {GetFactType<CastumVersion>().FactName}, comparison operations did not work correctly.";
            var versions = new List<IVersionFact>
            {
                new CastumVersion(true, false, false),
                new CastumVersion(false, false, false),
            };

            GivenCreateVersionedFactFactory(versions)
                .When("Derive", factory => ExpectedDeriveException(() => factory.Derive()))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory)]
        [Description("Derive with invalid version")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DeriveWihtInvalidVersion_2_TestCase()
        {
            string expectedReason = $"For versions {GetFactType<CastumVersion>().FactName} and {GetFactType<CastumVersion>().FactName}, comparison operations did not work correctly.";
            var versions = new List<IVersionFact>
            {
                new CastumVersion(true, false, false),
                new CastumVersion(true, true, false),
            };

            GivenCreateVersionedFactFactory(versions)
                .When("Derive", factory => ExpectedDeriveException(() => factory.Derive()))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }
    }
}
