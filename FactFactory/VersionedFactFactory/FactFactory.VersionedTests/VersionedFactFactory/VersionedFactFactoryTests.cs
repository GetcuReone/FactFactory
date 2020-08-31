using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactFactory.Helpers;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Priority;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;

namespace FactFactory.VersionedTests.VersionedFactFactory
{
    [TestClass]
    public sealed class VersionedFactFactoryTests : VersionedFactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create wantAction without version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFactWithoutVersionedRuleTestCase()
        {
            const long expectedValue = 1_000;

            GivenCreateVersionedFactFactory()
                .AndAddRules(new Collection
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

            GivenCreateVersionedFactFactory()
                .AndAddRules(new Collection
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
        [Description("Not recount facts with a different version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void NotRecountFactsWithDifferentVersionTestCase()
        {
            FactResult result1 = null;
            FactResult result2 = null;
            var container = new Container();

            GivenCreateVersionedFactFactory()
                .AndAddRules(new Collection
                {
                    (Version1 v, Fact1 fact) => new FactResult(fact.Value),

                    (Version1 v) => new Fact1(v),
                    (Version2 v) => new Fact1(v),
                })
                .And("Want fact.", factory =>
                {
                    factory.WantFacts((Version1 _, FactResult fact) => result1 = fact, container);
                    factory.WantFacts((Version2 _, FactResult fact) => result2 = fact, container);
                })
                .When("Derive", factory => 
                    factory.Derive())
                .Then("Check result.", _ =>
                {
                    Assert.IsNotNull(result1, "result1 cannot be null.");
                    Assert.IsNotNull(result2, "result2 cannot be null.");

                    Assert.AreEqual(1, result1.Value, "Expected another value.");
                    Assert.AreEqual(1, result2.Value, "Expected another value.");
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
            var container = new Container();

            GivenCreateVersionedFactFactory()
                .AndAddRules(new Collection
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
                    factory.WantFacts((Version1 _, FactResult fact) => { }, container);
                    factory.WantFacts((Version2 _, FactResult fact) => { }, container);
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
            var container = new Container();

            GivenCreateVersionedFactFactory()
                .AndAddRules(new Collection
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
                        factory.WantFacts((Version1 _, FactResult fact) => 
                        {
                            counterAction1++;
                        }, container);
                        factory.WantFacts((Fact1 fact) =>
                        {
                            counterAction3++;
                        }, container);
                        factory.WantFacts((Version2 _, FactResult fact) =>
                        {
                            counterAction2++;
                        }, container);
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
            const long expectedValue = 10;
            var container = new Container
            {
                new Fact1((int)expectedValue),
            };

            GivenCreateVersionedFactFactory()
                .AndAddRules(new Collection
                {
                    (Version1 v) => new FactResult(0),
                    (Version2 v, Fact1 fact) => new FactResult(fact.Value)
                })
                .When("Derive fact.", factFactory => 
                    factFactory.DeriveFact<FactResult, Version2>(container))
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request an available fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RequestAvailableFactTestCase()
        {
            const long expectedValue = 1;
            var container = new Container
            {
                new FactResult(expectedValue).SetVersionParam(new Version1()),
            };

            GivenCreateVersionedFactFactory()
                .AndAddRules(new Collection
                {
                    (Version2 v) => new FactResult(2),
                })
                .When("Derive fact.", factFactory =>
                    factFactory.DeriveFact<FactResult, Version1>(container))
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Select a higher priority fact from the container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SelectHigherPriorityFactFromContainerTestCase()
        {
            const long expectedValue = 1;
            var container = new Container
            {
                new FactResult(expectedValue).SetPriority(new Priority1()).SetVersion(new Version1()),
                new FactResult(expectedValue * 2).SetVersion(new Version2())
            };

            GivenCreateVersionedFactFactory()
                .When("Derive fact.", factFactory =>
                    factFactory.DeriveFact<FactResult, Version2>(container))
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Select a rule with a higher priority.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SelectRuleWithHigherPriorityTestCase()
        {
            const long expectedValue = 1;

            GivenCreateVersionedFactFactory()
                .AndAddRules(new Collection 
                {
                    (Version1 v, Priority1 p) => new FactResult(expectedValue),
                    (Version2 v) => new FactResult(expectedValue * 2),
                })
                .When("Derive fact.", factFactory =>
                    factFactory.DeriveFact<FactResult, Version2>())
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Select a fact not calculated by the rule.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SelectFactNotCalculatedByRuleTestCase()
        {
            const long expectedValue = 1;
            var container = new Container
            {
                new FactResult(expectedValue).SetVersion(new Version1()),
                new FactResult(expectedValue * 2).SetCalculateByRule().SetVersion(new Version2())
            };

            GivenCreateVersionedFactFactory()
                .When("Derive fact.", factFactory =>
                    factFactory.DeriveFact<FactResult, Version2>(container))
                .ThenFactEquals(expectedValue);
        }
    }
}
