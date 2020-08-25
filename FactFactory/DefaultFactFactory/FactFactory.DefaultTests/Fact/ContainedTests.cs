using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.DefaultTests.Fact
{
    [TestClass]
    public sealed class ContainedTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.Contained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for Contained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create CanDerived.", () => new CanDerived<ResultFact>())
                .Then("Check fact type.", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<CanDerived<ResultFact>>, "Expected another FactType.");
                });
        }
    }
}
