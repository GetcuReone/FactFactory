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
    public sealed class CannotDerivedTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.CannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for CannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForCannotDerivedFactTestCase()
        {
            GivenEmpty()
                .When("Create CannotDerived.", () => new CannotDerived<ResultFact>())
                .Then("Check fact type.", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<CannotDerived<ResultFact>>, "Expected another FactType.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Cannot use CannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CannotUseTestCase()
        {
            var container = new Container();

            Given("Add fact container.", () => container.Add(new ResultFact(default)))
                .And("Create fact.", () =>
                    new CannotDerived<ResultFact>())
                .When("Call Condition method.", cannotDerived =>
                    cannotDerived.Condition<Rule, WAction, Container>(null, null, container))
                .Then("Check result.", result =>
                    Assert.IsFalse(result, "CannotDerived can use."));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Can use CanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CanUseTestCase()
        {
            var container = new Container();

            Given("Create fact.", () => new CannotDerived<ResultFact>())
                .When("Call Condition method.", cannotDerived =>
                    cannotDerived.Condition<Rule, WAction, Container>(null, null, container))
                .Then("Check result.", result =>
                    Assert.IsTrue(result, "CannotDerived cannot use."));
        }
    }
}
