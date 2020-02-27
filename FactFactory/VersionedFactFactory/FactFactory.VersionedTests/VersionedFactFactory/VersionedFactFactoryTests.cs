using FactFactory.VersionedTests.CommonFacts;
using FactFactoryTestsCommon;
using GetcuReone.FactFactory.Versioned.Interfaces;
using GivenWhenThen.TestAdapter;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using V_Collection = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRuleCollection;
using V_FactFactory = GetcuReone.FactFactory.Versioned.VersionedFactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory
{
    [TestClass]
    public sealed class VersionedFactFactoryTests : CommonTestBase
    {
        private GivenBlock<V_FactFactory> GivenCreateVersionedFactFactory()
        {
            return Given("Create versioned fact factory", () => new V_FactFactory(GetVersionFacts));
        }

        private List<IVersionFact> GetVersionFacts()
        {
            return new List<IVersionFact>
            {
                new Version1(),
                new Version2(),
            };
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][fact_factory][versioned_fact_factory] create wantAction without version")]
        public void DeriveFactWithoutVersionedRuleTestCase()
        {
            GivenCreateVersionedFactFactory()
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

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][fact_factory][versioned_fact_factory] create wantAction with version")]
        public void DeriveFactWithtVersionedRuleTestCase()
        {
            FactResult result = null;

            GivenCreateVersionedFactFactory()
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
                .And("Want fact", factFactory => 
                {
                    factFactory.WantFact((Version1 _, FactResult fact) =>
                    {
                        result = fact;
                    });
                })
                .When("Derive fact", versionedFactFactory => versionedFactFactory.Derive())
                .Then("Check result", fact =>
                {
                    Assert.AreEqual(10, result.Value, "expecten another fact value");
                });
        }
    }
}
