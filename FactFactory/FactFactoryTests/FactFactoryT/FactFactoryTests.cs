using System.Linq;
using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Env;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class FactFactoryTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rules cannot be empty.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RulesCannotBeEmptyTestCase()
        {
            const string expectedReason = "Rules cannot be null.";

            GivenCreateFactFactory()
                .When("Derive facts.", factory => 
                    ExpectedDeriveException(() => factory.DeriveFact<Input10Fact>()))
                .ThenAssertErrorDetail(ErrorCode.EmptyRuleCollection, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Choosing the shortest way.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ChoosingShortestWayTestCase()
        {
            const int expectedValue = 5;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddFact(new Input16Fact(0))
                .AndAddRules(new Collection
                {
                    // main rule.
                    (Input2Fact f) => new Input1Fact(f.Value + 1),
                })
                .AndAddRules(new Collection
                {
                    // 1 way.
                    (Input3Fact f) => new Input2Fact(f.Value + 1),
                    (Input4Fact f) => new Input3Fact(f.Value + 1),
                    (Input5Fact f) => new Input4Fact(f.Value + 1),
                    (Input6Fact f) => new Input5Fact(f.Value + 1),
                    (Input7Fact f) => new Input6Fact(f.Value + 1),
                    (Input16Fact f) => new Input7Fact(f.Value + 1),
                })
                .AndAddRules(new Collection
                {
                    // 2 way.
                    (Input8Fact f) => new Input2Fact(f.Value + 1),
                    (Input9Fact f) => new Input8Fact(f.Value + 1),
                    (Input10Fact f) => new Input9Fact(f.Value + 1),
                    (Input16Fact f) => new Input10Fact(f.Value + 1),
                })
                .AndAddRules(new Collection
                {
                    // 2 way.
                    (Input11Fact f) => new Input2Fact(f.Value + 1),
                    (Input12Fact f) => new Input11Fact(f.Value + 1),
                    (Input13Fact f) => new Input12Fact(f.Value + 1),
                    (Input14Fact f) => new Input13Fact(f.Value + 1),
                    (Input16Fact f) => new Input14Fact(f.Value + 1),
                })
                .When("Derive facts.", factFactory =>
                    factFactory.DeriveFact<Input1Fact>())
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derivation of only necessary facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DerivationOnlyNecessaryFactsTestCase()
        {
            int counter = 0;
            const int expectedValue = 5;

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddFact(new Input16Fact(0))
                .AndAddFact(new Input15Fact(0))
                .AndAddRules(new Collection
                {
                    // main rule.
                    (Input2Fact f) =>
                    {
                        counter++;
                        return new Input1Fact(f.Value + 1);
                    }
                })
                .AndAddRules(new Collection
                {
                    // way.
                    (Input8Fact f) =>
                    {
                        counter++;
                        return new Input2Fact(f.Value + 1);
                    },
                    (Input9Fact f) =>
                    {
                        counter++;
                        return new Input8Fact(f.Value + 1);
                    },
                    (Input10Fact f) =>
                    {
                        counter++;
                        return new Input9Fact(f.Value + 1);
                    },
                    (Input16Fact f) =>
                    {
                        counter++;
                        return new Input10Fact(f.Value + 1);
                    },
                })
                .AndAddRules(new Collection
                {
                    // another rule to output the penultimate fact.
                    (Input8Fact f) =>
                    {
                        counter++;
                        return new Input10Fact(f.Value + 1);
                    }
                })
                .When("Derive facts.", factFactory => 
                    factFactory.DeriveFact<Input1Fact>())
                .Then("Check result.", _ => 
                    Assert.AreEqual(expectedValue, counter, "It had to work out 5 rules"));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check method DeriveFact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFactTestCase()
        {
            const int expectedValue = 10;

            GivenCreateFactFactory()
                .AndAddFact(new Input10Fact(10))
                .When("Run DeriveFact.", factFactory =>
                    factFactory.DeriveFact<Input10Fact>())
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get fact from container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactFromContainerTastCase()
        {
            var input6Fact = new Input6Fact(6);

            GivenCreateFactFactory()
                .AndAddFact(input6Fact)
                .When("Derive fact.", factFactory => 
                    factFactory.DeriveFact<Input6Fact>())
                .Then("Check fact.", fact => 
                    Assert.AreEqual(input6Fact, fact, "facts must match."));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive only one fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveOnlyOneFactTestCase()
        {
            Input6Fact fact6 = null;
            Input16Fact fact16 = null;
            Input7Fact fact7 = null;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input6Fact(6),
                    () => new Input16Fact(16),
                    () => new Input7Fact(7),
                })
                .And("Want facts.", factFactory =>
                {
                    factFactory.WantFacts((Input6Fact fact) => fact6 = fact);
                    factFactory.WantFacts((Input16Fact fact) => fact16 = fact);
                    factFactory.WantFacts((Input7Fact fact) => fact7 = fact);
                })
                .When("Derive fact.", factFactory => 
                    factFactory.DeriveFact<Input7Fact>())
                .ThenIsNotNull()
                .And("Check result.", _ =>
                {
                    Assert.IsNull(fact7, "fact7 cannot derived");
                    Assert.IsNull(fact16, "fact16 cannot derived");
                    Assert.IsNull(fact6, "fact6 cannot derived");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive facts after run method DeriveFact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFactsAfterRunDeriveFactTestCase()
        {
            Input6Fact fact6 = null;
            Input16Fact fact16 = null;
            Input7Fact fact7 = null;
            GetcuReone.FactFactory.FactFactory factory = null;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input6Fact(6),
                    () => new Input16Fact(16),
                    () => new Input7Fact(7),
                })
                .And("Want facts.", factFactory =>
                {
                    factFactory.WantFacts((Input6Fact fact) => fact6 = fact);
                    factFactory.WantFacts((Input16Fact fact) => fact16 = fact);
                    factFactory.WantFacts((Input7Fact fact) => fact7 = fact);
                    factory = factFactory;
                })
                .And("Derive fact.", factFactory => 
                    factFactory.DeriveFact<Input7Fact>())
                .When("Derive facts", fact =>
                {
                    factory.Derive();
                    return fact;
                })
                .ThenAreEqual(fact7)
                .And("Check result.", _ =>
                {
                    Assert.IsNotNull(fact7, "fact7 must derived");
                    Assert.IsNotNull(fact16, "fact16 must derived");
                    Assert.IsNotNull(fact6, "fact6 must derived");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Successful derive NotContained.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SuccessfulDeriveNotContainedTestCase()
        {
            GivenCreateFactFactory()
                .When("Run Derive.", factFactory =>
                    factFactory.DeriveFact<NotContained<OtherFact>>())
                .ThenIsNotNull();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Unsuccessful derive NotContained.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UnsuccessfulDeriveNotContainedTestCase()
        {
            string expectedMessage = $"Failed to derive one or more facts for the action ({typeof(NotContained<OtherFact>).Name}).";

            GivenCreateFactFactory()
                .AndAddFact(new OtherFact(default))
                .When("Run Derive.", factFactory => 
                    ExpectedDeriveException(() => factFactory.DeriveFact<NotContained<OtherFact>>()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedMessage);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.CannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Successful derive CannotDerived.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SuccessfulDeriveCannotDerivedTestCase()
        {
            GivenCreateFactFactory()
                .When("Run Derive.", factFactory =>
                    factFactory.DeriveFact<CannotDerived<OtherFact>>())
                .ThenIsNotNull();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.CannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Unsuccessful derive CannotDerived.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UnsuccessfulDeriveCannotDerivedTestCase()
        {
            string expectedMessage = $"Failed to derive one or more facts for the action ({typeof(CannotDerived<OtherFact>).Name}).";

            GivenCreateFactFactory()
                .AndAddFact(new OtherFact(default))
                .When("Run Derive.", factFactory => 
                    ExpectedDeriveException(() => factFactory.DeriveFact<CannotDerived<OtherFact>>()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedMessage);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add default fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddDefaultFactTestCase()
        {
            DefaultFact defaultFact = new DefaultFact(10);
            FactFactoryCustom factFactoryCustom = null;

            Given("Create factory.", () => factFactoryCustom = new FactFactoryCustom())
                .And("Add default fact.", factFactory => factFactory.DefaultFacts.Add(defaultFact))
                .When("Run Derive.", factFactory => 
                    factFactory.DeriveFact<DefaultFact>())
                .ThenIsNotNull()
                .AndAreEqual(defaultFact)
                .And("Check Container.", _ => 
                {
                    Assert.AreEqual(1, factFactoryCustom.Container.Count(), "Container must be empty");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add 2 default facts with the same types.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddTwoDefaultFactsWithSameTypesTestCase()
        {
            string expectedReason = $"The fact container already contains {GetFactType<DefaultFact>().FactName} type of fact.";

            Given("Create factory.", () => new FactFactoryCustom())
                .And("Add default fact.", factFactory => 
                    factFactory.DefaultFacts.Add(new DefaultFact(10)))
                .And("Add default fact.", factFactory => 
                    factFactory.DefaultFacts.Add(new DefaultFact(10)))
                .When("Run Derive.", factFactory => ExpectedFactFactoryException(() => factFactory.DeriveFact<DefaultFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive with empty rules.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveWithEmptyRulesTestCase()
        {
            const string expectedReason = "Rules cannot be null.";

            Given("Create factory.", () => new FactFactoryCustom())
                .And("Empty container.", factFactory =>
                {
                    factFactory.collection = null;
                })
                .When("Run Derive.", factFactory => 
                    ExpectedDeriveException(factFactory.Derive))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Clear WantActions after derive.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ClearWantActionsAfterDeriveTestCase()
        {
            Given("Create factory.", () => new FactFactoryCustom())
                .AndAddRules(new Collection
                {
                    (Input10Fact fact) => new ResultFact(fact.Value),
                    (Input11Fact fact) => new Input10Fact(fact.Value),
                    (Input12Fact fact) => new Input11Fact(fact.Value),
                    () => new Input12Fact(2),
                })
                .And("Want fact.", factFactory => 
                    factFactory.WantFacts((ResultFact result) => { }))
                .And("Check WantActions.", 
                    factFactory => Assert.AreEqual(1, factFactory.W_Actions.Count))
                .When("Derive.", factFactory => 
                    factFactory.Derive())
                .Then("Check result.", factFactory =>
                {
                    Assert.AreEqual(0, factFactory.W_Actions.Count);
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Container contains RuntimeSpecialFact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ContainerContainsConditionFactTestCase()
        {
            string expectedMessage = $"Container contains {nameof(IConditionFact)} facts.";

            GivenCreateFactFactory()
                .AndAddFact(new CanDerived<ResultFact>())
                .AndAddRules(new Collection
                {
                    (Input10Fact fact) => new ResultFact(fact.Value),
                })
                .When("Call Derive.", factFactory =>
                    ExpectedDeriveException(factFactory.Derive))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedMessage);
        }
    }
}
