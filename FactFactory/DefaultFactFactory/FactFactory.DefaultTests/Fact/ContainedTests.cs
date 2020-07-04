using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactory.DefaultTests.Fact
{
    [TestClass]
    public sealed class ContainedTests : CommonTestBase<FactBase>
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.Contained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for Contained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create CanDerived", () => new CanDerived<ResultFact>())
                .Then("Check fact type", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<CanDerived<ResultFact>>, "Expected another FactType.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.Contained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Can use CanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CanUseTestCase()
        {
            var container = new Container();

            Given("Add fact container.", () => container.Add(new ResultFact(default)))
                .And("Create fact.", () =>
                    new Contained<ResultFact>())
                .When("Call CanUse method.", contained =>
                    contained.CanUse<FactBase, Rule, WAction, Container>(null, null, container))
                .Then("Check result.", result =>
                    Assert.IsTrue(result, "Contained cannot use."));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.Contained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Cannot use Contained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CannotUseTestCase()
        {
            var container = new Container();

            Given("Create fact.", () =>new Contained<ResultFact>())
                .When("Call CanUse method.", contained =>
                    contained.CanUse<FactBase, Rule, WAction, Container>(null, null, container))
                .Then("Check result.", result =>
                    Assert.IsFalse(result, "Contained can use."));
        }
    }
}
