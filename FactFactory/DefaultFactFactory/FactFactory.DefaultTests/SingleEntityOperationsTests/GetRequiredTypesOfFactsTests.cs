using FactFactory.DefaultTests.SingleEntityOperationsTests.Env;
using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests
{
    [TestClass]
    [Ignore]
    public sealed class GetRequiredTypesOfFactsTests : SingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Not required input1Fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void NotRequiredInput1FactTestCase()
        {
            var rule = GetFactRule((Input1Fact _) => new ResultFact(default));
            var wantAction = GetWantAction((ResultFact _) => { });

            GivenCreateFacade()
                .When("Check method.", facade =>
                    facade.GetRequiredTypesOfFacts(rule, GetWantActionContext(wantAction, Container)))
                .ThenIsNotNull()
                .And("Check result.", types =>
                {
                    Assert.AreEqual(0, types.Count());
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Required Input2Fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RequiredInput2FactTestCase()
        {
            var rule = GetFactRule((Input2Fact _) => new ResultFact(default));
            var wantAction = GetWantAction((ResultFact _) => { });

            GivenCreateFacade()
                .When("Check method.", facade =>
                    facade.GetRequiredTypesOfFacts(rule, GetWantActionContext(wantAction, Container)))
                .ThenIsNotNull()
                .And("Check result.", types =>
                {
                    Assert.AreEqual(1, types.Count());
                    Assert.IsTrue(types.First().IsFactType<Input2Fact>());
                });
        }
    }
}
