using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts;
using GivenWhenThen.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.DefaultTests.Fact
{
    [TestClass]
    public sealed class SpecialFactTests : TestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.NotContained)]
        [Description("Get FactType for NotContained fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetFactTypeForNotContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet", () => new NotContained<ResultFact>())
                .Then("Check fact type", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<NotContained<ResultFact>>, "Expected another FactType.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.Contained)]
        [Description("Get FactType for Contained fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetFactTypeForContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet", () => new Contained<ResultFact>())
                .Then("Check fact type", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<Contained<ResultFact>>, "Expected another FactType.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.NoDerived)]
        [Description("Get FactType for NoDerived fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetFactTypeForNoDerivedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet", () => new NoDerived<ResultFact>())
                .Then("Check fact type", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<NoDerived<ResultFact>>, "Expected another FactType.");
                });
        }
    }
}
