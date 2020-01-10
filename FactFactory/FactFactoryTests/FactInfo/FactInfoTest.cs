﻿using FactFactory.Facts;
using FactFactory.Interfaces;
using FactFactoryTests.CommonFacts;
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

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] successful comparison of information about one fact")]
        public void CompareFactInfoOneFactTestCase()
        {
            DateOfDeriveFact fact = null;
            IFactInfo first = null;
            IFactInfo second = null;

            Given("Create fact", () => { fact = new DateOfDeriveFact(DateTime.Now); })
                .When("Create fact info", _ =>
                {
                    first = fact.GetFactInfo();
                    second = fact.GetFactInfo();
                })
                .Then("Compare factInfos", () => Assert.IsTrue(first.Compare(second), "factual information is the same"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] successful comparison of information about one fact")]
        public void SuccessCompareFactInfoTowFactTestCase()
        {
            DateOfDeriveFact firstFact = null;
            DateOfDeriveFact secondFact = null;
            IFactInfo first = null;
            IFactInfo second = null;

            Given("Create fact", () => 
            { 
                firstFact = new DateOfDeriveFact(DateTime.Now);
                secondFact = new DateOfDeriveFact(DateTime.Now);
            })
                .When("Create fact info", _ =>
                {
                    first = firstFact.GetFactInfo();
                    second = secondFact.GetFactInfo();
                })
                .Then("Compare factInfos", () => Assert.IsTrue(first.Compare(second), "factual information is the same"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] unsuccessful comparison of two facts")]
        public void FailedCompareFactInfoTowFactTestCase()
        {
            DateOfDeriveFact firstFact = null;
            OtherFact secondFact = null;
            IFactInfo first = null;
            IFactInfo second = null;

            Given("Create fact", () =>
            {
                firstFact = new DateOfDeriveFact(DateTime.Now);
                secondFact = new OtherFact(firstFact.Value);
            })
                .When("Create fact info", _ =>
                {
                    first = firstFact.GetFactInfo();
                    second = secondFact.GetFactInfo();
                })
                .Then("Compare factInfos", () => Assert.IsFalse(first.Compare(second), "factual information is the same"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] check fact name")]
        public void FactNameTestCase()
        {
            GivenCreateOtherFact(DateTime.Now)
                .When("Create factInfo", fact => fact.GetFactInfo())
                .Then("Check result", factInfo => Assert.AreEqual(nameof(OtherFact), factInfo.FactName, "not expected fact name"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] container contains fact")]
        public void ContainsContainerTestCase()
        {
            FactFactory.Entities.FactContainer container = null;

            GivenCreateOtherFact(DateTime.Now)
                .When("Add container", fact =>
                {
                    container = new FactFactory.Entities.FactContainer();
                    container.Add(fact);
                    return fact;
                })
                .Then("Check container contains fact", 
                    fact => Assert.IsTrue(fact.GetFactInfo().ContainsContainer(container), "the container does not contain a fact"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][info] the container does not contain a fact")]
        public void NotContainsContainerTestCase()
        {
            FactFactory.Entities.FactContainer container = null;

            GivenCreateOtherFact(DateTime.Now)
                .When("Create container", fact =>
                {
                    container = new FactFactory.Entities.FactContainer();
                    return fact;
                })
                .Then("Check container contains fact",
                    fact => Assert.IsFalse(fact.GetFactInfo().ContainsContainer(container), "container contains fact"));
        }
    }
}