using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Facts;
using GivenWhenThen.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FactFactoryTests.Fact
{
    [TestClass]
    public sealed class FactTests : TestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact)]
        [Description("Set value fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void SetValueFactTestCase()
        {
            DateTime operationDate = DateTime.Now;

            Given("Empty", () => { })
                .When("Create fact", _ => new StartDateOfDerive(operationDate))
                .Then("Check value fact", fact => Assert.AreEqual(operationDate, fact.Value, "a different value of the fact was expected"));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact)]
        [Description("Check method GeTFactType")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GeTFactTypeTestCase()
        {
            Given("Create fact", () => new StartDateOfDerive(DateTime.Now))
                .When("Run method", fact => fact.GetFactType())
                .Then("Check result", factInfo => Assert.IsTrue(factInfo is FactType<StartDateOfDerive>, "a different type of factual information was expected"));
        }
    }
}
