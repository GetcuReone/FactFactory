using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GivenWhenThen.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.WantAction
{
    [TestClass]
    public sealed class WantActionTests : CommonTestBase
    {
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[want_action][negative] create WantAction without action")]
        public void CreateWantActionWithoutActionTestCase()
        {
            GivenEmpty()
                .When("Create WantAction", _ => ExpectedException<ArgumentNullException>(() => new WAction(null, null)))
                .Then("Check error", ex => 
                {
                    Assert.IsNotNull(ex, "error is null");
                    Assert.AreEqual("wantAction", ex.ParamName, "Expectend another property name");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[want_action][negative] run invoke")]
        public void InvokeTestCase()
        {
            bool isRun = false;

            Given("Create WantAction", () => new WAction(ct => isRun = true, new List<IFactType> { GetFactType<OtherFact>() }))
                .When("Run method", wantAction => wantAction.Invoke(new GetcuReone.FactFactory.Entities.FactContainer()))
                .Then("Check result", _ => Assert.IsTrue(isRun, "Invoke not run"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[want_action][negative] create WantAction without input facts")]
        public void CreateWantActionWithoutInputFactsTestCase()
        {
            GivenEmpty()
                .When("Create WantAction", _ => ExpectedException<ArgumentException>(() => new WAction(ct => { }, null)))
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error is null");
                    Assert.AreEqual("factTypes cannot be empty. The desired action should request a fact on entry.", ex.Message, "Expectend another message");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[want_action][negative] request entry is not a valid fact")]
        public void WantAction_RequestEntryInvalidFactTestCase()
        {
            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new WAction(ct => { }, new List<IFactType> { GetFactType<InvalidFact>() }));
                })
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error is null");
                    Assert.AreEqual("InvalidFact types are not inherited from GetcuReone.FactFactory.Facts.FactBase", ex.Message, "Another message expected");
                });
        }
    }
}
