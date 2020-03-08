using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactFactory.Env;
using FactFactory.VersionedTests.VersionedFactFactory.Helpers;
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

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory)]
        [Description("Recount facts with a different version")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void RecountFactsWithDifferentVersionTestCase()
        {
            FactResult result1 = null;
            FactResult result2 = null;

            GivenCreateVersionedFactFactory(GetVersionFacts())
                .AndAddRules(new V_Collection
                {
                    (Version1 v, Fact1 fact) => new FactResult(fact.Value),

                    (Version1 v) => new Fact1(v.Value),
                    (Version2 v) => new Fact1(v.Value),
                })
                .And("Want fact", factory =>
                {
                    factory.WantFact((Version1 _, FactResult fact) => result1 = fact);
                    factory.WantFact((Version2 _, FactResult fact) => result2 = fact);
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(result1, "result1 cannot be null.");
                    Assert.IsNotNull(result2, "result2 cannot be null.");

                    Assert.AreEqual(1, result1.Value, "Expected another value.");
                    Assert.AreEqual(2, result2.Value, "Expected another value.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory)]
        [Description("Do not overshoot the fact once again")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DoNotOvershootFactOnceAgainTestCase()
        {
            int counterFact2 = 0;
            int counterFact1 = 0;

            GivenCreateVersionedFactFactory(GetVersionFacts())
                .AndAddRules(new V_Collection
                {
                    (Version1 v) =>
                    {
                        counterFact2++;
                        return  new Fact2(v.Value);
                    },

                    (Version1 v, Fact2 fact) =>
                    {
                        counterFact1++;
                        return new Fact1(fact.Value);
                    },
                    (Version2 v, Fact2 fact) =>
                    {
                        counterFact1++;
                        return new Fact1(fact.Value);
                    },

                    (Version1 v, Fact1 fact) => new FactResult(fact.Value),
                    (Version2 v, Fact1 fact) => new FactResult(fact.Value),

                })
                .And("Want fact", factory =>
                {
                    factory.WantFact((Version1 _, FactResult fact) => { });
                    factory.WantFact((Version2 _, FactResult fact) => { });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.AreEqual(1, counterFact2, "Fact2 was supposed to pay 1 time");
                    Assert.AreEqual(2, counterFact1, "Fact1 was supposed to pay 2 times");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory)]
        [Description("Do not recalculate calculated fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DoNotRecalculateCalculatedFactTestCase()
        {
            int counterFact = 0;
            int counterResult = 0;

            GivenCreateVersionedFactFactory(GetVersionFacts())
                .AndAddRules(new V_Collection
                {
                    (Version1 v, Fact1 fact) => 
                    {
                        counterResult++;
                        return new FactResult(fact.Value);
                    },

                    (Version1 v) => 
                    {
                        counterFact++;
                        return new Fact1(v.Value);
                    },
                    (Version2 v) => new Fact1(v.Value),
                })
                .And("Want fact", factory =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        factory.WantFact((Version1 _, FactResult fact) => { });
                        factory.WantFact((Version2 _, FactResult fact) => { }); 
                    }
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.AreEqual(1, counterFact, "The Fact1 should have been calculated 1 time.");
                    Assert.AreEqual(2, counterResult, "The Fact1 should have been calculated 2 times.");
                });
        }
    }
}
