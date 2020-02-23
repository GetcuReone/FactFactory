using FactFactory.VersionedTests.CommonFacts;
using FactFactoryTestsCommon;
using GetcuReone.FactFactory.Versioned.Entities;
using GetcuReone.FactFactory.Versioned.Interfaces;
using JwtTestAdapter;
using JwtTestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
                .And("Added rule", versionedFactFactory =>
                {
                    versionedFactFactory.Rules.AddRange(new VersionedFactRuleCollection
                    {
                        () => new Fact1(0),
                        (Fact1 fact) => new FactResult(fact.Value + 1),
                    });
                })
                .When("Derive fact", versionedFactFactory => versionedFactFactory.DeriveFact<FactResult>())
                .Then("Check result", fact =>
                {
                    Assert.AreEqual(1, fact.Value, "expecten another fact value");
                });
        }
    }
}
