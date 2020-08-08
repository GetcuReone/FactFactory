using FactFactory.DefaultTests.CommonFacts;
using FactFactory.DefaultTests.SingleEntityOperationsTests.Env;
using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests
{
    [TestClass]
    public sealed class CompareFactWorksTests : SingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compare want actions.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CompareActionsTestCase()
        {
            var firstWA = GetWantAction((Input1Fact _) => { });
            var secondWA = GetWantAction((Input2Fact _) => { });
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Compare want actions.", facade => facade.CompareFactWorks<FactBase, FactWorkBase<FactBase>, WantActionBase<FactBase>, FactContainerBase<FactBase>>(firstWA, secondWA, null, null))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compare want action and rule.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CompareActionAndRuleTestCase()
        {
            var action = GetWantAction((Input1Fact _) => { });
            var rule = GetFactRule((Input2Fact _) => new ResultFact(default));
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Compare want action and rule.", facade => facade.CompareFactWorks<FactBase, FactWorkBase<FactBase>, WantActionBase<FactBase>, FactContainerBase<FactBase>>(action, rule, null, null))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules without special facts (1).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithoutSpecialFacts_1_TestCase()
        {
            var first = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _) => new ResultFact(default));
            const int expectedValue = -1;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactWorks<FactBase, FactWorkBase<FactBase>, WantActionBase<FactBase>, FactContainerBase<FactBase>>(first, second, null, null))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules without special facts (2).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithoutSpecialFacts_2_TestCase()
        {
            var first = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactWorks<FactBase, FactWorkBase<FactBase>, WantActionBase<FactBase>, FactContainerBase<FactBase>>(first, second, null, null))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules without special facts (3).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonRulesWithoutSpecialFacts_3_TestCase()
        {
            var first = GetFactRule((Input1Fact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            const int expectedValue = 1;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactWorks<FactBase, FactWorkBase<FactBase>, WantActionBase<FactBase>, FactContainerBase<FactBase>>(first, second, null, null))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with special facts (1).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonWithSpecialFacts_1_TestCase()
        {
            var first = GetFactRule((Input2Fact _, SpecialFact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            const int expectedValue = 1;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactWorks<FactBase, FactWorkBase<FactBase>, WantActionBase<FactBase>, FactContainerBase<FactBase>>(first, second, null, null))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with special facts (2).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonWithSpecialFacts_2_TestCase()
        {
            var first = GetFactRule((Input2Fact _, SpecialFact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _, SpecialFact __) => new ResultFact(default));
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactWorks<FactBase, FactWorkBase<FactBase>, WantActionBase<FactBase>, FactContainerBase<FactBase>>(first, second, null, null))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with special facts (3).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonWithSpecialFacts_3_TestCase()
        {
            var first = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _, SpecialFact __) => new ResultFact(default));
            const int expectedValue = -1;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactWorks<FactBase, FactWorkBase<FactBase>, WantActionBase<FactBase>, FactContainerBase<FactBase>>(first, second, null, null))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with condition facts (1).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonWithConditionFacts_1_TestCase()
        {
            var first = GetFactRule((SpecialFact _, Condition_ContainedOtherFact __) => new ResultFact(default));
            var second = GetFactRule((SpecialFact _, Input1Fact __) => new ResultFact(default));
            const int expectedValue = 1;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactWorks<FactBase, FactWorkBase<FactBase>, WantActionBase<FactBase>, FactContainerBase<FactBase>>(first, second, null, null))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with condition facts (2).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonWithConditionFacts_2_TestCase()
        {
            var first = GetFactRule((SpecialFact _, Condition_ContainedOtherFact __) => new ResultFact(default));
            var second = GetFactRule((SpecialFact _, Condition_ContainedOtherFact __) => new ResultFact(default));
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactWorks<FactBase, FactWorkBase<FactBase>, WantActionBase<FactBase>, FactContainerBase<FactBase>>(first, second, null, null))
                .ThenAreEqual(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of rules with condition facts (3).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ComparisonWithConditionFacts_3_TestCase()
        {
            var first = GetFactRule((SpecialFact _, Input1Fact __) => new ResultFact(default));
            var second = GetFactRule((SpecialFact _, Condition_ContainedOtherFact __) => new ResultFact(default));
            const int expectedValue = -1;

            GivenCreateFacade()
                .When("Compare rules.", facade => facade.CompareFactWorks<FactBase, FactWorkBase<FactBase>, WantActionBase<FactBase>, FactContainerBase<FactBase>>(first, second, null, null))
                .ThenAreEqual(expectedValue);
        }
    }
}
