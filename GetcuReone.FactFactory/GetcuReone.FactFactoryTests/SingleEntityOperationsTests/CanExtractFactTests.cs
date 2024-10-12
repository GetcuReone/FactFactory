using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.SingleEntityOperationsTests.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.SingleEntityOperationsTests
{
    [TestClass]
    public sealed class CanExtractFactTests : SingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Can extract.")]
        [Timeout(Timeouts.Second.One)]
        public void CanExtractTestCase()
        {
            var container = new Container
            {
                new Input1Fact(default),
            };
            var rule = GetFactRule((Input1Fact _) => new ResultFact(default));
            var context = GetWantActionContext(null, container);

            GivenCreateFacade()
                .When("Check extract.", facade =>
                    facade.CanExtractFact(GetFactType<Input1Fact>(), rule, context))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Cannot extract.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CannotExtractTestCase()
        {
            var container = new Container
            {
            };
            var rule = GetFactRule((Input1Fact _) => new ResultFact(default));
            var context = GetWantActionContext(null, container);

            GivenCreateFacade()
                .When("Check extract.", facade =>
                    facade.CanExtractFact(GetFactType<Input1Fact>(), rule, context))
                .ThenIsFalse()
                .Run();
        }
    }
}
