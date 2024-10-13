using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Entities;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace GetcuReone.FactFactoryTests.Fact
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
                .ThenFactValueEquals(operationDate)
                .Run();
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
                    Assert.IsTrue(factInfo is FactType<DateTimeFact>, "a different type of factual information was expected"))
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get fact parameter.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactParameterTestCase()
        {
            const string code = "factParamCode";
            var obj = new object();

            Given("Create fact.", () => new DateTimeFact(DateTime.Now))
                .And("Add parameter.", fact =>
                    fact.AddParameter(new FactParameter(code, obj)))
                .When("Get parameter.", fact =>
                    fact.FindParameter(code))
                .ThenIsNotNull(errorMessage: "factParameter is null.")
                .AndAreEqual(parameter => parameter.Code, code,
                    errorMessage: "Other parameter code expected.")
                .AndAreEqual(parameter => parameter.Value, obj,
                    errorMessage: "Other parameter value expected.")
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get fact parameters.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactParametersTestCase()
        {
            const string code1 = "factParamCode1";
            var obj1 = new object();
            const string code2 = "factParamCode2";
            var obj2 = new object();

            Given("Create fact.", () => new DateTimeFact(DateTime.Now))
                .And("Add parameter 1.", fact =>
                    fact.AddParameter(new FactParameter(code1, obj1)))
                .And("Add parameter 2.", fact =>
                    fact.AddParameter(new FactParameter(code2, obj2)))
                .When("Get parameter.", fact =>
                    fact.GetParameters())
                .ThenIsNotNull(errorMessage: "factParameter is null.")
                .AndAreEqual(parameters => parameters.Count, 2,
                    errorMessage: "Different number of parameters expected.")
                .AndAreEqual(parameters => parameters.First().Code, code1,
                    errorMessage: "Other parameter1 code expected")
                .AndAreEqual(parameters => parameters.First().Value, obj1,
                    errorMessage: "Other parameter1 value expected.")
                .AndAreEqual(parameters => parameters.Skip(1).First().Code, code2,
                    errorMessage: "Other parameter2 code expected")
                .AndAreEqual(parameters => parameters.Skip(1).First().Value, obj2,
                    errorMessage: "Other parameter2 value expected.")
                .Run();
        }
    }
}
