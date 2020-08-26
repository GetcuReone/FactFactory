using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.Fact
{
    [TestClass]
    public sealed class NotContainedTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for CannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForNotContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContained.", () => new NotContained<ResultFact>())
                .Then("Check fact type.", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<NotContained<ResultFact>>, "Expected another FactType.");
                });
        }
    }
}
