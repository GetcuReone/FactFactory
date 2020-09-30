using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.WantAction
{
    [TestClass]
    public sealed class WantActionTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create WantAction without action.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateWantActionWithoutActionTestCase()
        {
            GivenEmpty()
                .When("Create WantAction.", _ => 
                    ExpectedException<ArgumentNullException>(() => new WAction((Action<IEnumerable<IFact>>)null, null, FactWorkOption.CanExecuteSync)))
                .ThenIsNotNull()
                .AndAreEqual(ex => ex.ParamName, "wantAction",
                    errorMessage: "Expectend another property name.");
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Run invoke.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void InvokeTestCase()
        {
            bool isRun = false;

            Given("Create WantAction.", () => new WAction(ct => isRun = true, new List<IFactType> { GetFactType<OtherFact>() }, FactWorkOption.CanExecuteSync))
                .When("Run method.", wantAction => 
                    wantAction.Invoke(new GetcuReone.FactFactory.Entities.FactContainer()))
                .Then("Check result.", _ => 
                    Assert.IsTrue(isRun, "Invoke not run."));
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create WantAction without input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateWantActionWithoutInputFactsTestCase()
        {
            const string expectedReason = "factTypes cannot be empty. The desired action should request a fact on entry.";
            GivenEmpty()
                .When("Create WantAction.", _ => 
                    ExpectedException<ArgumentException>(() => new WAction(ct => { }, null, FactWorkOption.CanExecuteSync)))
                .ThenIsNotNull()
                .And("Check error.", ex =>
                {
                    Assert.AreEqual(expectedReason, ex.Message, "Expectend another message.");
                });
        }
    }
}
