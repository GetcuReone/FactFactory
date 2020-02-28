using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactType.Env;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Exceptions;
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

        private GivenBlock<FactType<TFact>> GivenCreateFactType<TFact>()
            where TFact : IFact
        {
            return Given($"Create fact type for {typeof(TFact).Name}", () => new FactType<TFact>());
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

        [TestMethod]
        [TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NoDerived)]
        [Description("Create NoDerived fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CreateNoDerivedFactTestCase()
        {
            GivenCreateFactType<NoDerived<OtherFact>>()
                .When("Create NoDerived fact", factType => factType.CreateNoDerived())
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact, "fact cannot be null");
                    Assert.IsTrue(fact is NoDerived<OtherFact>, "Expected another type");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NoDerived)]
        [Description("Create a NoDerived fact using the wrong type")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CreateNoDerivedUsingWrongTypeTestCase()
        {
            GivenCreateFactType<OtherFact>()
                .When("Create NoDerived fact", factType => ExpectedException<FactFactoryException>(() => factType.CreateNoDerived()))
                .Then("Check result", error =>
                {
                    Assert.IsNotNull(error, "error cannot be null");
                    Assert.AreEqual(1, error.Details.Count);

                    ErrorDetail detail = error.Details[0];
                    Assert.AreEqual(ErrorCode.InvalidFactType, detail.Code, "Expected another code");
                    Assert.AreEqual($"{typeof(OtherFact).FullName} does not implement {typeof(INoDerivedFact).FullName} type.", detail.Reason, "Expected another message");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NoDerived)]
        [Description("Create a NoDerived fact without default constructor")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CreateNoDerivedWithoutDefaultConstructorTestCase()
        {
            GivenCreateFactType<NoDerivedWithoutConstructor>()
                .When("Create NoDerived fact", factType => ExpectedException<FactFactoryException>(() => factType.CreateNoDerived()))
                .Then("Check result", error =>
                {
                    Assert.IsNotNull(error, "error cannot be null");
                    Assert.AreEqual(1, error.Details.Count);

                    ErrorDetail detail = error.Details[0];
                    Assert.AreEqual(ErrorCode.InvalidFactType, detail.Code, "Expected another code");
                    Assert.AreEqual($"{typeof(NoDerivedWithoutConstructor).FullName} doesn't have a default constructor.", detail.Reason, "Expected another message");
                });
        }
    }
}
