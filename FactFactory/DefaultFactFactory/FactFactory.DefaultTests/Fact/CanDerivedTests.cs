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
    [Ignore]
    public sealed class CanDerivedTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for CanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForCanDerivedFactTestCase()
        {
            GivenEmpty()
                .When("Create CanDerived.", () => new CanDerived<ResultFact>())
                .Then("Check fact type.", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<CanDerived<ResultFact>>, "Expected another FactType.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Can use CanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CanUseTestCase()
        {
            var container = new Container();

            Given("Add fact container.", () => container.Add(new ResultFact(default)))
                .And("Create fact.", () =>
                    new CanDerived<ResultFact>())
                .When("Call Condition method.", canDerived =>
                    canDerived.Condition<Rule, WAction, Container>(null, null, container))
                .Then("Check result.", result =>
                    Assert.IsTrue(result, "CanDerived cannot use."));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Cannot use CanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CannotUseTestCase()
        {
            var container = new Container();

            Given("Create fact.", () =>new CanDerived<ResultFact>())
                .When("Call Condition method.", canDerived =>
                    canDerived.Condition<Rule, WAction, Container>(null, null, container))
                .Then("Check result.", result =>
                    Assert.IsFalse(result, "CanDerived can use."));
        }
    }
}
