using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Env;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class DeriveTests : FactFactoryTestBase
    {
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] check method Derive")]
        public void DeriveTestCase()
        {
            Input16Fact fact16 = null;

            GivenCreateFactFactory()
                .And("Set rules", factory => factory.Rules.AddRange(RuleCollectionHelper.GetInputFactRules()))
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

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] Checking for facts when deriving")]
        public void FactsWhenDeducingTestCase()
        {
            StartDateOfDerive dateOfDeriveFact = null;
            DerivingCurrentFactsFact derivingCurrentFactsFact = null;

            GivenCreateFactFactory()
                .And("Want fact DateOfDeriveFact", factory =>
                {
                    factory.WantFact((StartDateOfDerive fact1, DerivingCurrentFactsFact fact2) =>
                    {
                        dateOfDeriveFact = fact1;
                        derivingCurrentFactsFact = fact2;
                    });
                })
                .When("Derive facts", factory => factory.Derive())
                .Then("Check derive facts", _ =>
                {
                    Assert.IsNotNull(dateOfDeriveFact, "dateOfDeriveFact is not derived");
                    Assert.IsNotNull(derivingCurrentFactsFact, "DerivingCurrentFactsFact is not derived");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] Want a fact for which there is no rule")]
        public void NotExistsRuleForFactTestCase()
        {
            GivenCreateFactFactory()
                .And("Set rules", factory => factory.Rules.AddRange(RuleCollectionHelper.GetInputFactRules()))
                .And("Want fact", factory => factory.WantFact((OtherFact fact) => { }))
                .When("Derive facts", factory => ExpectedException<InvalidDeriveOperationException>(() => factory.Derive()))
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.IsNotNull(ex.Details, "error cannot be null");
                    Assert.AreEqual(1, ex.Details.Count, "Details must contain 1 detail");

                    var detail = ex.Details[0];
                    Assert.AreEqual(ErrorCode.RuleNotFound, detail.Code, "code not match");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] Want a fact that cannot be derived")]
        public void CannotDerivedOneFactFromOne1TestCase()
        {
            GivenCreateFactFactory()
                .And("Set rules", factory => factory.Rules.AddRange(RuleCollectionHelper.GetInputFactRules()))
                .And("Want fact", factory => factory.WantFact((Input4Fact fact) => { }))
                .When("Derive facts", factory => ExpectedException<InvalidDeriveOperationException>(() => factory.Derive()))
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.IsNotNull(ex.Details, "error cannot be null");
                    Assert.AreEqual(1, ex.Details.Count, "Details must contain 1 detail");

                    var detail = ex.Details[0];
                    Assert.AreEqual(ErrorCode.FactCannotCalculated, detail.Code, "code not match");
                    Assert.AreEqual(1, detail.NotFoundFacts.Values.Count, "Sets expected for one fact");

                    var notFoundFactSet = detail.NotFoundFacts.Values.First();

                    Assert.AreEqual(2, notFoundFactSet.Count, "2 sets of facts expected");
                    Assert.IsTrue(new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>().Compare(notFoundFactSet[0][0]), "expected other fact");
                    Assert.IsTrue(new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>().Compare(notFoundFactSet[1][0]), "expected other fact");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory][negative] Want a fact that cannot be derived")]
        public void CannotDerivedOneFactFromOne2TestCase()
        {
            GivenCreateFactFactory()
                .And("Set rules", factory => factory.Rules.AddRange(RuleCollectionHelper.GetRulesForNotAvailableInput6Fact()))
                .And("Want fact", factory => factory.WantFact((Input6Fact fact) => { }))
                .When("Derive facts", factory => ExpectedException<InvalidDeriveOperationException>(() => factory.Derive()))
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.IsNotNull(ex.Details, "error cannot be null");
                    Assert.AreEqual(1, ex.Details.Count, "Details must contain 1 detail");

                    var detail = ex.Details[0];
                    Assert.AreEqual(ErrorCode.FactCannotCalculated, detail.Code, "code not match");

                    var listFact = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>()
                    };

                    Assert.IsTrue(listFact.All(fact => detail.NotFoundFacts.Values.First()[0].Any(f => f.Compare(fact))), "Other facts expected");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][factory] Derived tow facts")]
        public void DerivedTwoFactsTestCase()
        {
            Input6Fact input6Fact = null;
            Input16Fact input16Fact = null;
            Input7Fact input7Fact = null;

            GivenCreateFactFactory()
                .And("Set rules", factory => factory.Rules.AddRange(RuleCollectionHelper.GetInputFactRules()))
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
    }
}
