using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.FactFactoryTests.Fact
{
    [TestClass]
    public sealed class FbContainedTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.BuildContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for BuildContained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForBuildContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create CanDerived.", () => new FbCanDerived<ResultFact>())
                .Then("Check fact type.", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<FbCanDerived<ResultFact>>, "Expected another FactType.");
                })
                .Run();
        }
    }
}
