using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.Fact
{
    [TestClass]
    public sealed class CannotDerivedTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.CannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for CannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForCannotDerivedFactTestCase()
        {
            GivenEmpty()
                .When("Create CannotDerived.", () => new CannotDerived<ResultFact>())
                .Then("Check fact type.", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<CannotDerived<ResultFact>>, "Expected another FactType.");
                })
                .Run();
        }
    }
}
