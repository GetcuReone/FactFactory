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
            StartDateOfDerive fact = null;
            IFactType first = null;
            IFactType second = null;

            Given("Create fact", () => { fact = new StartDateOfDerive(DateTime.Now); })
                .When("Create fact info", _ =>
                {
                    first = fact.GetFactType();
                    second = fact.GetFactType();
                })
                .Then("Compare factInfos", () => Assert.IsTrue(first.Compare(second), "factual information is the same"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] successful comparison of information about one fact")]
        public void SuccessCompareFactInfoTowFactTestCase()
        {
            StartDateOfDerive firstFact = null;
            StartDateOfDerive secondFact = null;
            IFactType first = null;
            IFactType second = null;

            Given("Create fact", () => 
            { 
                firstFact = new StartDateOfDerive(DateTime.Now);
                secondFact = new StartDateOfDerive(DateTime.Now);
            })
                .When("Create fact info", _ =>
                {
                    first = firstFact.GetFactType();
                    second = secondFact.GetFactType();
                })
                .Then("Compare factInfos", () => Assert.IsTrue(first.Compare(second), "factual information is the same"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] unsuccessful comparison of two facts")]
        public void FailedCompareFactInfoTowFactTestCase()
        {
            StartDateOfDerive firstFact = null;
            OtherFact secondFact = null;
            IFactType first = null;
            IFactType second = null;

            Given("Create fact", () =>
            {
                firstFact = new StartDateOfDerive(DateTime.Now);
                secondFact = new OtherFact(firstFact.Value);
            })
                .When("Create fact info", _ =>
                {
                    first = firstFact.GetFactType();
                    second = secondFact.GetFactType();
                })
                .Then("Compare factInfos", () => Assert.IsFalse(first.Compare(second), "factual information is the same"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] check fact name")]
        public void FactNameTestCase()
        {
            GivenCreateOtherFact(DateTime.Now)
                .When("Create factInfo", fact => fact.GetFactType())
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
                    fact => Assert.IsTrue(fact.GetFactType().ContainsContainer(container), "the container does not contain a fact"));
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
                    fact => Assert.IsFalse(fact.GetFactType().ContainsContainer(container), "container contains fact"));
        }
    }
}
