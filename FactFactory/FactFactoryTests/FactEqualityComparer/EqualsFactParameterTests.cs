﻿using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.FactFactoryTests.CommonFacts;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                .When("Run EqualsFactParameter.", comparer => 
                    comparer.EqualsFactParameter(null, null))
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
                .When("Run EqualsFactParameter.", comparer =>
                    comparer.EqualsFactParameter(new FactParameter(factParamCode, null), null))
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
                .When("Run EqualsFactParameter.", comparer =>
                    comparer.EqualsFactParameter(null, new FactParameter(factParamCode, null)))
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
                .When("Run EqualsFactParameter.", comparer =>
                    comparer.EqualsFactParameter(firstParam, secondParam))
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
                .When("Create object.", comparer =>
                    comparer.EqualsFactParameter(firstParam, secondParam))
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
                .When("Run EqualsFactParameter.", comparer =>
                    comparer.EqualsFactParameter(firstParam, secondParam))
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
                .When("Run EqualsFactParameter.", comparer =>
                    comparer.EqualsFactParameter(firstParam, secondParam))
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
                .When("Run EqualsFactParameter.", comparer =>
                    comparer.EqualsFactParameter(firstParam, secondParam))
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
                .When("Run EqualsFactParameter.", comparer =>
                    comparer.EqualsFactParameter(firstParam, secondParam))
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
                .When("Run EqualsFactParameter.", comparer =>
                    comparer.EqualsFactParameter(firstParam, secondParam))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Different values condition facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DifferentValuesConditionFactsTestCase()
        {
            const string factParamCode = "factParamCode";
            var firstParam = new FactParameter(factParamCode, new Contained<IntFact>());
            var secondParam = new FactParameter(factParamCode, new Contained<OtherFact>());

            GivenCreateComparer()
                .When("Run EqualsFactParameter.", comparer =>
                    comparer.EqualsFactParameter(firstParam, secondParam))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Same values condition facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SameValuesConditionFactsTestCase()
        {
            const string factParamCode = "factParamCode";
            var firstParam = new FactParameter(factParamCode, new Contained<IntFact>());
            var secondParam = new FactParameter(factParamCode, new Contained<IntFact>());

            GivenCreateComparer()
                .When("Run EqualsFactParameter.", comparer =>
                    comparer.EqualsFactParameter(firstParam, secondParam))
                .ThenIsFalse()
                .Run();
        }
    }
}