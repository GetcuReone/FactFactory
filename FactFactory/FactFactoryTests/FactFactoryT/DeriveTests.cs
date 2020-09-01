using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Env;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class DeriveTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check method Derive.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveTestCase()
        {
            Input16Fact fact16 = null;
            const int expectedValue = 16;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (Input15Fact firstFact, Input14Fact secondFact) => new Input16Fact(firstFact.Value + secondFact.Value - 3),
                    (Input2Fact secondFact) => new Input14Fact(secondFact.Value + 14),
                    (Input1Fact firstFact, Input2Fact secondFact) => new Input15Fact(firstFact.Value + secondFact.Value),
                    () => new Input1Fact(1),
                    (Input1Fact fact) => new Input2Fact(fact.Value * 2),
                })
                .And("Want fact.", factory =>
                {
                    factory.WantFacts((Input16Fact fact) =>
                    {
                        fact16 = fact;
                    });
                })
                .When("Derive facts.", factory => factory.Derive())
                .Then("Check derive facts.", _ =>
                {
                    Assert.IsNotNull(fact16, "fact16 is not derived");
                    Assert.AreEqual(expectedValue, fact16.Value, "unexpected value");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Want a fact for which there is no rule.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void NotExistsRuleForFactTestCase()
        {
            string expectedReason = $"No rules found able to calculate fact {GetFactType<OtherFact>().FactName}.";

            GivenCreateFactFactory()
                .AndAddRules(RuleCollectionHelper.GetInputFactRules())
                .And("Want fact.", factory => 
                    factory.WantFacts((OtherFact fact) => { }))
                .When("Derive facts.", factory => 
                    ExpectedDeriveException(() => factory.Derive()))
                .ThenAssertErrorDetail(ErrorCode.RuleNotFound, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Want a fact that cannot be derived.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CannotDerivedOneFactFromOne1TestCase()
        {
            IFactType wantFact = GetFactType<Input4Fact>();
            string expectedReason = $"Failed to derive one or more facts for the action ({wantFact.FactName}).";

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
                .And("Want fact.", factory => 
                    factory.WantFacts((Input4Fact fact) => { }))
                .When("Derive facts.", factory => 
                    ExpectedDeriveException(() => factory.Derive()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedReason)
                .And("Get first detail.", error => 
                    error.Details.First())
                .AndAreEqual(detail => detail.RequiredFacts.Count, setNeedFacts.Count,
                    errorMessage: "A different amount of required facts was expected.")
                .AndIsTrue(detail => detail.Container != null)
                .And("Check detail.", detail =>
                {
                    List<DeriveFactErrorDetail> factDetails = detail.RequiredFacts.ToList();

                    for (int i = 0; i < setNeedFacts.Count; i++)
                    {
                        DeriveFactErrorDetail factDetail = factDetails[i];
                        Assert.IsTrue(wantFact.EqualsFactType(factDetail.RequiredFact), "They expected another fact to be required.");

                        List<IFactType> expectedNeedFacts = setNeedFacts[i];
                        List<IFactType> needFacts = factDetail.NeedFacts.ToList();

                        for (int j = 0; i < expectedNeedFacts.Count; i++)
                            Assert.IsTrue(expectedNeedFacts[j].EqualsFactType(needFacts[j]), "Another missing fact was expected.");
                    }
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Two facts of the same type cannot be derive.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TwoFactsSameTypeCannotDeriveTestCase()
        {
            IFactType wantFact = GetFactType<Input4Fact>();
            string expectedReason = $"Failed to derive one or more facts for the action ({wantFact.FactName}).";

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
                .And("Want fact.", factory =>
                    factory.WantFacts((Input4Fact fact) => { }))
                .And("Want fact.", factory =>
                    factory.WantFacts((Input4Fact fact) => { }))
                .When("Derive facts.", factory => 
                    ExpectedDeriveException(() => factory.Derive()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedReason)
                .AndAreEqual(error => error.Details.Count, 2,
                    errorMessage: "Expceted another count details.")
                .And("Check error.", error =>
                {
                    foreach (var detail in error.Details)
                    {
                        Assert.AreEqual(setNeedFacts.Count, detail.RequiredFacts.Count, "A different amount of required facts was expected.");
                        Assert.IsNotNull(detail.Container);
                        List<DeriveFactErrorDetail> factDetails = detail.RequiredFacts.ToList();

                        for (int i = 0; i < setNeedFacts.Count; i++)
                        {
                            DeriveFactErrorDetail factDetail = factDetails[i];
                            Assert.IsTrue(wantFact.EqualsFactType(factDetail.RequiredFact), "They expected another fact to be required.");

                            List<IFactType> expectedNeedFacts = setNeedFacts[i];
                            List<IFactType> needFacts = factDetail.NeedFacts.ToList();

                            for (int j = 0; i < expectedNeedFacts.Count; i++)
                                Assert.IsTrue(expectedNeedFacts[j].EqualsFactType(needFacts[j]), "Another missing fact was expected.");
                        } 
                    }
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Two facts cannot be derive.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TwoFactsCannotDeriveTestCase()
        {
            IFactType wantFact1 = GetFactType<Input1Fact>();
            string expectedReason1 = $"Failed to derive one or more facts for the action ({wantFact1.FactName}).";

            var setNeedFacts1 = new List<List<IFactType>>
            {
                new List<IFactType>
                {
                    GetFactType<Input3Fact>(),
                },
            };

            IFactType wantFact2 = GetFactType<Input2Fact>();
            string expectedReason2 = $"Failed to derive one or more facts for the action ({wantFact2.FactName}).";

            var setNeedFacts2 = new List<List<IFactType>>
            {
                new List<IFactType>
                {
                    GetFactType<Input4Fact>(),
                },
            };

            GivenCreateFactFactory()
                .AndAddRules(new Collection 
                {
                    (Input3Fact fact) => new Input1Fact(fact.Value),
                    (Input4Fact fact) => new Input2Fact(fact.Value)
                })
                .And("Want fact1.", factory =>
                    factory.WantFacts((Input1Fact fact) => { }))
                .And("Want fact2.", factory =>
                    factory.WantFacts((Input2Fact fact) => { }))
                .When("Derive facts.", factory =>
                    ExpectedDeriveException(() => factory.Derive()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedReason1)
                .And("Check error detail 1.", error =>
                {
                    DeriveErrorDetail detail = error.Details.First();
                    Assert.AreEqual(setNeedFacts1.Count, detail.RequiredFacts.Count, "A different amount of required facts was expected.");
                    List<DeriveFactErrorDetail> factDetails = detail.RequiredFacts.ToList();

                    for (int i = 0; i < setNeedFacts1.Count; i++)
                    {
                        DeriveFactErrorDetail factDetail = factDetails[i];
                        Assert.IsTrue(wantFact1.EqualsFactType(factDetail.RequiredFact), "They expected another fact to be required.");

                        List<IFactType> expectedNeedFacts = setNeedFacts1[i];
                        List<IFactType> needFacts = factDetail.NeedFacts.ToList();

                        for (int j = 0; i < expectedNeedFacts.Count; i++)
                            Assert.IsTrue(expectedNeedFacts[j].EqualsFactType(needFacts[j]), "Another missing fact was expected.");
                    }
                })
                .AndAssertErrorDetail(ErrorCode.FactCannotDerived, expectedReason2)
                .And("Check error detail.", error =>
                {
                    DeriveErrorDetail detail = error.Details.Skip(1).First();
                    Assert.AreEqual(setNeedFacts2.Count, detail.RequiredFacts.Count, "A different amount of required facts was expected.");
                    List<DeriveFactErrorDetail> factDetails = detail.RequiredFacts.ToList();

                    for (int i = 0; i < setNeedFacts2.Count; i++)
                    {
                        DeriveFactErrorDetail factDetail = factDetails[i];
                        Assert.IsTrue(wantFact2.EqualsFactType(factDetail.RequiredFact), "They expected another fact to be required.");

                        List<IFactType> expectedNeedFacts = setNeedFacts2[i];
                        List<IFactType> needFacts = factDetail.NeedFacts.ToList();

                        for (int j = 0; i < expectedNeedFacts.Count; i++)
                            Assert.IsTrue(expectedNeedFacts[j].EqualsFactType(needFacts[j]), "Another missing fact was expected.");
                    }
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Two facts in one action cannot be derive.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TwoFactsInOneActionCannotDeriveTestCase()
        {
            List<IFactType> expectedRequiredFacts = new List<IFactType>
            {
                GetFactType<Input1Fact>(),
                GetFactType<Input2Fact>(),
            };
            string expectedReason = $"Failed to derive one or more facts for the action ({string.Join(", ", expectedRequiredFacts.ConvertAll(f => f.FactName))}).";

            var setNeedFacts = new List<List<IFactType>>
            {
                new List<IFactType>
                {
                    GetFactType<Input3Fact>(),
                },
                new List<IFactType>
                {
                    GetFactType<Input4Fact>(),
                },
            };

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (Input3Fact fact) => new Input1Fact(fact.Value),
                    (Input4Fact fact) => new Input2Fact(fact.Value)
                })
                .And("Want fact1.", factory =>
                    factory.WantFacts((Input1Fact fact1, Input2Fact fact2) => { }))
                .When("Derive facts.", factory =>
                    ExpectedDeriveException(() => factory.Derive()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedReason)
                .And("Check error detail 1.", error =>
                {
                    DeriveErrorDetail detail = error.Details.First();
                    Assert.AreEqual(expectedRequiredFacts.Count, detail.RequiredFacts.Count, "A different amount of required facts was expected.");
                    List<DeriveFactErrorDetail> factDetails = detail.RequiredFacts.ToList();

                    for (int i = 0; i < expectedRequiredFacts.Count; i++)
                    {
                        DeriveFactErrorDetail factDetail = factDetails[i];
                        Assert.IsTrue(expectedRequiredFacts[i].EqualsFactType(factDetail.RequiredFact), "They expected another fact to be required.");

                        List<IFactType> expectedNeedFacts = setNeedFacts[i];
                        List<IFactType> needFacts = factDetail.NeedFacts.ToList();

                        for (int j = 0; i < expectedNeedFacts.Count; i++)
                            Assert.IsTrue(expectedNeedFacts[j].EqualsFactType(needFacts[j]), "Another missing fact was expected.");
                    }
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Want a fact that cannot be derived.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CannotDerivedOneFactFromOne2TestCase()
        {
            IFactType wantFact = GetFactType<Input6Fact>();
            string expectedReason = $"Failed to derive one or more facts for the action ({wantFact.FactName}).";
            var expectedNeedFacts = new List<IFactType>
            {
                GetFactType<Input3Fact>(),
                GetFactType<Input5Fact>(),
            };

            GivenCreateFactFactory()
                .AndAddRules(RuleCollectionHelper.GetRulesForNotAvailableInput6Fact())
                .And("Want fact.", factory =>
                    factory.WantFacts((Input6Fact fact) => { }))
                .When("Derive facts.", factory =>
                    ExpectedDeriveException(() => factory.Derive()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedReason)
                .And("Check error", error =>
                {
                    DeriveErrorDetail detail = error.Details.First();
                    Assert.AreEqual(1, detail.RequiredFacts.Count, "A different amount of required facts was expected.");

                    DeriveFactErrorDetail factDetail = detail.RequiredFacts.First();
                    Assert.IsTrue(wantFact.EqualsFactType(factDetail.RequiredFact), "They expected another fact to be required.");

                    Assert.AreEqual(expectedNeedFacts.Count, factDetail.NeedFacts.Count, "Another number of missing facts expected.");
                    List<IFactType> needFacts = factDetail.NeedFacts.ToList();

                    for (int i = 0; i < expectedNeedFacts.Count; i++)
                        Assert.IsTrue(expectedNeedFacts[i].EqualsFactType(needFacts[i]), "Another missing fact was expected.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derived three facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DerivedThreeFactsTestCase()
        {
            Input6Fact input6Fact = null;
            Input16Fact input16Fact = null;
            Input7Fact input7Fact = null;
            var container = new Container
            {
                new Input3Fact(3),
            };

            GivenCreateFactFactory()
                .AndAddRules(RuleCollectionHelper.GetInputFactRules())
                .And("Want fact6.", factory =>
                    factory.WantFacts((Input6Fact fact) => { input6Fact = fact; }, container))
                .And("Want fact16.", factory =>
                    factory.WantFacts((Input16Fact fact) => { input16Fact = fact; }, container))
                .And("Want fact16.", factory =>
                    factory.WantFacts((Input7Fact fact) => { input7Fact = fact; }, container))
                .When("Derive facts.", factory =>
                    factory.Derive())
                .Then("Check error.", _ =>
                {
                    Assert.IsNotNull(input6Fact, "input6Fact is not derived");
                    Assert.IsNotNull(input16Fact, "input16Fact is not derived");
                    Assert.IsNotNull(input7Fact, "input7Fact is not derived");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Choosing the path with the least number of rules.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ChoosingPathWithLeastNumberRulesTestCase()
        {
            const int expectedValue = 2;

            GivenCreateFactFactory()
                 .AndAddRules(new Collection
                 {
                     (Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5) => new ResultFact(fact2.Value),

                     () => new Input2Fact(1),
                     () => new Input3Fact(1),
                     () => new Input4Fact(1),
                     () => new Input5Fact(1),
                 })
                 .AndAddRules(new Collection
                 {
                     (Input10Fact fact) => new ResultFact(fact.Value),
                     (Input11Fact fact) => new Input10Fact(fact.Value),
                     (Input12Fact fact) => new Input11Fact(fact.Value),
                     () => new Input12Fact(2),
                 })
                 .When("Derive.", factFactory =>
                    factFactory.DeriveFact<ResultFact>())
                 .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive fact use rule with condition fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFactUseRuleWithConditionTestCase()
        {
            const int expectedValue = 10;
            var container = new Container
            {
                new OtherFact(default)
            };

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(default),
                    (Input1Fact fact) => new ResultFact(1_000),
                    (Condition_ContainedOtherFact condition) => new ResultFact(expectedValue),
                })
                .When("Derive fact.", factFactory =>
                    factFactory.DeriveFact<ResultFact>(container))
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive fact use rule without condition fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFactUseRuleWithoutConditionTestCase()
        {
            const int expectedValue = 1_000;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new OtherFact(default),
                    (OtherFact fact) => new ResultFact(expectedValue),
                    (Condition_ContainedOtherFact condition) => new ResultFact(10),
                })
                .When("Derive fact.", factFactory =>
                    factFactory.DeriveFact<ResultFact>())
                .ThenFactEquals(expectedValue);
        }
    }
}
