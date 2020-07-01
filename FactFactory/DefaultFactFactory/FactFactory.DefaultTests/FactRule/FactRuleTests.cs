using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.FactRule
{
    [TestClass]
    public sealed class FactRuleTests : CommonTestBase<FactBase>
    {
        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create FactRule without param.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateFactRuleWithoutParamTestCase()
        {
            GivenEmpty()
                .When("Create factRule", _ => new Rule((_, __) => { return default; }, null, GetFactType<OtherFact>()))
                .Then("Check input param", rule => Assert.AreEqual(0, rule.InputFactTypes.Count, "InpuTFactTypes is not empty"));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a rule with one input parameter.")]
        [Timeout(Timeouts.Millisecond.FiveHundred), TestCategory(GetcuReoneTC.Unit)]
        public void CreateFactRuleOneInputParamTestCase()
        {
            IntFact fact = null;

            Given("Create fact", () => new IntFact(0))
                .When("Create factRule", factInner => 
                {
                    fact = factInner;
                    return new Rule((_, __) => { return default; }, new List<IFactType> { fact.GetFactType() }, GetFactType<OtherFact>());
                })
                .Then("Check input param", rule => 
                {
                    Assert.AreEqual(1, rule.InputFactTypes.Count, "InpuTFactTypes is empty");
                    Assert.IsTrue(rule.InputFactTypes.First().EqualsFactType(fact.GetFactType()), "factual information does not match");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a rule with several input parameters.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateFactRuleSeveralInputParamTestCase()
        {
            IntFact fact = null;

            Given("Create fact", () => new IntFact(0))
                .When("Create factRule", factInner =>
                {
                    fact = factInner;
                    return new Rule((_, __) => { return default; }, new List<IFactType> { fact.GetFactType(), fact.GetFactType(), fact.GetFactType() }, GetFactType<OtherFact>());
                })
                .Then("Check input param", rule =>
                {
                    Assert.AreEqual(3, rule.InputFactTypes.Count, "InpuTFactTypes is not empty");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a rule with output parameter.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateFactRuleOutputParamTestCase()
        {
            IntFact fact = null;

            Given("Create fact", () => new IntFact(0))
                .When("Create factRule", factInner =>
                {
                    fact = factInner;
                    return new Rule((_, __) => { return default; }, null, fact.GetFactType());
                })
                .Then("Check output param", rule => Assert.IsTrue(rule.OutputFactType.EqualsFactType(fact.GetFactType()), "factual information does not match"));
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a rule without param.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check method calculate.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CalculateFactRuleTestCase()
        {
            DateTime operationDate = DateTime.Now;
            var container = new Container();

            Given("Add fact 1", () => container.Add(new DateTimeFact(operationDate)))
                .And("Add fact 2", _ => container.Add(new IntFact(1)))
                .And("Create rule", _ =>
                {
                    Func<IFactContainer<FactBase>, IWantAction<FactBase>, FactBase> func = (ct, __) =>
                    {
                        var date = ct.GetFact<DateTimeFact>().Value;
                        var number = ct.GetFact<IntFact>().Value;

                        return new OtherFact(date.AddDays(number));
                    };

                    return new Rule(func, container.Select(fact => fact.GetFactType()).ToList(), GetFactType<OtherFact>());
                })
                .When("Run method", rule => rule.Calculate(container, default(WAction)))
                .Then("Check result", fact =>
                {
                    Assert.IsNotNull(fact, "fac cannot be null");
                    Assert.IsTrue(fact.CalculatedByRule, "CalculatedByRule cannot be false");
                    if (fact is OtherFact otherFact)
                        Assert.AreEqual(operationDate.AddDays(1), otherFact.Value, "dates do not match");
                    else
                        Assert.Fail($"fact have type {fact.GetType().FullName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rule can be followed.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CanCalculateFactRuleTestCase()
        {
            var container = new Container();
            Given("Add fact 1", () => container.Add(new DateTimeFact(DateTime.Now)))
                .And("Add fact 2", _ => container.Add(new IntFact(1)))
                .And("Create rule", _ =>
                {
                    Func<IFactContainer<FactBase>, IWantAction<FactBase>, FactBase> func = (ct, __) => default;

                    return new Rule(func, container.Select(fact => fact.GetFactType()).ToList(), GetFactType<OtherFact>());
                })
                .When("run method", rule => rule.CanCalculate(container, default(WAction)))
                .Then("check result", result => Assert.IsTrue(result, "rule cannot be executed"));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rule cannot be executed.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CanNotCalculateFactRuleTestCase()
        {
            var container = new Container();
            var factInfos = new List<IFactType> 
            {
                GetFactType<Input10Fact>(),
                GetFactType<IntFact>(),
            };

            Given("Add fact 1", () => container.Add(new DateTimeFact(DateTime.Now)))
                .And("Add fact 2", _ => container.Add(new IntFact(1)))
                .And("Create rule", _ =>
                {
                    Func<IFactContainer<FactBase>, IWantAction<FactBase>, FactBase> func = (ct, __) => default;

                    return new Rule(func, factInfos, GetFactType<OtherFact>());
                })
                .When("run method", rule => rule.CanCalculate(container, default(WAction)))
                .Then("check result", result => Assert.IsFalse(result, "rule can be followed"));
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request entry calculated by the rule fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RequestEntryCalculatedByRuleFactTestCase()
        {
            string expectedReason = "Cannot request a fact calculated according to the rule.";

            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new Rule((_, __) => { return default; }, new List<IFactType> { GetFactType<IntFact>() }, GetFactType<IntFact>()));
                })
                .Then("Check error", ex => 
                {
                    Assert.IsNotNull(ex, "error is null");
                    Assert.AreEqual(expectedReason, ex.Message, "Another message expected");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request an invalid fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Rule_RequestInvalidFactTestCase()
        {
            string expectedReason = $"InvalidFact types are not inherited from {typeof(FactBase).FullName}.";

            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new Rule((_, __) => { return default; }, new List<IFactType> { GetFactType<IntFact>() }, GetFactType<InvalidFact>()));
                })
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error is null");
                    Assert.AreEqual(expectedReason, ex.Message, "Another message expected");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request entry is not a valid fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Rule_RequestEntryInvalidFactTestCase()
        {
            IFactType inputType = GetFactType<InvalidFact>();
            string expectedReason = $"InvalidFact types are not inherited from {typeof(FactBase).FullName}.";

            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new Rule((_, __) => { return default; }, new List<IFactType> { inputType }, GetFactType<IntFact>()));
                })
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error is null");
                    Assert.AreEqual(expectedReason, ex.Message, "Another message expected");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(TC.Objects.CannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Return NoDerive fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ReturnNoDeriveFactTestCase()
        {
            string expectedReason = $"Parameter outputFactType should not be converted into {typeof(ISpecialFact).FullName}";

            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new Rule((_, __) => { return default; }, new List<IFactType> { GetFactType<IntFact>() }, GetFactType<CannotDerived<Input10Fact>>()));
                })
                .Then("Check error", ex =>
                {
                    Assert.AreEqual(expectedReason, ex.Message, "Another message expected");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Return NotContained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ReturnNotContainedFactTestCase()
        {
            string expectedReason = $"Parameter outputFactType should not be converted into {typeof(ISpecialFact).FullName}";

            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new Rule((_, __) => { return default; }, new List<IFactType> { GetFactType<IntFact>() }, GetFactType<NotContained<Input10Fact>>()));
                })
                .Then("Check error", ex =>
                {
                    Assert.AreEqual(expectedReason, ex.Message, "Another message expected");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(TC.Objects.Contained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Return Contained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ReturnContainedFactTestCase()
        {
            string expectedReason = $"Parameter outputFactType should not be converted into {typeof(ISpecialFact).FullName}";

            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new Rule((_, __) => { return default; }, new List<IFactType> { GetFactType<IntFact>() }, GetFactType<Contained<Input10Fact>>()));
                })
                .Then("Check error", ex =>
                {
                    Assert.AreEqual(expectedReason, ex.Message, "Another message expected");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Return CanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ReturnCanDerivedFactTestCase()
        {
            string expectedReason = $"Parameter outputFactType should not be converted into {typeof(ISpecialFact).FullName}";

            GivenEmpty()
                .When("Create rule", _ =>
                {
                    return ExpectedException<ArgumentException>(
                        () => new Rule((_, __) => { return default; }, new List<IFactType> { GetFactType<IntFact>() }, GetFactType<CanDerived<Input10Fact>>()));
                })
                .Then("Check error", ex =>
                {
                    Assert.AreEqual(expectedReason, ex.Message, "Another message expected");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(TC.Objects.Contained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create rule with invalid input fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateRuleWithInvalidInputFactTypeTestCase()
        {
            IFactType invalidFactType = GetFactType<InvalidSpecialFact>();
            string expectedReason = $"{invalidFactType.FactName} implements more than one runtime special fact interface.";

            GivenEmpty()
                .When("Create wantAction", _ =>
                {
                    return ExpectedFactFactoryException(() => new Rule(
                        (_, __) => { return default; },
                        new List<IFactType> { invalidFactType },
                        GetFactType<IntFact>()));
                })
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }
    }
}
