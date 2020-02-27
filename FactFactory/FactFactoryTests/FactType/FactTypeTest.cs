using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using GivenWhenThen.TestAdapter;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FactFactoryTests.FactType
{
    [TestClass]
    public sealed class FactTypeTest : TestBase
    {
        private GivenBlock<OtherFact> GivenCreateOtherFact(DateTime dateTime)
        {
            return Given("Create OthreFact", () => new OtherFact(dateTime));
        }

        [TestMethod]
        [TestCategory(TC.Objects.FactType)]
        [Description("Successful comparison of information about one fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CompareFactTypeOneFactTestCase()
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

        [TestMethod]
        [TestCategory(TC.Objects.FactType)]
        [Description("Successful comparison of information about one fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void SuccessCompareFactTypeTowFactTestCase()
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

        [TestMethod]
        [TestCategory(TC.Objects.FactType)]
        [Description("Unsuccessful comparison of two facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void FailedCompareFactTypeTowFactTestCase()
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

        [TestMethod]
        [TestCategory(TC.Objects.FactType)]
        [Description("Check fact name")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void FactNameTestCase()
        {
            GivenCreateOtherFact(DateTime.Now)
                .When("Create factInfo", fact => fact.GetFactType())
                .Then("Check result", factInfo => Assert.AreEqual(nameof(OtherFact), factInfo.FactName, "not expected fact name"));
        }
    }
}
