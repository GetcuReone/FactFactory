using FactFactory.Exceptions;
using FactFactory.Facts;
using FactFactoryTests.CommonFacts;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class FactFactoryTests : TestBase
    {
        private FactFactory.FactFactory FactFactory { get; set; }

        [TestInitialize]
        public void Initialaze()
        {
            FactFactory = new FactFactory.FactFactory();
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] check method Derive")]
        public void DeriveFactFactoryTestCase()
        {
            Input16Fact fact16 = null;

            Given("Set rules", () => FactFactory.Rules.AddRange(RuleCollectionHelper.GetInputFactRules()))
                .And("Ask for a fact", _ =>
                {
                    FactFactory.WantFact((Input16Fact fact) =>
                    {
                        fact16 = fact;
                    });
                })
                .When("Derive facts", _ => FactFactory.Derive())
                .Then("Check derive facts", _ =>
                {
                    Assert.IsNotNull(fact16, "fact16 is not derived");
                    Assert.AreEqual(16, fact16.Value, "unexpected value");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] check method DeriveAndResult")]
        public void DeriveAndResultFactFactoryTestCase()
        {
            Given("Set rules", () => FactFactory.Rules.AddRange(RuleCollectionHelper.GetInputFactRules()))
                .When("Derive and return facts", _ => FactFactory.DeriveAndReturn<Input16Fact>())
                .Then("Check derive facts", fact =>
                {
                    Assert.IsNotNull(fact, "fact16 is not derived");
                    Assert.AreEqual(16, fact.Value, "unexpected value");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] Checking for facts when deriving")]
        public void FactsWhenDeducingTestCase()
        {
            DateOfDeriveFact dateOfDeriveFact = null;
            DerivingCurrentFactsFact derivingCurrentFactsFact = null;

            Given("Want fact DateOfDeriveFact", () => 
            {
                FactFactory.WantFact((DateOfDeriveFact fact1, DerivingCurrentFactsFact fact2) => 
                {
                    dateOfDeriveFact = fact1;
                    derivingCurrentFactsFact = fact2;
                });
            })
                .When("Derive facts", _ => FactFactory.Derive())
                .Then("Check derive facts", _ =>
                {
                    Assert.IsNotNull(dateOfDeriveFact, "dateOfDeriveFact is not derived");
                    Assert.IsNotNull(derivingCurrentFactsFact, "DerivingCurrentFactsFact is not derived");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] Want not available fact")]
        public void WantNotAvailableFactTestCase()
        {
            GivenEmpty()
                .When("Want fact", _ => ExpectedException<ArgumentException>(() => FactFactory.WantFact((CurrentFactsFindingFact fact) => { })))
                .Then("Check error", ex => Assert.IsNotNull(ex, "error cannot be null"));

        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] Want a fact for which there is no rule")]
        public void NotExistsRuleForFactTestCase()
        {
            Given("Set rules", () => FactFactory.Rules.AddRange(RuleCollectionHelper.GetInputFactRules()))
                .And("Want fact", _ => FactFactory.WantFact((OtherFact fact) => { }))
                .When("Derive facts", _ => ExpectedException<InvalidOperationException>(() => FactFactory.Derive()))
                .Then("Check error", ex => Assert.IsNotNull(ex, "error cannot be null"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] Want a fact that cannot be derived")]
        public void CannotDerivedOneFactFromOne1TestCase()
        {
            Given("Set rules", () => FactFactory.Rules.AddRange(RuleCollectionHelper.GetInputFactRules()))
                .And("Want fact", _ => FactFactory.WantFact((Input4Fact fact) => { }))
                .When("Derive facts", _ => ExpectedException<InvalidDeriveOperationException>(() => FactFactory.Derive()))
                .Then("Check error", ex => 
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.IsNotNull(ex.NotFoundRuleForFactsSet, "NotFoundRuleForFactsSet cannot be null");
                    Assert.AreEqual(2, ex.NotFoundRuleForFactsSet.Count, "there must be two set of sets of necessary facts");

                    Assert.IsNotNull(ex.NotFoundRuleForFactsSet[0], "item from NotFoundRuleForFactsSet cannot be null");
                    Assert.IsNotNull(ex.NotFoundRuleForFactsSet[1], "item from NotFoundRuleForFactsSet cannot be null");

                    Assert.AreEqual(1, ex.NotFoundRuleForFactsSet[0].Count, "there must be one set of necessary facts");
                    Assert.AreEqual(1, ex.NotFoundRuleForFactsSet[1].Count, "there must be one set of necessary facts");

                    Assert.IsTrue(ex.NotFoundRuleForFactsSet[0][0].Compare(new FactFactory.Entities.FactInfo<Input5Fact>()), "type fact must be Input5Fact");
                    Assert.IsTrue(ex.NotFoundRuleForFactsSet[1][0].Compare(new FactFactory.Entities.FactInfo<Input3Fact>()), "type fact must be Input3Fact");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] Want a fact that cannot be derived")]
        public void CannotDerivedOneFactFromOne2TestCase()
        {
            Given("Set rules", () => FactFactory.Rules.AddRange(RuleCollectionHelper.GetRulesForNotAvailableInput6Fact()))
                .And("Want fact", _ => FactFactory.WantFact((Input6Fact fact) => { }))
                .When("Derive facts", _ => ExpectedException<InvalidDeriveOperationException>(() => FactFactory.Derive()))
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.IsNotNull(ex.NotFoundRuleForFactsSet, "NotFoundRuleForFactsSet cannot be null");
                    Assert.AreEqual(1, ex.NotFoundRuleForFactsSet.Count, "there must be two set of sets of necessary facts");

                    Assert.IsNotNull(ex.NotFoundRuleForFactsSet[0], "item from NotFoundRuleForFactsSet cannot be null");
                    Assert.AreEqual(2, ex.NotFoundRuleForFactsSet[0].Count, "there must be one set of necessary facts");

                    Assert.IsTrue(ex.NotFoundRuleForFactsSet[0][0].Compare(new FactFactory.Entities.FactInfo<Input3Fact>()), "type fact must be Input3Fact");
                    Assert.IsTrue(ex.NotFoundRuleForFactsSet[0][1].Compare(new FactFactory.Entities.FactInfo<Input5Fact>()), "type fact must be Input5Fact");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] Derived tow facts")]
        public void DerivedTwoFactsTestCase()
        {
            Input6Fact input6Fact = null;
            Input16Fact input16Fact = null;
            Input7Fact input7Fact = null;

            Given("Set rules", () => FactFactory.Rules.AddRange(RuleCollectionHelper.GetInputFactRules()))
                .And("Want fact6", _ => FactFactory.WantFact((Input6Fact fact) => { input6Fact = fact; }))
                .And("Want fact16", _ => FactFactory.WantFact((Input16Fact fact) => { input16Fact = fact; }))
                .And("Want fact16", _ => FactFactory.WantFact((Input7Fact fact) => { input7Fact = fact; }))
                .And("Add fact3", _ => FactFactory.Container.Add(new Input3Fact(3)))
                .When("Derive facts", FactFactory.Derive)
                .Then("Check error", _ =>
                {
                    Assert.IsNotNull(input6Fact, "input6Fact is not derived");
                    Assert.IsNotNull(input16Fact, "input16Fact is not derived");
                    Assert.IsNotNull(input7Fact, "input7Fact is not derived");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] rules cannot be empty")]
        public void RulesCannotBeEmptyTestCase()
        {
            Given("Set rules", () => new Env.FactFactoryWithoutRules())
                .When("Derive facts", factory => ExpectedException<InvalidOperationException>(() => factory.DeriveAndReturn<Input10Fact>()))
                .Then("Check error", ex => Assert.IsNotNull(ex, "error cannot be null"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
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
                .When("Derive facts", FactFactory.DeriveAndReturn<Input1Fact>)
                .Then("Check result", f => Assert.AreEqual(5, f.Value, "Another number of rules worked"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] Derivation of only necessary facts")]
        public void DerivationOnlyNecessaryFacts()
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
                .When("Derive facts", FactFactory.DeriveAndReturn<Input1Fact>)
                .Then("Check result", f => Assert.AreEqual(5, counter, "It had to work out 5 rules"));
        }
    }
}
