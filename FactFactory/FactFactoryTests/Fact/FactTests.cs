using System;
using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.Fact
{
    [TestClass]
    public sealed class FactTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Set value fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SetValueFactTestCase()
        {
            DateTime operationDate = DateTime.Now;

            GivenEmpty()
                .When("Create fact.", _ => 
                    new DateTimeFact(operationDate))
                .ThenFactEquals(operationDate);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check method GetFactType.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeTestCase()
        {
            Given("Create fact.", () => new DateTimeFact(DateTime.Now))
                .When("Run method.", fact => 
                    fact.GetFactType())
                .Then("Check result.", factInfo => 
                    Assert.IsTrue(factInfo is FactType<DateTimeFact>, "a different type of factual information was expected"));
        }
    }
}
