using FactFactory.Consts;
using FactFactory.Entities;
using FactFactory.Exceptions;
using FactFactory.Facts;
using FactFactoryTests.CommonFacts;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class WantFactTests : FactFactoryTestBase
    {
        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] Want not available fact")]
        public void WantNotAvailableFactTestCase()
        {
            GivenCreateFactFactory()
                .When("Want fact", factory => ExpectedException<FactFactoryException>(() => factory.WantFact((CurrentFactsFindingFact fact) => { })))
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.IsNotNull(ex.Details, "error cannot be null");
                    Assert.AreEqual(1, ex.Details.Count, "Details must contain 1 detail");

                    ErrorDetail detail = ex.Details[0];
                    Assert.AreEqual(ErrorCodes.InvalidData, detail.Code, "code not match");
                    Assert.AreEqual("The CurrentFactsFindingFact is available only for the rules", detail.Reason, "reason not match");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] Want not contained fact")]
        public void WantNotContainedFactTestCase()
        {
            GivenCreateFactFactory()
                .When("NotContainedFact", factory => ExpectedException<FactFactoryException>(() => factory.WantFact((NotContained<Input1Fact> _) => { })))
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.IsNotNull(ex.Details, "Details cannot be null");
                    Assert.AreEqual(1, ex.Details.Count, "there must be one detail");

                    ErrorDetail detail = ex.Details[0];
                    Assert.AreEqual(ErrorCodes.InvalidData, detail.Code, "code not match");
                    Assert.AreEqual("Cannot derive for No and NotContained facts", detail.Reason, "reason not match");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] Want no fact")]
        public void WantNoFactTestCase()
        {
            GivenCreateFactFactory()
                .When("NotContainedFact", factory => ExpectedException<FactFactoryException>(() => factory.WantFact((No<Input1Fact> _) => { })))
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.IsNotNull(ex.Details, "Details cannot be null");
                    Assert.AreEqual(1, ex.Details.Count, "there must be one detail");

                    ErrorDetail detail = ex.Details[0];
                    Assert.AreEqual(ErrorCodes.InvalidData, detail.Code, "code not match");
                    Assert.AreEqual("Cannot derive for No and NotContained facts", detail.Reason, "reason not match");
                });
        }
    }
}
