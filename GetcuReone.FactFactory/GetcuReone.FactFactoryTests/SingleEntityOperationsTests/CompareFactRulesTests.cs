﻿using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactoryTests.SingleEntityOperationsTests.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.FactFactoryTests.SingleEntityOperationsTests
{
    [TestClass]
    public sealed class CompareFactRulesTests : SingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules without special facts (1).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithoutSpecialFacts_1_TestCase()
        {
            var first = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _) => new ResultFact(default));
            var context = GetWantActionContext(null, null);
            const int expectedValue = -1;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactRules(first, second, context))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules without special facts (2).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithoutSpecialFacts_2_TestCase()
        {
            var first = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            var context = GetWantActionContext(null, null);
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactRules(first, second, context))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules without special facts (3).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithoutSpecialFacts_3_TestCase()
        {
            var first = GetFactRule((Input1Fact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            var context = GetWantActionContext(null, null);
            const int expectedValue = 1;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactRules(first, second, context))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with special facts (1).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonWithSpecialFacts_1_TestCase()
        {
            var first = GetFactRule((Input2Fact _, SpecialFact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            var context = GetWantActionContext(null, null);
            const int expectedValue = 1;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactRules(first, second, context))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with special facts (2).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonWithSpecialFacts_2_TestCase()
        {
            var first = GetFactRule((Input2Fact _, SpecialFact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _, SpecialFact __) => new ResultFact(default));
            var context = GetWantActionContext(null, null);
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactRules(first, second, context))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with special facts (3).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonWithSpecialFacts_3_TestCase()
        {
            var first = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _, SpecialFact __) => new ResultFact(default));
            var context = GetWantActionContext(null, null);
            const int expectedValue = -1;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactRules(first, second, context))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with condition facts (1).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonWithConditionFacts_1_TestCase()
        {
            var first = GetFactRule((SpecialFact _, FbCondition_ContainedOtherFact __) => new ResultFact(default));
            var second = GetFactRule((SpecialFact _, Input1Fact __) => new ResultFact(default));
            var context = GetWantActionContext(null, null);
            const int expectedValue = 1;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactRules(first, second, context))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with condition facts (2).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonWithConditionFacts_2_TestCase()
        {
            var first = GetFactRule((SpecialFact _, FbCondition_ContainedOtherFact __) => new ResultFact(default));
            var second = GetFactRule((SpecialFact _, FbCondition_ContainedOtherFact __) => new ResultFact(default));
            var context = GetWantActionContext(null, null);
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactRules(first, second, context))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with condition facts (3).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonWithConditionFacts_3_TestCase()
        {
            var first = GetFactRule((SpecialFact _, Input1Fact __) => new ResultFact(default));
            var second = GetFactRule((SpecialFact _, FbCondition_ContainedOtherFact __) => new ResultFact(default));
            var context = GetWantActionContext(null, null);
            const int expectedValue = -1;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactRules(first, second, context))
                .ThenAreEqual(expectedValue)
                .Run();
        }
    }
}
