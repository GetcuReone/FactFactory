using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.DefaultTests.Fact
{
    [TestClass]
    public sealed class SpecialFactTests : CommonTestBase<FactBase>
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for NotContained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.Contained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for Contained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create Contained", () => new Contained<ResultFact>())
                .Then("Check fact type", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<Contained<ResultFact>>, "Expected another FactType.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.CannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for CannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForCannotDerivedFactTestCase()
        {
            GivenEmpty()
                .When("Create CannotDerived", () => new CannotDerived<ResultFact>())
                .Then("Check fact type", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<CannotDerived<ResultFact>>, "Expected another FactType.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for CanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactTypeForCanDerivedFactTestCase()
        {
            GivenEmpty()
                .When("Create CanDerived", () => new CanDerived<ResultFact>())
                .Then("Check fact type", fact =>
                {
                    Assert.IsTrue(fact.GetFactType() is FactType<CanDerived<ResultFact>>, "Expected another FactType.");
                });
        }
    }
}
