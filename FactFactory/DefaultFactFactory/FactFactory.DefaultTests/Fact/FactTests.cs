using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
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
        [Description("Set value fact.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void SetValueFactTestCase()
        {
            DateTime operationDate = DateTime.Now;

            Given("Empty", () => { })
                .When("Create fact", _ => new DateTimeFact(operationDate))
                .Then("Check value fact", fact => Assert.AreEqual(operationDate, fact.Value, "a different value of the fact was expected"));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact)]
        [Description("Check method GetFactType.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetFactTypeTestCase()
        {
            Given("Create fact", () => new DateTimeFact(DateTime.Now))
                .When("Run method", fact => fact.GetFactType())
                .Then("Check result", factInfo => Assert.IsTrue(factInfo is FactType<DateTimeFact>, "a different type of factual information was expected"));
        }
    }
}
