using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Entities;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GetcuReone.FactFactoryTests.Fact
{
    [TestClass]
    public sealed class AddParameterTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add fact parameter with empty code.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddFactParameterWithEmptyCodeTestCase()
        {
            var obj = new object();

            Given("Create fact.", () => new DateTimeFact(default))
                .When("Add parameter.", fact =>
                    ExpectedException<ArgumentNullException>(() => fact.AddParameter(new FactParameter(null, obj))))
                .ThenIsNotNull()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add two parameters with the same code.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddTwoParametersWithSameCodeTestCase()
        {
            const string code = "FactParamCode";
            const string expectedMessage = "FactParameter with FactParamCode code already contained.";

            Given("Create fact.", () => new DateTimeFact(default))
                .And("Add parameter.", fact => 
                    fact.AddParameter(new FactParameter(code, new object())))
                .When("Add parameter.", fact =>
                    ExpectedException<ArgumentException>(() => fact.AddParameter(new FactParameter(code, new object()))))
                .ThenIsNotNull()
                .AndAreEqual(error => error.Message, expectedMessage)
                .Run();
        }
    }
}
