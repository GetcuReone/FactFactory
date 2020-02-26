﻿using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facts;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class FactFactoryTests : TestBase
    {
        private GetcuReone.FactFactory.FactFactory FactFactory { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            FactFactory = new GetcuReone.FactFactory.FactFactory();
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] rules cannot be empty")]
        public void RulesCannotBeEmptyTestCase()
        {
            Given("Set rules", () => FactFactory.Rules.Clear())
                .When("Derive facts", factory => ExpectedException<InvalidDeriveOperationException<FactBase, WAction>>(() => FactFactory.DeriveFact<Input10Fact>()))
                .Then("Check error", ex => 
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.IsNotNull(ex.Details, "error cannot be null");
                    Assert.AreEqual(1, ex.Details.Count, "Details must contain 1 detail");

                    var detail = ex.Details[0];
                    Assert.AreEqual(ErrorCode.EmptyRuleCollection, detail.Code, "code not match");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] rules cannot be empty")]
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

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] Derivation of only necessary facts")]
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

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] get original container")]
        public void GetOriginalContainerTestCase()
        {
            Given("Create factory", () => new Env.FactFactoryWithoutRules())
                .When("Run derive", factory => ExpectedException<InvalidDeriveOperationException<FactBase, WAction>>(() => factory.DeriveFact<OtherFact>()))
                .Then("Check error", ex => 
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.IsNotNull(ex.Details, "error cannot be null");
                    Assert.AreEqual(1, ex.Details.Count, "Details must contain 1 detail");

                    var detail = ex.Details[0];
                    Assert.AreEqual(ErrorCode.InvalidData, detail.Code, "code not match");
                    Assert.AreEqual("method GetCopyContainer return original container", detail.Reason, "reason not match");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] check method DeriveFact")]
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

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] get fact from container")]
        public void GetFactFromContainerTastCase()
        {
            var input6Fact = new Input6Fact(6);

            Given("Add fact in container", () => FactFactory.Container.Add(input6Fact))
                .When("Derive fact", () => FactFactory.DeriveFact<Input6Fact>())
                .Then("Check fact", fact => Assert.AreEqual(input6Fact, fact, "facts must match"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] derive only one fact")]
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

        //[Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] derive facts after run method DeriveFact")]
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
    }
}
