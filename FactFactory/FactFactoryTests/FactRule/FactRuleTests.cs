﻿using FactFactory.Interfaces;
using FactFactoryTests.CommonFacts;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Rule = FactFactory.Entities.FactRule;
using Container = FactFactory.Entities.FactContainer;
using FactFactory.Facts;

namespace FactFactoryTests.FactRule
{
    [TestClass]
    public sealed class FactRuleTests : TestBase
    {
        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] create FactRule without param")]
        public void CreateFactRuleWithoutParamTestCase()
        {
            GivenEmpty()
                .When("Create factRule", _ => new Rule(ct => { return default; }, null, null))
                .Then("Check input param", rule => Assert.AreEqual(0, rule.InputFactInfos.Count, "InputFactInfos is not empty"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] create a rule with one input parameter")]
        public void CreateFactRuleOneInputParamTestCase()
        {
            IntFact fact = null;

            Given("Create fact", () => new IntFact(0))
                .When("Create factRule", factInner => 
                {
                    fact = factInner;
                    return new Rule(ct => { return default; }, new List<IFactInfo> { fact.GetFactInfo() }, null);
                })
                .Then("Check input param", rule => 
                {
                    Assert.AreEqual(1, rule.InputFactInfos.Count, "InputFactInfos is empty");
                    Assert.IsTrue(rule.InputFactInfos.First().Compare(fact.GetFactInfo()), "factual information does not match");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] create a rule with several input parameters")]
        public void CreateFactRuleSeveralInputParamTestCase()
        {
            IntFact fact = null;

            Given("Create fact", () => new IntFact(0))
                .When("Create factRule", factInner =>
                {
                    fact = factInner;
                    return new Rule(ct => { return default; }, new List<IFactInfo> { fact.GetFactInfo(), fact.GetFactInfo(), fact.GetFactInfo() }, null);
                })
                .Then("Check input param", rule =>
                {
                    Assert.AreEqual(3, rule.InputFactInfos.Count, "InputFactInfos is not empty");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] create a rule with output parameter")]
        public void CreateFactRuleOutputParamTestCase()
        {
            IntFact fact = null;

            Given("Create fact", () => new IntFact(0))
                .When("Create factRule", factInner =>
                {
                    fact = factInner;
                    return new Rule(ct => { return default; }, null, fact.GetFactInfo());
                })
                .Then("Check output param", rule => Assert.IsTrue(rule.OutputFactInfo.Compare(fact.GetFactInfo()), "factual information does not match"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][negative] create a rule without param")]
        public void CreateFactRuleWithoutFuncTestCase()
        {
            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentNullException>(() => new Rule(null, null, null));
                })
                .Then("Check error", ex => Assert.IsNotNull(ex, "error is null"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] check method derive")]
        public void DeriveFactRuleTestCase()
        {
            DateTime operationDate = DateTime.Now;
            var container = new Container();

            Given("Add fact 1", () => container.Add(new DateOfDeriveFact(operationDate)))
                .And("Add fact 2", _ => container.Add(new IntFact(1)))
                .And("Create rule", _ =>
                {
                    Func<IFactContainer, IFact> func = ct =>
                    {
                        var date = ct.GetFact<DateOfDeriveFact>().Value;
                        var number = ct.GetFact<IntFact>().Value;

                        return new OtherFact(date.AddDays(number));
                    };

                    return new Rule(func, container.Select(fact => fact.GetFactInfo()).ToList(), new FactFactory.Entities.FactInfo<OtherFact>());
                })
                .When("Run method", rule => rule.Derive(container))
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact, "fac cannot be null");
                    if (fact is OtherFact otherFact)
                        Assert.AreEqual(operationDate.AddDays(1), otherFact.Value, "dates do not match");
                    else
                        Assert.Fail($"fact have type {fact.GetType().FullName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] rule can be followed")]
        public void CanDeriveFactRuleTestCase()
        {
            var container = new Container();
            Given("Add fact 1", () => container.Add(new DateOfDeriveFact(DateTime.Now)))
                .And("Add fact 2", _ => container.Add(new IntFact(1)))
                .And("Create rule", _ =>
                {
                    Func<IFactContainer, IFact> func = ct => default;

                    return new Rule(func, container.Select(fact => fact.GetFactInfo()).ToList(), new FactFactory.Entities.FactInfo<OtherFact>());
                })
                .When("run method", rule => rule.CanDerive(container))
                .Then("check result", result => Assert.IsTrue(result, "rule cannot be executed"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] rule cannot be executed")]
        public void CanNotDeriveFactRuleTestCase()
        {
            var container = new Container();
            var factInfos = new List<IFactInfo> 
            {
                new FactFactory.Entities.FactInfo<DateTimeFact>(),
                new FactFactory.Entities.FactInfo<IntFact>(),
            };

            Given("Add fact 1", () => container.Add(new DateOfDeriveFact(DateTime.Now)))
                .And("Add fact 2", _ => container.Add(new IntFact(1)))
                .And("Create rule", _ =>
                {
                    Func<IFactContainer, IFact> func = ct => default;

                    return new Rule(func, factInfos, new FactFactory.Entities.FactInfo<OtherFact>());
                })
                .When("run method", rule => rule.CanDerive(container))
                .Then("check result", result => Assert.IsFalse(result, "rule can be followed"));
        }
    }
}