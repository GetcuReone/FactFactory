using FactFactory.DefaultTests.FactType.Env;
using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactType.Env;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework;
using GetcuReone.GwtTestFramework.Entities;
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
        [TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Successful comparison of information about one fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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
        [TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Successful comparison of information about one fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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
        [TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Unsuccessful comparison of two facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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
        [TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check fact name.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FactNameTestCase()
        {
            GivenCreateOtherFact(DateTime.Now)
                .When("Create factInfo", fact => fact.GetFactType())
                .Then("Check result", factInfo => Assert.AreEqual(nameof(OtherFact), factInfo.FactName, "not expected fact name"));
        }

        [TestMethod]
        [TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NoDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create NoDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NoDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a NoDerived fact using the wrong type.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateNoDerivedUsingWrongTypeTestCase()
        {
            string expectedReason = $"{typeof(OtherFact).FullName} does not implement {typeof(INoDerivedFact).FullName} type.";

            GivenCreateFactType<OtherFact>()
                .When("Create NoDerived fact", factType => ExpectedException<FactFactoryException>(() => factType.CreateSpecialFact<INoDerivedFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NoDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a NoDerived fact without default constructor.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateNoDerivedWithoutDefaultConstructorTestCase()
        {
            string expectedReason = $"{typeof(NoDerivedWithoutConstructor).FullName} doesn't have a default constructor.";

            GivenCreateFactType<NoDerivedWithoutConstructor>()
                .When("Create NoDerived fact", factType => ExpectedException<FactFactoryException>(() => factType.CreateSpecialFact<INoDerivedFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create NotContained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a NotContained fact using the wrong type.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateNotContainedUsingWrongTypeTestCase()
        {
            string expectedReason = $"{typeof(OtherFact).FullName} does not implement {typeof(INotContainedFact).FullName} type.";

            GivenCreateFactType<OtherFact>()
                .When("Create NoDerived fact", factType => ExpectedException<FactFactoryException>(() => factType.CreateSpecialFact<INotContainedFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a NotContained fact without default constructor.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateNotContainedWithoutDefaultConstructorTestCase()
        {
            string expectedReason = $"{typeof(NotContainedWithoutConstructor).FullName} doesn't have a default constructor.";

            GivenCreateFactType<NotContainedWithoutConstructor>()
                .When("Create NoDerived fact", factType => ExpectedException<FactFactoryException>(() => factType.CreateSpecialFact<INotContainedFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create NoDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateCanDerivedFactTestCase()
        {
            GivenCreateFactType<CanDerived<OtherFact>>()
                .When("Create CanDerived fact", factType => factType.CreateSpecialFact<ICanDerivedFact>())
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact, "fact cannot be null");
                    Assert.IsTrue(fact is CanDerived<OtherFact>, "Expected another type");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a CanDerived fact using the wrong type.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateCanDerivedUsingWrongTypeTestCase()
        {
            string expectedReason = $"{typeof(OtherFact).FullName} does not implement {typeof(ICanDerivedFact).FullName} type.";

            GivenCreateFactType<OtherFact>()
                .When("Create CanDerived fact", factType => ExpectedException<FactFactoryException>(() => factType.CreateSpecialFact<ICanDerivedFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a CanDerived fact without default constructor.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateCanDerivedWithoutDefaultConstructorTestCase()
        {
            string expectedReason = $"{typeof(CanDerivedWithoutConstructor).FullName} doesn't have a default constructor.";

            GivenCreateFactType<CanDerivedWithoutConstructor>()
                .When("Create CanDerived fact", factType => ExpectedException<FactFactoryException>(() => factType.CreateSpecialFact<ICanDerivedFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }
    }
}
