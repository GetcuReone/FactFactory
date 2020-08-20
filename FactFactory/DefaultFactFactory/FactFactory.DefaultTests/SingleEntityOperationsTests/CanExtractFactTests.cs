using FactFactory.DefaultTests.SingleEntityOperationsTests.Env;
using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests
{
    [TestClass]
    public sealed class CanExtractFactTests : SingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Can extract.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CanExtractTestCase()
        {
            var container = new Container
            {
                new Input1Fact(default),
            };
            var rule = GetFactRule((Input1Fact _) => new ResultFact(default));
            var context = GetWantActionContext((IWantAction)null, container);

            GivenCreateFacade()
                .When("Check extract.", facade =>
                    facade.CanExtractFact<Input1Fact, IFactRule, IWantAction, Container>(rule, context))
                .ThenIsTrue();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Cannot extract.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CannotExtractTestCase()
        {
            var container = new Container
            {
                new Input1Fact(default),
            };
            var rule = GetFactRule((Input1Fact _) => new ResultFact(default));
            var context = GetWantActionContext((IWantAction)null, container);

            GivenCreateFacade()
                .When("Check extract.", facade =>
                    facade.CanExtractFact<Input2Fact, IFactRule, IWantAction, Container>(rule, context))
                .ThenIsFalse();
        }
    }
}
