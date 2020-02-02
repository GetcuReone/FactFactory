using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Facts;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FactFactoryTests.Fact
{
    [TestClass]
    public sealed class FactTests : TestBase
    {
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact] set value fact")]
        public void SetValueFactTestCase()
        {
            DateTime operationDate = DateTime.Now;

            Given("Empty", () => { })
                .When("Create fact", _ => new DateOfDeriveFact(operationDate))
                .Then("Check value fact", fact => Assert.AreEqual(operationDate, fact.Value, "a different value of the fact was expected"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact] check method GeTFactType")]
        public void GeTFactTypeTestCase()
        {
            Given("Create fact", () => new DateOfDeriveFact(DateTime.Now))
                .When("Run method", fact => fact.GetFactType())
                .Then("Check result", factInfo => Assert.IsTrue(factInfo is FactInfo<DateOfDeriveFact>, "a different type of factual information was expected"));
        }
    }
}
