﻿using FactFactory.TestsCommon;
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
        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.FactType)]
        [Description("Create WantAction without action")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.FactType)]
        [Description("Run invoke")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void InvokeTestCase()
        {
            bool isRun = false;

            Given("Create WantAction", () => new WAction(ct => isRun = true, new List<IFactType> { GetFactType<OtherFact>() }))
                .When("Run method", wantAction => wantAction.Invoke(new GetcuReone.FactFactory.Entities.FactContainer()))
                .Then("Check result", _ => Assert.IsTrue(isRun, "Invoke not run"));
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.FactType)]
        [Description("Create WantAction without input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.FactType)]
        [Description("Request entry is not a valid fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
