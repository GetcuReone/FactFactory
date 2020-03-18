using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Env;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.SpecialFacts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class FactFactoryTests : FactFactoryTestBase
    {
        private GetcuReone.FactFactory.FactFactory FactFactory { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            FactFactory = new GetcuReone.FactFactory.FactFactory();
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory)]
        [Description("Rules cannot be empty.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void RulesCannotBeEmptyTestCase()
        {
            Given("Set rules", () => FactFactory.Rules.Clear())
                .When("Derive facts", factory => ExpectedDeriveException(() => FactFactory.DeriveFact<Input10Fact>()))
                .ThenAssertErrorDetail(ErrorCode.EmptyRuleCollection, "Rules cannot be null.");
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory)]
        [Description("Choosing the shortest way.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void ChoosingShortestWayTestCase()
        {
            Given("Check empty rules", () => Assert.IsNotNull(FactFactory.Rules, "rules cannot be null"))
                .And("Add fact", () => FactFactory.Container.Add(new Input16Fact(0)))
                .And("Add main rule", () => FactFactory.Rules.Add((Input2Fact f) => new Input1Fact(f.Value + 1)))
                .And("Add 1 way", () =>
                {
                    FactFactory.Rules.Add((Input3Fact f) => new Input2Fact(f.Value + 1));
                    FactFactory.Rules.Add((Input4Fact f) => new Input3Fact(f.Value + 1));
                    FactFactory.Rules.Add((Input5Fact f) => new Input4Fact(f.Value + 1));
                    FactFactory.Rules.Add((Input6Fact f) => new Input5Fact(f.Value + 1));
                    FactFactory.Rules.Add((Input7Fact f) => new Input6Fact(f.Value + 1));
                    FactFactory.Rules.Add((Input16Fact f) => new Input7Fact(f.Value + 1));
                })
                .And("Add 2 way", () =>
                {
                    FactFactory.Rules.Add((Input8Fact f) => new Input2Fact(f.Value + 1));
                    FactFactory.Rules.Add((Input9Fact f) => new Input8Fact(f.Value + 1));
                    FactFactory.Rules.Add((Input10Fact f) => new Input9Fact(f.Value + 1));
                    FactFactory.Rules.Add((Input16Fact f) => new Input10Fact(f.Value + 1));
                })
                .And("Add 3 way", () =>
                {
                    FactFactory.Rules.Add((Input11Fact f) => new Input2Fact(f.Value + 1));
                    FactFactory.Rules.Add((Input12Fact f) => new Input11Fact(f.Value + 1));
                    FactFactory.Rules.Add((Input13Fact f) => new Input12Fact(f.Value + 1));
                    FactFactory.Rules.Add((Input14Fact f) => new Input13Fact(f.Value + 1));
                    FactFactory.Rules.Add((Input16Fact f) => new Input14Fact(f.Value + 1));
                })
                .When("Derive facts", FactFactory.DeriveFact<Input1Fact>)
                .Then("Check result", f => Assert.AreEqual(5, f.Value, "Another number of rules worked"));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory)]
        [Description("Derivation of only necessary facts.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DerivationOnlyNecessaryFactsTestCase()
        {
            int counter = 0;

            Given("Check empty rules", () => Assert.IsNotNull(FactFactory.Rules, "rules cannot be null"))
                .And("Add fact Input16Fact", () => FactFactory.Container.Add(new Input16Fact(0)))
                .And("Add fact Input15Fact", () => FactFactory.Container.Add(new Input15Fact(0)))
                .And("Add main rule", () => FactFactory.Rules.Add((Input2Fact f) => 
                {
                    counter++;
                    return new Input1Fact(f.Value + 1);
                }))
                .And("Add way", () =>
                {
                    FactFactory.Rules.Add((Input8Fact f) => 
                    {
                        counter++;
                        return new Input2Fact(f.Value + 1);
                    });
                    FactFactory.Rules.Add((Input9Fact f) => 
                    {
                        counter++;
                        return new Input8Fact(f.Value + 1);
                    });
                    FactFactory.Rules.Add((Input10Fact f) => 
                    {
                        counter++;
                        return new Input9Fact(f.Value + 1);
                    });
                    FactFactory.Rules.Add((Input16Fact f) => 
                    {
                        counter++;
                        return new Input10Fact(f.Value + 1);
                    });
                })
                .And("Add another rule to output the penultimate fact", () =>
                {
                    FactFactory.Rules.Add((Input8Fact f) =>
                    {
                        counter++;
                        return new Input10Fact(f.Value + 1);
                    });
                })
                .When("Derive facts", FactFactory.DeriveFact<Input1Fact>)
                .Then("Check result", f => Assert.AreEqual(5, counter, "It had to work out 5 rules"));
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory)]
        [Description("Get original container.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetOriginalContainerTestCase()
        {
            Given("Create factory", () => new FactFactoryCustom())
                .And("Change container", factFactory =>
                {
                    factFactory.container = new FactContainerGetOriginal();
                })
                .When("Run derive", factory => ExpectedDeriveException(() => factory.DeriveFact<OtherFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, "IFactContainer.Copy method return original container.");
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory)]
        [Description("Check method DeriveFact.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DeriveFactTestCase()
        {
            Given("Add rule", () => FactFactory.Rules.Add(() => new Input10Fact(10)))
                .When("Run DeriveFact", _ => FactFactory.DeriveFact<Input10Fact>())
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact, "fact cannot be null");
                    Assert.AreEqual(10, fact.Value, "fact have other value");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory)]
        [Description("Get fact from container.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetFactFromContainerTastCase()
        {
            var input6Fact = new Input6Fact(6);

            Given("Add fact in container", () => FactFactory.Container.Add(input6Fact))
                .When("Derive fact", () => FactFactory.DeriveFact<Input6Fact>())
                .Then("Check fact", fact => Assert.AreEqual(input6Fact, fact, "facts must match"));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory)]
        [Description("Derive only one fact.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DeriveOnlyOneFactTestCase()
        {
            Input6Fact fact6 = null;
            Input16Fact fact16 = null;
            Input7Fact fact7 = null;

            Given("Add rules", () =>
            {
                FactFactory.Rules.Add(() => new Input6Fact(6));
                FactFactory.Rules.Add(() => new Input16Fact(16));
                FactFactory.Rules.Add(() => new Input7Fact(7));
            })
                .And("Want facts", () =>
                {
                    FactFactory.WantFact((Input6Fact fact) => fact6 = fact);
                    FactFactory.WantFact((Input16Fact fact) => fact16 = fact);
                    FactFactory.WantFact((Input7Fact fact) => fact7 = fact);
                })
                .When("Derive fact", () => FactFactory.DeriveFact<Input7Fact>())
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact, "fact not derived");

                    Assert.IsNull(fact7, "fact7 cannot derived");
                    Assert.IsNull(fact16, "fact16 cannot derived");
                    Assert.IsNull(fact6, "fact6 cannot derived");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory)]
        [Description("Derive facts after run method DeriveFact.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DeriveFactsAfterRunDeriveFactTestCase()
        {
            Input6Fact fact6 = null;
            Input16Fact fact16 = null;
            Input7Fact fact7 = null;

            Given("Add rules", () =>
            {
                FactFactory.Rules.Add(() => new Input6Fact(6));
                FactFactory.Rules.Add(() => new Input16Fact(16));
                FactFactory.Rules.Add(() => new Input7Fact(7));
            })
                .And("Want facts", () =>
                {
                    FactFactory.WantFact((Input6Fact fact) => fact6 = fact);
                    FactFactory.WantFact((Input16Fact fact) => fact16 = fact);
                    FactFactory.WantFact((Input7Fact fact) => fact7 = fact);
                })
                .And("Derive fact", () => FactFactory.DeriveFact<Input7Fact>())
                .When("Derive facts", fact =>
                {
                    FactFactory.Derive();
                    return fact;
                })
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact7, "fact7 must derived");
                    Assert.IsNotNull(fact16, "fact16 must derived");
                    Assert.IsNotNull(fact6, "fact6 must derived");

                    Assert.AreNotEqual(fact, fact7, "fact and fact7 must be different");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.NoDerived)]
        [Description("Add a special fact to the container.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddSpecialFactContainer()
        {
            string expectedMessage = $"In the container there should be no facts realizing types {nameof(INotContainedFact)} and {nameof(INoDerivedFact)}";

            Given("Create factory", () => new FactFactoryCustom())
                .AndAddFact(new NoDerived<OtherFact>())
                .When("Run derive", factory => ExpectedDeriveException(() => factory.DeriveFact<OtherFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedMessage);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.NotContained)]
        [Description("Successful derive NotContained.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void SuccessfulDeriveNotContainedTestCase()
        {
            Given("Create factory", () => new FactFactoryCustom())
                .When("Run Derive", factFactory => factFactory.DeriveFact<NotContained<OtherFact>>())
                .Then("Check fact", fact => Assert.IsNotNull(fact, "fact cannot be null"));
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.NotContained)]
        [Description("Unsuccessful derive NotContained.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void UnsuccessfulDeriveNotContainedTestCase()
        {
            string expectedMessage = $"Failed to calculate one or more facts for the action ({typeof(NotContained<OtherFact>).Name}).";

            Given("Create factory", () => new FactFactoryCustom())
                .AndAddFact(new OtherFact(default))
                .When("Run Derive", factFactory => ExpectedDeriveException(() => factFactory.DeriveFact<NotContained<OtherFact>>()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotCalculated, expectedMessage);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.NoDerived)]
        [Description("Successful derive NotContained.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void SuccessfulDeriveNoDerivedTestCase()
        {
            Given("Create factory", () => new FactFactoryCustom())
                .When("Run Derive", factFactory => factFactory.DeriveFact<NoDerived<OtherFact>>())
                .Then("Check fact", fact => Assert.IsNotNull(fact, "fact cannot be null"));
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.NoDerived)]
        [Description("Unsuccessful derive NoDerived.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void UnsuccessfulDeriveNoDerivedTestCase()
        {
            string expectedMessage = $"Failed to calculate one or more facts for the action ({typeof(NoDerived<OtherFact>).Name}).";

            Given("Create factory", () => new FactFactoryCustom())
                .AndAddFact(new OtherFact(default))
                .When("Run Derive", factFactory => ExpectedDeriveException(() => factFactory.DeriveFact<NoDerived<OtherFact>>()))
                .ThenAssertErrorDetail(ErrorCode.FactCannotCalculated, expectedMessage);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.NoDerived)]
        [Description("Add default fact.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddDefaultFactTestCase()
        {
            DefaultFact defaultFact = new DefaultFact(10);
            FactFactoryCustom factFactoryCustom = null;

            Given("Create factory", () => factFactoryCustom = new FactFactoryCustom())
                .And("Add default fact", factFactory => factFactory.DefaultFacts.Add(defaultFact))
                .When("Run Derive", factFactory => factFactory.DeriveFact<DefaultFact>())
                .Then("Check fact", fact => 
                {
                    Assert.AreEqual(defaultFact, fact, "Expected anothe fact.");
                    Assert.AreEqual(0, factFactoryCustom.Container.Count(), "Container must be empty");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory), TestCategory(TC.Objects.NoDerived)]
        [Description("Add 2 default facts with the same types.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddTwoDefaultFactsWithSameTypesTestCase()
        {
            string expectedReason = $"GetDefaultFacts method return more than two {GetFactType<DefaultFact>().FactName} facts";
            Given("Create factory", () => new FactFactoryCustom())
                .And("Add default fact", factFactory => factFactory.DefaultFacts.Add(new DefaultFact(10)))
                .And("Add default fact", factFactory => factFactory.DefaultFacts.Add(new DefaultFact(10)))
                .When("Run Derive", factFactory => ExpectedDeriveException(() => factFactory.DeriveFact<DefaultFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }
    }
}
