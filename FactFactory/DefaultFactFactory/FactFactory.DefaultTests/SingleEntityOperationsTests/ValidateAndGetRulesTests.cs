using FactFactory.DefaultTests.SingleEntityOperationsTests.Env;
using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Constants;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests
{
    [TestClass]
    public sealed class ValidateAndGetRulesTests : SingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rules cannot be null.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RulesCannotBeNullTestCase()
        {
            const string expectedReason = "Rules cannot be null.";
            Collection collection = null;

            GivenCreateFacade()
                .When("Run method ValidateAndGetRules.", facade =>
                    ExpectedDeriveException(() => facade.ValidateAndGetRules<FactBase, Rule, Collection>(collection)))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive with rules returning a blank copy.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveWithRulesReturningBlankCopyTestCase()
        {
            const string expectedReason = "IFactRuleCollection.Copy method return null.";
            var collection = new RulesGetNull();

            GivenCreateFacade()
                .When("Run method ValidateAndGetRules.", facade =>
                    ExpectedDeriveException(() => facade.ValidateAndGetRules<FactBase, Rule, Collection>(collection)))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive with rules returning a different type of rules.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveWithRulesReturningDifferentTypeRulesTestCase()
        {
            const string expectedReason = "IFactRuleCollection.Copy method returned a different type of rules.";
            var collection = new RulesGetDifferent();

            GivenCreateFacade()
                .When("Run method ValidateAndGetRules.", facade =>
                    ExpectedDeriveException(() => facade.ValidateAndGetRules<FactBase, Rule, Collection>(collection)))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get original container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetOriginalContainerTestCase()
        {
            const string expectedReason = "IFactRuleCollection.Copy method return original rule collection.";
            var collection = new FactRuleCollectionGetOriginal();

            GivenCreateFacade()
                .When("Run method ValidateAndGetRules.", facade =>
                    ExpectedDeriveException(() => facade.ValidateAndGetRules<FactBase, Rule, Collection>(collection)))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }
    }
}
