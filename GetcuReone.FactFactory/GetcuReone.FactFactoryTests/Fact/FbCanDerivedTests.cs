using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.FactFactoryTests.Fact
{
    [TestClass]
    public sealed class FbCanDerivedTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.BuildCanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for BuildCanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForBuildCanDerivedFactTestCase()
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
