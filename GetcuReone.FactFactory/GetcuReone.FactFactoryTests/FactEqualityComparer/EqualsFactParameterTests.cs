using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.FactFactoryTests.CommonFacts;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using F_EqualityComparer = GetcuReone.FactFactory.BaseEntities.FactEqualityComparer;

namespace GetcuReone.FactFactoryTests.FactEqualityComparer
{
    [TestClass]
    public sealed class EqualsFactParameterTests : FactEqualityComparerTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Empty fact parameters.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void EmptyFactParametersTestCase()
        {
            GivenCreateComparer()
                .When("Run EqualsFactParameters.", _ =>
                    F_EqualityComparer.EqualsFactParameters(null, null))
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

            GivenCreateComparer()
                .When("Run EqualsFactParameters.", _ =>
                    F_EqualityComparer.EqualsFactParameters(new FactParameter(factParamCode, null), null))
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

            GivenCreateComparer()
                .When("Run EqualsFactParameters.", _ =>
                    F_EqualityComparer.EqualsFactParameters(null, new FactParameter(factParamCode, null)))
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

            GivenCreateComparer()
                .When("Run EqualsFactParameters.", _ =>
                    F_EqualityComparer.EqualsFactParameters(firstParam, secondParam))
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

            GivenCreateComparer()
                .When("Create object.", _ =>
                    F_EqualityComparer.EqualsFactParameters(firstParam, secondParam))
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

            GivenCreateComparer()
                .When("Run EqualsFactParameters.", _ =>
                    F_EqualityComparer.EqualsFactParameters(firstParam, secondParam))
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

            GivenCreateComparer()
                .When("Run EqualsFactParameters.", _ =>
                    F_EqualityComparer.EqualsFactParameters(firstParam, secondParam))
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

            GivenCreateComparer()
                .When("Run EqualsFactParameters.", _ =>
                    F_EqualityComparer.EqualsFactParameters(firstParam, secondParam))
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

            GivenCreateComparer()
                .When("Run EqualsFactParameters.", _ =>
                    F_EqualityComparer.EqualsFactParameters(firstParam, secondParam))
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

            GivenCreateComparer()
                .When("Run EqualsFactParameters.", _ =>
                    F_EqualityComparer.EqualsFactParameters(firstParam, secondParam))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Different values build condition facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DifferentValuesBuildConditionFactsTestCase()
        {
            const string factParamCode = "factParamCode";
            var firstParam = new FactParameter(factParamCode, new FbContained<IntFact>());
            var secondParam = new FactParameter(factParamCode, new FbContained<OtherFact>());

            GivenCreateComparer()
                .When("Run EqualsFactParameters.", _ =>
                    F_EqualityComparer.EqualsFactParameters(firstParam, secondParam))
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

            GivenCreateComparer()
                .When("Run EqualsFactParameters.", _ =>
                    F_EqualityComparer.EqualsFactParameters(firstParam, secondParam))
                .ThenIsFalse()
                .Run();
        }
    }
}
