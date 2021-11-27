using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.Fact
{
    [TestClass]
    public sealed class BuildCannotDerivedTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.BuildCannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for BuildCannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForBuildCannotDerivedFactTestCase()
        {
            GivenEmpty()
                .When("Create CannotDerived.", () => new BuildCannotDerived<ResultFact>())
                .Then("Check fact type.", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<BuildCannotDerived<ResultFact>>, "Expected another FactType.");
                })
                .Run();
        }
    }
}
