using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using JwtTestAdapter;
using JwtTestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FactFactoryTests.FactInfo
{
    [TestClass]
    public sealed class FactInfoTest : TestBase
    {
        private GivenBlock<OtherFact> GivenCreateOtherFact(DateTime dateTime)
        {
            return Given("Create OthreFact", () => new OtherFact(dateTime));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] successful comparison of information about one fact")]
        public void CompareFactInfoOneFactTestCase()
        {
            DateOfDeriveFact fact = null;
            IFactType first = null;
            IFactType second = null;

            Given("Create fact", () => { fact = new DateOfDeriveFact(DateTime.Now); })
                .When("Create fact info", _ =>
                {
                    first = fact.GeTFactType();
                    second = fact.GeTFactType();
                })
                .Then("Compare factInfos", () => Assert.IsTrue(first.Compare(second), "factual information is the same"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] successful comparison of information about one fact")]
        public void SuccessCompareFactInfoTowFactTestCase()
        {
            DateOfDeriveFact firstFact = null;
            DateOfDeriveFact secondFact = null;
            IFactType first = null;
            IFactType second = null;

            Given("Create fact", () => 
            { 
                firstFact = new DateOfDeriveFact(DateTime.Now);
                secondFact = new DateOfDeriveFact(DateTime.Now);
            })
                .When("Create fact info", _ =>
                {
                    first = firstFact.GeTFactType();
                    second = secondFact.GeTFactType();
                })
                .Then("Compare factInfos", () => Assert.IsTrue(first.Compare(second), "factual information is the same"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] unsuccessful comparison of two facts")]
        public void FailedCompareFactInfoTowFactTestCase()
        {
            DateOfDeriveFact firstFact = null;
            OtherFact secondFact = null;
            IFactType first = null;
            IFactType second = null;

            Given("Create fact", () =>
            {
                firstFact = new DateOfDeriveFact(DateTime.Now);
                secondFact = new OtherFact(firstFact.Value);
            })
                .When("Create fact info", _ =>
                {
                    first = firstFact.GeTFactType();
                    second = secondFact.GeTFactType();
                })
                .Then("Compare factInfos", () => Assert.IsFalse(first.Compare(second), "factual information is the same"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] check fact name")]
        public void FactNameTestCase()
        {
            GivenCreateOtherFact(DateTime.Now)
                .When("Create factInfo", fact => fact.GeTFactType())
                .Then("Check result", factInfo => Assert.AreEqual(nameof(OtherFact), factInfo.FactName, "not expected fact name"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] container contains fact")]
        public void ContainsContainerTestCase()
        {
            GetcuReone.FactFactory.Entities.FactContainer container = null;

            GivenCreateOtherFact(DateTime.Now)
                .When("Add container", fact =>
                {
                    container = new GetcuReone.FactFactory.Entities.FactContainer();
                    container.Add(fact);
                    return fact;
                })
                .Then("Check container contains fact", 
                    fact => Assert.IsTrue(fact.GeTFactType().ContainsContainer(container), "the container does not contain a fact"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] the container does not contain a fact")]
        public void NotContainsContainerTestCase()
        {
            GetcuReone.FactFactory.Entities.FactContainer container = null;

            GivenCreateOtherFact(DateTime.Now)
                .When("Create container", fact =>
                {
                    container = new GetcuReone.FactFactory.Entities.FactContainer();
                    return fact;
                })
                .Then("Check container contains fact",
                    fact => Assert.IsFalse(fact.GeTFactType().ContainsContainer(container), "container contains fact"));
        }
    }
}
