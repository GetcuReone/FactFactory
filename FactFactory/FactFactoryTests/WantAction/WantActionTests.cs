using GetcuReone.FactFactory.Interfaces;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.WantAction
{
    [TestClass]
    public sealed class WantActionTests : TestBase
    {
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][action][negative] create WantAction without action")]
        public void CreateWantActionWithoutActionTestCase()
        {
            GivenEmpty()
                .When("Create WantAction", _ => ExpectedException<ArgumentNullException>(() => new WAction(null, null)))
                .Then("Check error", ex => Assert.IsNotNull(ex, "error is null"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][action][negative] run invoke")]
        public void InvokeTestCase()
        {
            bool isRun = false;

            Given("Create WantAction", () => new WAction(ct => isRun = true, new List<IFactType>()))
                .When("Run method", wantAction => wantAction.Invoke(new GetcuReone.FactFactory.Entities.FactContainer()))
                .Then("Check result", _ => Assert.IsTrue(isRun, "Invoke not run"));
        }
    }
}
