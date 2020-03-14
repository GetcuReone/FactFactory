using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactType.Env;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.FactFactory.Exceptions;
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
            DateTimeFact fact = null;
            IFactType first = null;
            IFactType second = null;

            Given("Create fact", () => { fact = new DateTimeFact(DateTime.Now); })
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
            DateTimeFact firstFact = null;
            DateTimeFact secondFact = null;
            IFactType first = null;
            IFactType second = null;

            Given("Create fact", () => 
            { 
                firstFact = new DateTimeFact(DateTime.Now);
                secondFact = new DateTimeFact(DateTime.Now);
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
            DateTimeFact firstFact = null;
            OtherFact secondFact = null;
            IFactType first = null;
            IFactType second = null;

            Given("Create fact", () =>
            {
                firstFact = new DateTimeFact(DateTime.Now);
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
                .When("Create NoDerived fact", factType => factType.CreateSpecialFact<INoDerivedFact>())
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
            string expectedReason = $"{typeof(OtherFact).FullName} does not implement {typeof(INoDerivedFact).FullName} type.";

            GivenCreateFactType<OtherFact>()
                .When("Create NoDerived fact", factType => ExpectedException<FactFactoryException>(() => factType.CreateSpecialFact<INoDerivedFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NoDerived)]
        [Description("Create a NoDerived fact without default constructor")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CreateNoDerivedWithoutDefaultConstructorTestCase()
        {
            string expectedReason = $"{typeof(NoDerivedWithoutConstructor).FullName} doesn't have a default constructor.";

            GivenCreateFactType<NoDerivedWithoutConstructor>()
                .When("Create NoDerived fact", factType => ExpectedException<FactFactoryException>(() => factType.CreateSpecialFact<INoDerivedFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NotContained)]
        [Description("Create NotContained fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CreateNotContainedFactTestCase()
        {
            GivenCreateFactType<NotContained<OtherFact>>()
                .When("Create NotContained fact", factType => factType.CreateSpecialFact<INotContainedFact>())
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact, "fact cannot be null");
                    Assert.IsTrue(fact is NotContained<OtherFact>, "Expected another type");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NotContained)]
        [Description("Create a NotContained fact using the wrong type")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CreateNotContainedUsingWrongTypeTestCase()
        {
            string expectedReason = $"{typeof(OtherFact).FullName} does not implement {typeof(INotContainedFact).FullName} type.";

            GivenCreateFactType<OtherFact>()
                .When("Create NoDerived fact", factType => ExpectedException<FactFactoryException>(() => factType.CreateSpecialFact<INotContainedFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NotContained)]
        [Description("Create a NotContained fact without default constructor")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CreateNotContainedWithoutDefaultConstructorTestCase()
        {
            string expectedReason = $"{typeof(NotContainedWithoutConstructor).FullName} doesn't have a default constructor.";

            GivenCreateFactType<NotContainedWithoutConstructor>()
                .When("Create NoDerived fact", factType => ExpectedException<FactFactoryException>(() => factType.CreateSpecialFact<INotContainedFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }
    }
}
