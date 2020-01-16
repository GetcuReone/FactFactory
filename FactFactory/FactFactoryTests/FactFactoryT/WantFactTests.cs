using FactFactory.Consts;
using FactFactory.Exceptions;
using FactFactory.Facts;
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

                    var detail = ex.Details[0];
                    Assert.AreEqual(ErrorCodes.InvalidData, detail.Code, "code not match");
                    Assert.AreEqual("The CurrentFactsFindingFact is available only for the rules", detail.Reason, "reason not match");
                });
        }
    }
}
