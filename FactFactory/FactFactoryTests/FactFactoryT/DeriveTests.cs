﻿using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Env;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using GivenWhenThen.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

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

        [TestMethod]
        [TestCategory(TC.Objects.Factory)]
        [Description("Checking for facts when deriving")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void FactsWhenDeducingTestCase()
        {
            StartDateOfDerive dateOfDeriveFact = null;

            GivenCreateFactFactory()
                .And("Want fact DateOfDeriveFact", factory =>
                {
                    factory.WantFact((StartDateOfDerive fact1) =>
                    {
                        dateOfDeriveFact = fact1;
                    });
                })
                .When("Derive facts", factory => factory.Derive())
                .Then("Check derive facts", _ =>
                {
                    Assert.IsNotNull(dateOfDeriveFact, "dateOfDeriveFact is not derived");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory)]
        [Description("Want a fact for which there is no rule")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void NotExistsRuleForFactTestCase()
        {
            GivenCreateFactFactory()
                .And("Set rules", factory => factory.Rules.AddRange(RuleCollectionHelper.GetInputFactRules()))
                .And("Want fact", factory => factory.WantFact((OtherFact fact) => { }))
                .When("Derive facts", factory => ExpectedException<InvalidDeriveOperationException<FactBase, WAction>>(() => factory.Derive()))
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.IsNotNull(ex.Details, "error cannot be null");
                    Assert.AreEqual(1, ex.Details.Count, "Details must contain 1 detail");

                    var detail = ex.Details[0];
                    Assert.AreEqual(ErrorCode.RuleNotFound, detail.Code, "code not match");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory)]
        [Description("Want a fact that cannot be derived")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CannotDerivedOneFactFromOne1TestCase()
        {
            GivenCreateFactFactory()
                .And("Set rules", factory => factory.Rules.AddRange(RuleCollectionHelper.GetInputFactRules()))
                .And("Want fact", factory => factory.WantFact((Input4Fact fact) => { }))
                .When("Derive facts", factory => ExpectedException<InvalidDeriveOperationException<FactBase, WAction>>(() => factory.Derive()))
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
                    Assert.IsTrue(new GetcuReone.FactFactory.Entities.FactType<Input3Fact>().Compare(notFoundFactSet[0][0]), "expected other fact");
                    Assert.IsTrue(new GetcuReone.FactFactory.Entities.FactType<Input5Fact>().Compare(notFoundFactSet[1][0]), "expected other fact");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Factory)]
        [Description("Want a fact that cannot be derived")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CannotDerivedOneFactFromOne2TestCase()
        {
            GivenCreateFactFactory()
                .And("Set rules", factory => factory.Rules.AddRange(RuleCollectionHelper.GetRulesForNotAvailableInput6Fact()))
                .And("Want fact", factory => factory.WantFact((Input6Fact fact) => { }))
                .When("Derive facts", factory => ExpectedException<InvalidDeriveOperationException<FactBase, WAction>>(() => factory.Derive()))
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.IsNotNull(ex.Details, "error cannot be null");
                    Assert.AreEqual(1, ex.Details.Count, "Details must contain 1 detail");

                    var detail = ex.Details[0];
                    Assert.AreEqual(ErrorCode.FactCannotCalculated, detail.Code, "code not match");

                    var listFact = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>()
                    };

                    Assert.IsTrue(listFact.All(fact => detail.NotFoundFacts.Values.First()[0].Any(f => f.Compare(fact))), "Other facts expected");
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

        [TestMethod]
        [TestCategory(TC.Objects.Factory)]
        [Description("Derived default facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void DerivedDefaultFactsTestCase()
        {
            StartDateOfDerive startDateOfDerive = null;
            DerivingFacts derivingFacts = null;

            GivenCreateFactFactory()
                .And("Want StartDateOfDerive", factory => factory.WantFact((StartDateOfDerive fact) => { startDateOfDerive = fact; }))
                .And("Want DerivingFacts", factory => factory.WantFact((DerivingFacts fact) => { derivingFacts = fact; }))
                .When("Derive facts", factory => factory.Derive())
                .Then("Check error", _ =>
                {
                    Assert.IsNotNull(startDateOfDerive, "StartDateOfDerive is not derived");
                    Assert.IsNotNull(derivingFacts, "DerivingFacts is not derived");
                });
        }
    }
}
