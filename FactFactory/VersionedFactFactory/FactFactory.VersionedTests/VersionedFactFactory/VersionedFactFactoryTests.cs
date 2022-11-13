using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Priority;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.FactFactory.Versioned.Extensions;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactory.VersionedTests.VersionedFactFactory
{
    [TestClass]
    public sealed class VersionedFactFactoryTests : BaseVersionedFactFactoryTests
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
                .ThenFactValueEquals(expectedValue)
                .Run();
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
                .ThenFactValueEquals(expectedValue)
                .Run();
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
                })
                .Run();
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
                })
                .Run();
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
                })
                .Run();
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
                .ThenFactValueEquals(expectedValue)
                .Run();
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
                .ThenFactValueEquals(expectedValue)
                .Run();
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
                new FactResult(expectedValue).AddPriorityParameter(new Priority1()).AddVerionParameter(new Version1()),
                new FactResult(expectedValue * 2).AddVerionParameter(new Version2())
            };

            GivenCreateVersionedFactFactory()
                .When("Derive fact.", factFactory =>
                    factFactory.DeriveFact<FactResult, Version2>(container))
                .ThenFactValueEquals(expectedValue)
                .Run();
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
                .ThenFactValueEquals(expectedValue)
                .Run();
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
                new FactResult(expectedValue).AddVerionParameter(new Version1()),
                new FactResult(expectedValue * 2).SetCalculateByRule().AddVerionParameter(new Version2())
            };

            GivenCreateVersionedFactFactory()
                .When("Derive fact.", factFactory =>
                    factFactory.DeriveFact<FactResult, Version2>(container))
                .ThenFactValueEquals(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Calculate a fact by priority rule.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CalculateFactByPriorityRuleTestCase()
        {
            const long expectedValue = 3;

            GivenCreateVersionedFactFactory()
                .AndAddRules(new Collection
                {
                    (Priority1 p) => new Fact2((int)p.PriorityValue),
                    (Version1 v) => new Fact2(v),
                    (Version2 v) => new Fact2(v),

                    (Version1 v, Priority1 p, Fact2 f) => new Fact1(f + (int)p.PriorityValue + v),
                    (Version2 v, Fact2 f) => new Fact1(f + v),
                    (Fact2 f) => new Fact1(f),

                    (Fact1 f) => new FactResult(f),
                })
                .When("Derive fact.", factFactory =>
                    factFactory.DeriveFact<FactResult>())
                .ThenFactValueEquals(expectedValue)
                .Run();
        }
    }
}
