using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.WantAction
{
    [TestClass]
    public sealed class WantActionTests : CommonTestBase<FactBase>
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create WantAction without action.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Run invoke.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void InvokeTestCase()
        {
            bool isRun = false;

            Given("Create WantAction", () => new WAction(ct => isRun = true, new List<IFactType> { GetFactType<OtherFact>() }))
                .When("Run method", wantAction => wantAction.Invoke(new GetcuReone.FactFactory.Entities.FactContainer()))
                .Then("Check result", _ => Assert.IsTrue(isRun, "Invoke not run"));
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create WantAction without input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request entry is not a valid fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void WantAction_RequestEntryInvalidFactTestCase()
        {
            string expectedReason = $"InvalidFact types are not inherited from {typeof(FactBase).FullName}.";

            GivenEmpty()
                .When("Create wantAction", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new WAction(ct => { }, new List<IFactType> { GetFactType<InvalidFact>() }));
                })
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error is null");
                    Assert.AreEqual(expectedReason, ex.Message, "Another message expected");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request invalid special fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RequestInvalidSpecialFactTestCase()
        {
            IFactType invalidFactType = GetFactType<InvalidSpecialFact>();
            string expectedReason = $"{invalidFactType.FactName} implements more than one runtime special fact interface.";

            GivenEmpty()
                .When("Create wantAction", _ =>
                {
                    return ExpectedFactFactoryException(
                        () => new WAction(ct => { }, new List<IFactType> { invalidFactType }));
                })
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }
    }
}
