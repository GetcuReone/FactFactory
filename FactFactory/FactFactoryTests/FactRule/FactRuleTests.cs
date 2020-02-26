﻿using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

namespace FactFactoryTests.FactRule
{
    [TestClass]
    public sealed class FactRuleTests : TestBase
    {
        private IFactType GetFactType<TFact>()
            where TFact : IFact
        {
            return new FactType<TFact>();
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] create FactRule without param")]
        public void CreateFactRuleWithoutParamTestCase()
        {
            GivenEmpty()
                .When("Create factRule", _ => new Rule(ct => { return default; }, null, GetFactType<OtherFact>()))
                .Then("Check input param", rule => Assert.AreEqual(0, rule.InputFactTypes.Count, "InpuTFactTypes is not empty"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] create a rule with one input parameter")]
        public void CreateFactRuleOneInputParamTestCase()
        {
            IntFact fact = null;

            Given("Create fact", () => new IntFact(0))
                .When("Create factRule", factInner => 
                {
                    fact = factInner;
                    return new Rule(ct => { return default; }, new List<IFactType> { fact.GetFactType() }, GetFactType<OtherFact>());
                })
                .Then("Check input param", rule => 
                {
                    Assert.AreEqual(1, rule.InputFactTypes.Count, "InpuTFactTypes is empty");
                    Assert.IsTrue(rule.InputFactTypes.First().Compare(fact.GetFactType()), "factual information does not match");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] create a rule with several input parameters")]
        public void CreateFactRuleSeveralInputParamTestCase()
        {
            IntFact fact = null;

            Given("Create fact", () => new IntFact(0))
                .When("Create factRule", factInner =>
                {
                    fact = factInner;
                    return new Rule(ct => { return default; }, new List<IFactType> { fact.GetFactType(), fact.GetFactType(), fact.GetFactType() }, GetFactType<OtherFact>());
                })
                .Then("Check input param", rule =>
                {
                    Assert.AreEqual(3, rule.InputFactTypes.Count, "InpuTFactTypes is not empty");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] create a rule with output parameter")]
        public void CreateFactRuleOutputParamTestCase()
        {
            IntFact fact = null;

            Given("Create fact", () => new IntFact(0))
                .When("Create factRule", factInner =>
                {
                    fact = factInner;
                    return new Rule(ct => { return default; }, null, fact.GetFactType());
                })
                .Then("Check output param", rule => Assert.IsTrue(rule.OutputFactType.Compare(fact.GetFactType()), "factual information does not match"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][negative] create a rule without param")]
        public void CreateFactRuleWithoutFuncTestCase()
        {
            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentNullException>(() => new Rule(null, null, null));
                })
                .Then("Check error", ex => 
                {
                    Assert.IsNotNull(ex, "error is null");
                    Assert.AreEqual("func", ex.ParamName, "Another parameter name expected");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] check method calculate")]
        public void CalculateFactRuleTestCase()
        {
            DateTime operationDate = DateTime.Now;
            var container = new Container();

            Given("Add fact 1", () => container.Add(new StartDateOfDerive(operationDate)))
                .And("Add fact 2", _ => container.Add(new IntFact(1)))
                .And("Create rule", _ =>
                {
                    Func<IFactContainer<FactBase>, FactBase> func = ct =>
                    {
                        var date = ct.GetFact<StartDateOfDerive>().Value;
                        var number = ct.GetFact<IntFact>().Value;

                        return new OtherFact(date.AddDays(number));
                    };

                    return new Rule(func, container.Select(fact => fact.GetFactType()).ToList(), new GetcuReone.FactFactory.Entities.FactType<OtherFact>());
                })
                .When("Run method", rule => rule.Calculate(container))
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact, "fac cannot be null");
                    if (fact is OtherFact otherFact)
                        Assert.AreEqual(operationDate.AddDays(1), otherFact.Value, "dates do not match");
                    else
                        Assert.Fail($"fact have type {fact.GetType().FullName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] rule can be followed")]
        public void CanCalculateFactRuleTestCase()
        {
            var container = new Container();
            Given("Add fact 1", () => container.Add(new StartDateOfDerive(DateTime.Now)))
                .And("Add fact 2", _ => container.Add(new IntFact(1)))
                .And("Create rule", _ =>
                {
                    Func<IFactContainer<FactBase>, FactBase> func = ct => default;

                    return new Rule(func, container.Select(fact => fact.GetFactType()).ToList(), new GetcuReone.FactFactory.Entities.FactType<OtherFact>());
                })
                .When("run method", rule => rule.CanCalculate(container))
                .Then("check result", result => Assert.IsTrue(result, "rule cannot be executed"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] rule cannot be executed")]
        public void CanNotCalculateFactRuleTestCase()
        {
            var container = new Container();
            var factInfos = new List<IFactType> 
            {
                new FactType<DateTimeFact>(),
                new FactType<IntFact>(),
            };

            Given("Add fact 1", () => container.Add(new StartDateOfDerive(DateTime.Now)))
                .And("Add fact 2", _ => container.Add(new IntFact(1)))
                .And("Create rule", _ =>
                {
                    Func<IFactContainer<FactBase>, FactBase> func = ct => default;

                    return new Rule(func, factInfos, new FactType<OtherFact>());
                })
                .When("run method", rule => rule.CanCalculate(container))
                .Then("check result", result => Assert.IsFalse(result, "rule can be followed"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][negative] request entry calculated by the rule fact")]
        public void RequestEntryCalculatedByRuleFactTestCase()
        {
            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new Rule(ct => { return default; }, new List<IFactType> { GetFactType<IntFact>() }, GetFactType<IntFact>()));
                })
                .Then("Check error", ex => 
                {
                    Assert.IsNotNull(ex, "error is null");
                    Assert.AreEqual("Cannot request a fact calculated according to the rule", ex.Message, "Another message expected");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][negative] request an invalid fact")]
        public void Rule_RequestInvalidFactTestCase()
        {
            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new Rule(ct => { return default; }, new List<IFactType> { GetFactType<IntFact>() }, GetFactType<InvalidFact>()));
                })
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error is null");
                    Assert.AreEqual("InvalidFact types are not inherited from GetcuReone.FactFactory.Facts.FactBase", ex.Message, "Another message expected");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][negative] request entry is not a valid fact")]
        public void Rule_RequestEntryInvalidFactTestCase()
        {
            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new Rule(ct => { return default; }, new List<IFactType> { GetFactType<InvalidFact>() }, GetFactType<IntFact>()));
                })
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error is null");
                    Assert.AreEqual("InvalidFact types are not inherited from GetcuReone.FactFactory.Facts.FactBase", ex.Message, "Another message expected");
                });
        }
    }
}
