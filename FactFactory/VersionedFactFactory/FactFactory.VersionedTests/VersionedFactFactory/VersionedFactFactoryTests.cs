using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
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

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory)]
        [Description("Create wantAction without version")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory)]
        [Description("Create wantAction with version")]
        //[Timeout(Timeouts.MilliSecond.Hundred)]
        public void DeriveFactWithtVersionedRuleTestCase()
        {
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
                .When("Derive fact", factFactory => factFactory.DeriveFact<FactResult, Version1>())
                .Then("Check result", fact =>
                {
                    Assert.AreEqual(10, fact.Value, "expecten another fact value");
                });
        }
    }
}
