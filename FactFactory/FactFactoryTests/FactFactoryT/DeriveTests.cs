using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Env;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using GivenWhenThen.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class DeriveTests : FactFactoryTestBase
    {

        [TestMethod]
        [TestCategory(TC.Objects.Factory)]
        [Description("Check method Derive")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DeriveTestCase()
        {
            Input16Fact fact16 = null;

            GivenCreateFactFactory()
                .AndAddRules(RuleCollectionHelper.GetInputFactRules())
                .And("Want fact", factory =>
                {
                    factory.WantFact((Input16Fact fact) =>
                    {
                        fact16 = fact;
                    });
                })
                .When("Derive facts", factory => factory.Derive())
                .Then("Check derive facts", _ =>
                {
                    Assert.IsNotNull(fact16, "fact16 is not derived");
                    Assert.AreEqual(16, fact16.Value, "unexpected value");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory)]
        [Description("Want a fact for which there is no rule")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void NotExistsRuleForFactTestCase()
        {
            string expectedReason = $"No rules found able to calculate fact {GetFactType<OtherFact>().FactName}.";

            GivenCreateFactFactory()
                .AndAddRules(RuleCollectionHelper.GetInputFactRules())
                .And("Want fact", factory => factory.WantFact((OtherFact fact) => { }))
                .When("Derive facts", factory => ExpectedDeriveException(() => factory.Derive()))
                .ThenAssertErrorDetail(ErrorCode.RuleNotFound, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory)]
        [Description("Want a fact that cannot be derived")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CannotDerivedOneFactFromOne1TestCase()
        {
            IFactType wantFact = GetFactType<Input4Fact>();
            string expectedReason = $"Failed to calculate one or more facts for the action ({wantFact.FactName}).";

            var setNeedFacts = new List<List<IFactType>>
            {
                new List<IFactType>
                {
                    GetFactType<Input3Fact>(),
                },
                new List<IFactType>
                {
                    GetFactType<Input5Fact>(),
                },
            };

            GivenCreateFactFactory()
                .AndAddRules(RuleCollectionHelper.GetInputFactRules())
                .And("Want fact", factory => factory.WantFact((Input4Fact fact) => { }))
                .When("Derive facts", factory => ExpectedDeriveException(() => factory.Derive()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotCalculated, expectedReason)
                .And("Check error", error =>
                {
                    DeriveErrorDetail<FactBase> detail = error.Details.First();
                    Assert.AreEqual(setNeedFacts.Count, detail.RequiredFacts.Count, "A different amount of required facts was expected.");
                    List<DeriveFactErrorDetail> factDetails = detail.RequiredFacts.ToList();

                    for (int i = 0; i < setNeedFacts.Count; i++)
                    {
                        DeriveFactErrorDetail factDetail = factDetails[i];
                        Assert.IsTrue(wantFact.Compare(factDetail.RequiredFact), "They expected another fact to be required.");

                        List<IFactType> expectedNeedFacts = setNeedFacts[i];
                        List<IFactType> needFacts = factDetail.NeedFacts.ToList();

                        for (int j = 0; i < expectedNeedFacts.Count; i++)
                            Assert.IsTrue(expectedNeedFacts[j].Compare(needFacts[j]), "Another missing fact was expected.");
                    }
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory)]
        [Description("Want a fact that cannot be derived")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CannotDerivedOneFactFromOne2TestCase()
        {
            IFactType wantFact = GetFactType<Input6Fact>();
            string expectedReason = $"Failed to calculate one or more facts for the action ({wantFact.FactName}).";
            var expectedNeedFacts = new List<IFactType>
            {
                GetFactType<Input3Fact>(),
                GetFactType<Input5Fact>(),
            };

            GivenCreateFactFactory()
                .AndAddRules(RuleCollectionHelper.GetRulesForNotAvailableInput6Fact())
                .And("Want fact", factory => factory.WantFact((Input6Fact fact) => { }))
                .When("Derive facts", factory => ExpectedDeriveException(() => factory.Derive()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotCalculated, expectedReason)
                .And("Check error", error =>
                {
                    DeriveErrorDetail<FactBase> detail = error.Details.First();
                    Assert.AreEqual(1, detail.RequiredFacts.Count, "A different amount of required facts was expected.");

                    DeriveFactErrorDetail factDetail = detail.RequiredFacts.First();
                    Assert.IsTrue(wantFact.Compare(factDetail.RequiredFact), "They expected another fact to be required.");

                    Assert.AreEqual(expectedNeedFacts.Count, factDetail.NeedFacts.Count, "Another number of missing facts expected.");
                    List<IFactType> needFacts = factDetail.NeedFacts.ToList();

                    for (int i = 0; i < expectedNeedFacts.Count; i++)
                        Assert.IsTrue(expectedNeedFacts[i].Compare(needFacts[i]), "Another missing fact was expected.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory)]
        [Description("Derived tow facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DerivedTwoFactsTestCase()
        {
            Input6Fact input6Fact = null;
            Input16Fact input16Fact = null;
            Input7Fact input7Fact = null;

            GivenCreateFactFactory()
                .AndAddRules(RuleCollectionHelper.GetInputFactRules())
                .And("Want fact6", factory => factory.WantFact((Input6Fact fact) => { input6Fact = fact; }))
                .And("Want fact16", factory => factory.WantFact((Input16Fact fact) => { input16Fact = fact; }))
                .And("Want fact16", factory => factory.WantFact((Input7Fact fact) => { input7Fact = fact; }))
                .And("Add fact3", factory => factory.Container.Add(new Input3Fact(3)))
                .When("Derive facts", factory => factory.Derive())
                .Then("Check error", _ =>
                {
                    Assert.IsNotNull(input6Fact, "input6Fact is not derived");
                    Assert.IsNotNull(input16Fact, "input16Fact is not derived");
                    Assert.IsNotNull(input7Fact, "input7Fact is not derived");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory)]
        [Description("Get the original rules for the Derive")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetOriginalsRulesForDerive()
        {
            Given("Create custom factory", () => new FactFactoryCustom())
                .And("Change rules", factFactory => 
                {
                    factFactory.collection = new FactRuleCollectionGetOriginal();
                })
                .When("Derive fact", factFactory => ExpectedDeriveException(() => factFactory.Derive()))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, "FactRuleCollectionBase.Copy method return original rule collection.");
        }
    }
}
