using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactType.Env;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework;
using GetcuReone.GwtTestFramework.Entities;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FactFactoryTests.FactType
{
    [TestClass]
    public sealed class FactTypeTest : TestBase
    {
        private GivenBlock<object, OtherFact> GivenCreateOtherFact(DateTime dateTime)
        {
            return Given("Create OthreFact.", () => new OtherFact(dateTime));
        }

        private GivenBlock<object, FactType<TFact>> GivenCreateFactType<TFact>()
            where TFact : IFact
        {
            return Given($"Create fact type for {typeof(TFact).Name}.", () => new FactType<TFact>());
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

            Given("Create fact.", () => { fact = new DateTimeFact(DateTime.Now); })
                .When("Create fact info.", _ =>
                {
                    first = fact.GetFactType();
                    second = fact.GetFactType();
                })
                .Then("Compare factInfos.", () => 
                    Assert.IsTrue(first.EqualsFactType(second), "Actual information is the same."))
                .Run();
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

            Given("Create fact.", () => 
            { 
                firstFact = new DateTimeFact(DateTime.Now);
                secondFact = new DateTimeFact(DateTime.Now);
            })
                .When("Create fact info.", _ =>
                {
                    first = firstFact.GetFactType();
                    second = secondFact.GetFactType();
                })
                .Then("Compare factInfos", () => 
                    Assert.IsTrue(first.EqualsFactType(second), "Actual information is the same."))
                .Run();
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

            Given("Create fact.", () =>
            {
                firstFact = new DateTimeFact(DateTime.Now);
                secondFact = new OtherFact(firstFact.Value);
            })
                .When("Create fact info.", _ =>
                {
                    first = firstFact.GetFactType();
                    second = secondFact.GetFactType();
                })
                .Then("Compare factInfos", () => 
                    Assert.IsFalse(first.EqualsFactType(second), "Actual information is the same."))
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check fact name.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FactNameTestCase()
        {
            GivenCreateOtherFact(DateTime.Now)
                .When("Create factInfo.", fact => 
                    fact.GetFactType())
                .ThenAreEqual(factInfo => factInfo.FactName, nameof(OtherFact),
                    errorMessage: "Not expected fact name.")
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.BuildCannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create BuildCannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateBuildCannotDerivedFactTestCase()
        {
            GivenCreateFactType<BuildCannotDerived<OtherFact>>()
                .When("Create BuildCannotDerived fact.", factType => 
                    factType.CreateBuildConditionFact<IBuildConditionFact>())
                .ThenIsNotNull()
                .AndIsTrue(fact => fact is BuildCannotDerived<OtherFact>,
                    errorMessage: "Expected another type.")
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.BuildCannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a BuildCannotDerived fact using the wrong type.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateBuildCannotDerivedUsingWrongTypeTestCase()
        {
            string expectedReason = $"{typeof(OtherFact).FullName} does not implement {typeof(IBuildConditionFact).FullName} type.";

            GivenCreateFactType<OtherFact>()
                .When("Create BuildCannotDerived fact.", factType => 
                    ExpectedException<FactFactoryException>(() => factType.CreateBuildConditionFact<IBuildConditionFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.BuildNotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create BuildNotContained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateBuildNotContainedFactTestCase()
        {
            GivenCreateFactType<BuildNotContained<OtherFact>>()
                .When("Create BuildNotContained fact.", factType => 
                    factType.CreateBuildConditionFact<BuildConditionFactBase>())
                .ThenIsNotNull()
                .AndIsTrue(fact => fact is BuildNotContained<OtherFact>,
                    errorMessage: "Expected another type.")
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.BuildNotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a BuildNotContained fact using the wrong type.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateBuildNotContainedUsingWrongTypeTestCase()
        {
            string expectedReason = $"{typeof(OtherFact).FullName} does not implement {typeof(BuildConditionFactBase).FullName} type.";

            GivenCreateFactType<OtherFact>()
                .When("Create BuildNotContained fact.", factType => 
                    ExpectedException<FactFactoryException>(() => factType.CreateBuildConditionFact<BuildConditionFactBase>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.BuildNotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a BuildNotContained fact without default constructor.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateBuildNotContainedWithoutDefaultConstructorTestCase()
        {
            string expectedReason = $"{typeof(NotContainedWithoutConstructor).FullName} doesn't have a default constructor.";

            GivenCreateFactType<NotContainedWithoutConstructor>()
                .When("Create BuildNotContained fact.", factType => 
                    ExpectedException<FactFactoryException>(() => factType.CreateBuildConditionFact<BuildConditionFactBase>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.BuildCanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create BuildCanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateBuildCanDerivedFactTestCase()
        {
            GivenCreateFactType<BuildCanDerived<OtherFact>>()
                .When("Create CanDerived fact.", factType => 
                    factType.CreateBuildConditionFact<IBuildConditionFact>())
                .ThenIsNotNull()
                .AndIsTrue(fact => fact is BuildCanDerived<OtherFact>,
                    errorMessage: "Expected another type.")
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.BuildCanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a BuildCanDerived fact using the wrong type.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateBuildCanDerivedUsingWrongTypeTestCase()
        {
            string expectedReason = $"{typeof(OtherFact).FullName} does not implement {typeof(IBuildConditionFact).FullName} type.";

            GivenCreateFactType<OtherFact>()
                .When("Create BuildCanDerived fact.", factType => 
                    ExpectedException<FactFactoryException>(() => factType.CreateBuildConditionFact<IBuildConditionFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(TC.Objects.BuildCanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a Condition fact without default constructor.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateConditionWithoutConstructorTestCase()
        {
            string expectedReason = $"{typeof(ConditionWithoutConstructor).FullName} doesn't have a default constructor.";

            GivenCreateFactType<ConditionWithoutConstructor>()
                .When("Create CanDerived fact.", factType => 
                    ExpectedException<FactFactoryException>(() => factType.CreateBuildConditionFact<IBuildConditionFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason)
                .Run();
        }
    }
}
