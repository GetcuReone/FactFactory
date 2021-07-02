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
using System.Linq;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

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
                .ThenAssertErrorDetail(ErrorCode.EmptyRuleCollection, expectedReason)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Choosing the shortest way.")]
        //[Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ChoosingShortestWayTestCase()
        {
            const int expectedValue = 5;
            var container = new Container
            {
                new Input16Fact(0),
            };

            GivenCreateFactFactory()
                .AndRulesNotNul()
                .AndAddRules(new Collection
                {
                    // main rule.
                    (Input2Fact f) => new Input1Fact(f + 1),
                })
                .AndAddRules(new Collection
                {
                    // 1 way.
                    (Input3Fact f) => new Input2Fact(f + 1),
                    (Input4Fact f) => new Input3Fact(f + 1),
                    (Input5Fact f) => new Input4Fact(f + 1),
                    (Input6Fact f) => new Input5Fact(f + 1),
                    (Input7Fact f) => new Input6Fact(f + 1),
                    (Input16Fact f) => new Input7Fact(f + 1),
                })
                .AndAddRules(new Collection
                {
                    // 2 way.
                    (Input8Fact f) => new Input2Fact(f + 1),
                    (Input9Fact f) => new Input8Fact(f + 1),
                    (Input10Fact f) => new Input9Fact(f + 1),
                    (Input16Fact f) => new Input10Fact(f + 1),
                })
                .AndAddRules(new Collection
                {
                    // 3 way.
                    (Input11Fact f) => new Input2Fact(f + 1),
                    (Input12Fact f) => new Input11Fact(f + 1),
                    (Input13Fact f) => new Input12Fact(f + 1),
                    (Input14Fact f) => new Input13Fact(f + 1),
                    (Input16Fact f) => new Input14Fact(f + 1),
                })
                .When("Derive facts.", factFactory =>
                    factFactory.DeriveFact<Input1Fact>(container))
                .ThenFactValueEquals(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derivation of only necessary facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DerivationOnlyNecessaryFactsTestCase()
        {
            int counter = 0;
            const int expectedValue = 5;
            var container = new Container
            {
                new Input16Fact(0),
                new Input15Fact(0),
            };

            GivenCreateFactFactory()
                .AndRulesNotNul()
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
                    factFactory.DeriveFact<Input1Fact>(container))
                .Then("Check result.", _ => 
                    Assert.AreEqual(expectedValue, counter, "It had to work out 5 rules"))
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check method DeriveFact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DeriveFactTestCase()
        {
            const int expectedValue = 10;
            var container = new Container
            {
                new Input10Fact(expectedValue),
            };

            GivenCreateFactFactory()
                .When("Run DeriveFact.", factFactory =>
                    factFactory.DeriveFact<Input10Fact>(container))
                .ThenFactValueEquals(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get fact from container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactFromContainerTastCase()
        {
            var input6Fact = new Input6Fact(6);
            var container = new Container
            {
                input6Fact,
            };

            GivenCreateFactFactory()
                .When("Derive fact.", factFactory =>
                    factFactory.DeriveFact<Input6Fact>(container))
                .ThenAreEqual(input6Fact)
                .Run();
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
                })
                .Run();
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
            var container = new Container();

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input6Fact(6),
                    () => new Input16Fact(16),
                    () => new Input7Fact(7),
                })
                .And("Want facts.", factFactory =>
                {
                    factFactory.WantFacts((Input6Fact fact) => fact6 = fact, container);
                    factFactory.WantFacts((Input16Fact fact) => fact16 = fact, container);
                    factFactory.WantFacts((Input7Fact fact) => fact7 = fact, container);
                    factory = factFactory;
                })
                .And("Derive fact.", factFactory => 
                    factFactory.DeriveFact<Input7Fact>(container))
                .When("Derive facts", fact =>
                {
                    factory.Derive();
                })
                .Then("Check Input7Fact.", fact => Assert.AreEqual(fact, fact7))
                .And("Check result.", _ =>
                {
                    Assert.IsNotNull(fact7, "fact7 must derived");
                    Assert.IsNotNull(fact16, "fact16 must derived");
                    Assert.IsNotNull(fact6, "fact6 must derived");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.BuildNotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Successful derive BuildNotContained.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SuccessfulDeriveBuildNotContainedTestCase()
        {
            GivenCreateFactFactory()
                .When("Run Derive.", factFactory =>
                    factFactory.DeriveFact<BuildNotContained<OtherFact>>())
                .ThenIsNotNull()
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.BuildNotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Unsuccessful derive BuildNotContained.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UnsuccessfulDeriveBuildNotContainedTestCase()
        {
            string expectedMessage = $"Failed to derive one or more facts for the action ({typeof(BuildNotContained<OtherFact>).Name}).";
            var container = new Container
            {
                new OtherFact(default),
            };

            GivenCreateFactFactory()
                .When("Run Derive.", factFactory => 
                    ExpectedDeriveException(() => factFactory.DeriveFact<BuildNotContained<OtherFact>>(container)))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.BuildCannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Successful derive BuildCannotDerived.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SuccessfulDeriveBuildCannotDerivedTestCase()
        {
            GivenCreateFactFactory()
                .When("Run Derive.", factFactory =>
                    factFactory.DeriveFact<BuildCannotDerived<OtherFact>>())
                .ThenIsNotNull()
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.BuildCannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Unsuccessful derive BuildCannotDerived.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void UnsuccessfulDeriveBuildCannotDerivedTestCase()
        {
            string expectedMessage = $"Failed to derive one or more facts for the action ({typeof(BuildCannotDerived<OtherFact>).Name}).";
            var container = new Container
            {
                new OtherFact(default),
            };

            GivenCreateFactFactory()
                .When("Run Derive.", factFactory => 
                    ExpectedDeriveException(() => factFactory.DeriveFact<BuildCannotDerived<OtherFact>>(container)))
                .ThenAssertErrorDetail(ErrorCode.FactCannotDerived, expectedMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add default fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddDefaultFactTestCase()
        {
            DefaultFact defaultFact = new DefaultFact(10);
            FactFactoryCustom factFactoryCustom = null;
            var container = new Container();

            Given("Create factory.", () => factFactoryCustom = new FactFactoryCustom())
                .And("Add default fact.", factFactory => factFactory.DefaultFacts.Add(defaultFact))
                .When("Run Derive.", factFactory => 
                    factFactory.DeriveFact<DefaultFact>(container))
                .ThenIsNotNull()
                .AndAreEqual(defaultFact)
                .And("Check Container.", _ => 
                {
                    Assert.AreEqual(1, container.Count(), "Container must be empty");
                })
                .Run();
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
                .And("Want facts.", factFactory => 
                    factFactory.WantFacts((DefaultFact fact) => { }))
                .When("Run Derive.", factFactory => 
                    ExpectedDeriveException(factFactory.Derive))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason)
                .Run();
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
                .AndAreEqual(factory => factory.W_FactsInfos.Count, 1)
                .When("Derive.", factFactory =>
                    factFactory.Derive())
                .ThenAreEqual(factory => factory.W_FactsInfos.Count, 0)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Container contains SpecialFact in runtime.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ContainerContainsConditionFactTestCase()
        {
            string expectedMessage = $"Container contains {nameof(IBuildConditionFact)} facts.";
            var container = new Container
            {
                new BuildCanDerived<ResultFact>(),
            };

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    (Input10Fact fact) => new ResultFact(fact.Value),
                })
                .And("Want facts.", factFactory => factFactory.WantFacts((ResultFact _) => { }, container))
                .When("Call Derive.", factFactory =>
                    ExpectedDeriveException(factFactory.Derive))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedMessage)
                .Run();
        }
    }
}
