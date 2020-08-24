using FactFactory.DefaultTests.SingleEntityOperationsTests.Env;
using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests
{
    [TestClass]
    [Ignore]
    public sealed class CompatibleRuleTests : SingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compatible rules.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CompatibleRulesTestCase()
        {
            var first = GetFactRule((Input2Fact _, Input1Fact __) => new ResultFact(default));
            var second = GetFactRule((Input2Fact _) => new ResultFact(default));
            var context = GetWantActionContext((IWantAction)null, (IFactContainer)null);

            GivenCreateFacade()
                .When("Check compatible.", facade => 
                    facade.CompatibleRule(first, second, context))
                .ThenIsTrue();
        }
    }
}
