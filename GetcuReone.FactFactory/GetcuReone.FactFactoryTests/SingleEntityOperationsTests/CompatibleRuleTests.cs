using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactoryTests.SingleEntityOperationsTests.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.FactFactoryTests.SingleEntityOperationsTests
{
    [TestClass]
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
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Check compatible.", facade =>
                    facade.CompatibleRule(first, second, context))
                .ThenIsTrue()
                .Run();
        }
    }
}
