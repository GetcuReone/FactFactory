using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactFactory.Helpers;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
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
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create wantAction without version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFactWithoutVersionedRuleTestCase()
        {
            const long expectedValue = 1_000;

            GivenCreateVersionedFactFactory(GetVersionFacts())
                .AndAddRules(new V_Collection
                {
                    //without version
                    () => new Fact1(1_000),
                    (Fact1 fact) => new FactResult(fact.Value),
                    // version 1
                    (Version1 version) => new Fact1(10),
                    (Version1 version, Fact1 fact) => new FactResult(fact.Value * version),
                    // version 1
                    (Version2 version) => new Fact1(20),
                    (Version2 version, Fact1 fact) => new FactResult(fact.Value * version),
                })
                .When("Derive fact.", factFactory =>
                    factFactory.DeriveFact<FactResult>())
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create wantAction with version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFactWithtVersionedRuleTestCase()
        {
            const long expectedValue = 10;

            GivenCreateVersionedFactFactory(GetVersionFacts())
                .AndAddRules(new V_Collection
                {
                    //without version
                    () => new Fact1(1_000),
                    (Fact1 fact) => new FactResult(fact.Value + 1),
                    // version 1
                    (Version1 version) => new Fact1(10),
                    (Version1 version, Fact1 fact) => new FactResult(fact.Value * version),
                    // version 2
                    (Version2 version) => new Fact1(100),
                    (Version2 version, Fact1 fact) => new FactResult(fact.Value * version),
                })
                .When("Derive fact.", factFactory => 
                    factFactory.DeriveFact<FactResult, Version1>())
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Recount facts with a different version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RecountFactsWithDifferentVersionTestCase()
        {
            FactResult result1 = null;
            FactResult result2 = null;

            GivenCreateVersionedFactFactory(GetVersionFacts())
                .AndAddRules(new V_Collection
                {
                    (Version1 v, Fact1 fact) => new FactResult(fact.Value),

                    (Version1 v) => new Fact1(v),
                    (Version2 v) => new Fact1(v),
                })
                .And("Want fact.", factory =>
                {
                    factory.WantFact((Version1 _, FactResult fact) => result1 = fact);
                    factory.WantFact((Version2 _, FactResult fact) => result2 = fact);
                })
                .When("Derive", factory => 
                    factory.Derive())
                .Then("Check result.", _ =>
                {
                    Assert.IsNotNull(result1, "result1 cannot be null.");
                    Assert.IsNotNull(result2, "result2 cannot be null.");

                    Assert.AreEqual(1, result1.Value, "Expected another value.");
                    Assert.AreEqual(2, result2.Value, "Expected another value.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Do not overshoot the fact once again.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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
                        return  new Fact2(v);
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
                .And("Want fact.", factory =>
                {
                    factory.WantFact((Version1 _, FactResult fact) => { });
                    factory.WantFact((Version2 _, FactResult fact) => { });
                })
                .When("Derive", factory => 
                    factory.Derive())
                .Then("Check result.", _ =>
                {
                    Assert.AreEqual(1, counterFact2, "Fact2 was supposed to pay 1 time.");
                    Assert.AreEqual(1, counterFact1, "Fact1 was supposed to pay 1 times.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Do not recalculate calculated fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DoNotRecalculateCalculatedFactTestCase()
        {
            int counterFact1 = 0;
            int counterFact2 = 0;
            int counterResult = 0;
            int counterAction1 = 0;
            int counterAction2 = 0;
            int counterAction3 = 0;

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
                        counterFact1++;
                        return new Fact1(v);
                    },
                    (Version2 v) =>
                    {
                        counterFact2++;
                        return new Fact1(v);
                    },
                })
                .And("Want fact.", factory =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        factory.WantFact((Version1 _, FactResult fact) => 
                        {
                            counterAction1++;
                        });
                        factory.WantFact((Fact1 fact) =>
                        {
                            counterAction3++;
                        });
                        factory.WantFact((Version2 _, FactResult fact) =>
                        {
                            counterAction2++;
                        });
                    }
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result.", _ =>
                {
                    Assert.AreEqual(1, counterFact1, "The Fact1 should have been calculated 1 time.");
                    Assert.AreEqual(0, counterFact2, "The Fact2 should have been calculated 0 time.");

                    Assert.AreEqual(counterFact1 + counterFact2, counterResult, "The Fact1 should have been calculated 2 times.");

                    Assert.AreEqual(10, counterAction1, "Expected another value counterAction1.");
                    Assert.AreEqual(10, counterAction2, "Expected another value counterAction2.");
                    Assert.AreEqual(10, counterAction3, "Expected another value counterAction3.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Use newer rule for Derive.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UseNewerRuleForDeriveTestCase()
        {
            int expectedValue = 10;

            GivenCreateVersionedFactFactory(GetVersionFacts())
                .AndAddRules(new V_Collection
                {
                    (Version1 v) => new FactResult(0),
                    (Version2 v, Fact1 fact) => new FactResult(fact.Value)
                })
                .And("Add fact.", factFactory => 
                    factFactory.Container.Add(new Fact1(expectedValue)))
                .When("Derive fact.", factFactory => 
                    factFactory.DeriveFact<FactResult, Version2>().Value)
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request an available fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RequestAvailableFactTestCase()
        {
            int expectedValue = 1;

            GivenCreateVersionedFactFactory(GetVersionFacts())
                .AndAddRules(new V_Collection
                {
                    (Version2 v) => new FactResult(2),
                })
                .And("Add fact.", factFactory => 
                    factFactory.Container.Add(new FactResult(expectedValue, new Version1())))
                .When("Derive fact.", factFactory => 
                    factFactory.DeriveFact<FactResult, Version1>())
                .Then("Check result.", fact =>
                {
                    Assert.AreEqual(expectedValue, fact.Value, "The older rule worked.");
                });
        }
    }
}
