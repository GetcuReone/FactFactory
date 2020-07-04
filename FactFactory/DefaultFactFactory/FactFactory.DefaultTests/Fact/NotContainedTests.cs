using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactory.DefaultTests.Fact
{
    [TestClass]
    public sealed class NotContainedTests : CommonTestBase<FactBase>
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for CannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForNotContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContained", () => new NotContained<ResultFact>())
                .Then("Check fact type", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<NotContained<ResultFact>>, "Expected another FactType.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Cannot use NotContained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CannotUseTestCase()
        {
            var container = new Container();

            Given("Add fact container.", () => container.Add(new ResultFact(default)))
                .And("Create fact.", () =>
                    new NotContained<ResultFact>())
                .When("Call Condition method.", notContained =>
                    notContained.Condition<FactBase, Rule, WAction, Container>(null, null, container))
                .Then("Check result.", result =>
                    Assert.IsFalse(result, "NotContained can use."));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Can use CanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CanUseTestCase()
        {
            var container = new Container();

            Given("Create fact.", () => new NotContained<ResultFact>())
                .When("Call Condition method.", notContained =>
                    notContained.Condition<FactBase, Rule, WAction, Container>(null, null, container))
                .Then("Check result.", result =>
                    Assert.IsTrue(result, "NotContained cannot use."));
        }
    }
}
