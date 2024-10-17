using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.FactFactoryTests.CommonFacts;
using GetcuReone.FactFactoryTests.SingleEntityOperationsTests.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.FactFactoryTests.SingleEntityOperationsTests
{
    [TestClass]
    public sealed class EqualsFactParametersTests : SingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Empty fact parameters.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void EmptyFactParametersTestCase()
        {
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run EqualsFactParameters.", facade =>
                    facade.EqualsFactParameters(null, null, context))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("First parameter is null.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FirstParameterIsNullTestCase()
        {
            const string factParamCode = "factParamCode";
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run EqualsFactParameters.", facade =>
                    facade.EqualsFactParameters(new FactParameter(factParamCode, null), null, context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Second parameter is null.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SecondParameterIsNullTestCase()
        {
            const string factParamCode = "factParamCode";
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run EqualsFactParameters.", facade =>
                    facade.EqualsFactParameters(null, new FactParameter(factParamCode, null), context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Fact parameters value is empty.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void EmptyValueTestCase()
        {
            const string factParamCode = "factParamCode";
            var firstParam = new FactParameter(factParamCode, null);
            var secondParam = new FactParameter(factParamCode, null);
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run EqualsFactParameters.", facade =>
                    facade.EqualsFactParameters(firstParam, secondParam, context))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("First parameter is null.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FirstParameterValueIsNullTestCase()
        {
            const string factParamCode = "factParamCode";
            var firstParam = new FactParameter(factParamCode, null);
            var secondParam = new FactParameter(factParamCode, new object());
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run EqualsFactParameters.", facade =>
                    facade.EqualsFactParameters(firstParam, secondParam, context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Second parameter is null.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SecondParameterValueIsNullTestCase()
        {
            const string factParamCode = "factParamCode";
            var firstParam = new FactParameter(factParamCode, new object());
            var secondParam = new FactParameter(factParamCode, null);
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run EqualsFactParameters.", facade =>
                    facade.EqualsFactParameters(firstParam, secondParam, context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Different values of the fact parameters.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DifferentValuesFactParametersTestCase()
        {
            const string factParamCode = "factParamCode";
            var firstParam = new FactParameter(factParamCode, new object());
            var secondParam = new FactParameter(factParamCode, new object());
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run EqualsFactParameters.", facade =>
                    facade.EqualsFactParameters(firstParam, secondParam, context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Same values of the fact parameters.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SameValuesFactParametersTestCase()
        {
            const string factParamCode = "factParamCode";
            var firstParam = new FactParameter(factParamCode, new object());
            var secondParam = new FactParameter(factParamCode, firstParam.Value);
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run EqualsFactParameters.", facade =>
                    facade.EqualsFactParameters(firstParam, secondParam, context))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Different values special facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DifferentValuesSpecialFactsTestCase()
        {
            const string factParamCode = "factParamCode";
            var firstParam = new FactParameter(factParamCode, new SpecialFact1());
            var secondParam = new FactParameter(factParamCode, new SpecialFact2());
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run EqualsFactParameters.", facade =>
                    facade.EqualsFactParameters(firstParam, secondParam, context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Same values special facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SameValuesSpecialFactsTestCase()
        {
            const string factParamCode = "factParamCode";
            var firstParam = new FactParameter(factParamCode, new SpecialFact());
            var secondParam = new FactParameter(factParamCode, new SpecialFact());
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run EqualsFactParameters.", facade =>
                    facade.EqualsFactParameters(firstParam, secondParam, context))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Different values build condition facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DifferentValuesConditionFactsTestCase()
        {
            const string factParamCode = "factParamCode";
            var firstParam = new FactParameter(factParamCode, new FbContained<IntFact>());
            var secondParam = new FactParameter(factParamCode, new FbContained<OtherFact>());
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run EqualsFactParameters.", facade =>
                    facade.EqualsFactParameters(firstParam, secondParam, context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Same values build condition facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SameValuesConditionFactsTestCase()
        {
            const string factParamCode = "factParamCode";
            var firstParam = new FactParameter(factParamCode, new FbContained<IntFact>());
            var secondParam = new FactParameter(factParamCode, new FbContained<IntFact>());
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run EqualsFactParameters.", facade =>
                    facade.EqualsFactParameters(firstParam, secondParam, context))
                .ThenIsFalse()
                .Run();
        }
    }
}
