using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

namespace FactFactoryTests.FactRule
{
    [TestClass]
    public sealed class FactRuleTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create FactRule without param.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateFactRuleWithoutParamTestCase()
        {
            GivenEmpty()
                .When("Create factRule.", _ => 
                    new Rule(facts => { return new OtherFact(default); }, null, GetFactType<OtherFact>(), FactWorkOption.CanExecuteSync))
                .Then("Check input param.", rule => 
                    Assert.AreEqual(0, rule.InputFactTypes.Count, "InpuTFactTypes is not empty."))
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a rule with one input parameter.")]
        [Timeout(Timeouts.Millisecond.FiveHundred), TestCategory(GetcuReoneTC.Unit)]
        public void CreateFactRuleOneInputParamTestCase()
        {
            IntFact fact = null;

            Given("Create fact", () => new IntFact(0))
                .When("Create factRule.", factInner => 
                {
                    fact = factInner;
                    return new Rule(
                        facts => { return new OtherFact(default); },
                        new List<IFactType> { fact.GetFactType() },
                        GetFactType<OtherFact>(),
                        FactWorkOption.CanExecuteSync);
                })
                .Then("Check input param.", rule => 
                {
                    Assert.AreEqual(1, rule.InputFactTypes.Count, "InpuTFactTypes is empty");
                    Assert.IsTrue(rule.InputFactTypes.First().EqualsFactType(fact.GetFactType()), "factual information does not match");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a rule with several input parameters.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateFactRuleSeveralInputParamTestCase()
        {
            IntFact fact = null;

            Given("Create fact.", () => new IntFact(0))
                .When("Create factRule.", factInner =>
                {
                    fact = factInner;
                    return new Rule(
                        facts => { return new OtherFact(default); },
                        new List<IFactType> { fact.GetFactType(), fact.GetFactType(), fact.GetFactType() },
                        GetFactType<OtherFact>(),
                        FactWorkOption.CanExecuteSync);
                })
                .Then("Check input param.", rule =>
                {
                    Assert.AreEqual(3, rule.InputFactTypes.Count, "InpuTFactTypes is not empty.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a rule with output parameter.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateFactRuleOutputParamTestCase()
        {
            IntFact fact = null;

            Given("Create fact.", () => new IntFact(0))
                .When("Create factRule.", factInner =>
                {
                    fact = factInner;
                    return new Rule(
                        facts => { return fact; },
                        null,
                        fact.GetFactType(),
                        FactWorkOption.CanExecuteSync);
                })
                .ThenIsTrue(rule => rule.OutputFactType.EqualsFactType(fact.GetFactType()),
                    errorMessage: "factual information does not match.")
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a rule without param.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateFactRuleWithoutFuncTestCase()
        {
            const string paramName = "func";

            GivenEmpty()
                .When("Create rule,", _ =>
                    ExpectedException<ArgumentNullException>(() => new Rule(default(Func<IEnumerable<IFact>, IFact>), null, null, FactWorkOption.CanExecuteSync)))
                .ThenIsNotNull()
                .AndAreEqual(ex => ex.ParamName, paramName,
                    errorMessage: "Another parameter name expected.")
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a async rule without param.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateAsyncFactRuleWithoutFuncTestCase()
        {
            const string paramName = "funcAsync";

            GivenEmpty()
                .When("Create rule,", _ =>
                    ExpectedException<ArgumentNullException>(() => new Rule(default(Func<IEnumerable<IFact>, ValueTask<IFact>>), null, null, FactWorkOption.CanExecuteSync)))
                .ThenIsNotNull()
                .AndAreEqual(ex => ex.ParamName, paramName,
                    errorMessage: "Another parameter name expected.")
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check method calculate.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CalculateFactRuleTestCase()
        {
            DateTime operationDate = DateTime.Now;
            var container = new Container();

            Given("Add fact 1.", () => container.Add(new DateTimeFact(operationDate)))
                .And("Add fact 2.", _ => 
                    container.Add(new IntFact(1)))
                .And("Create rule.", _ =>
                {
                    Func<IEnumerable<IFact>, FactBase> func = facts =>
                    {
                        var date = facts.GetFact<DateTimeFact>().Value;
                        var number = facts.GetFact<IntFact>().Value;

                        return new OtherFact(date.AddDays(number));
                    };

                    return new Rule(
                        func,
                        container.Select(fact => fact.GetFactType()).ToList(),
                        GetFactType<OtherFact>(),
                        FactWorkOption.CanExecuteSync);
                })
                .When("Run method.", rule => 
                    rule.Calculate(container))
                .ThenIsNotNull()
                .And("Check result.", fact =>
                {
                    if (fact is OtherFact otherFact)
                        Assert.AreEqual(operationDate.AddDays(1), otherFact.Value, "Dates do not match.");
                    else
                        Assert.Fail($"fact have type {fact.GetType().FullName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request entry calculated by the rule fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RequestEntryCalculatedByRuleFactTestCase()
        {
            const string expectedReason = "Cannot request a fact calculated according to the rule. (Parameter 'inputFactTypes')";

            GivenEmpty()
                .When("Create rule.", _ =>
                    ExpectedException<ArgumentException>(() => GetFactRule((IntFact _) => new IntFact(default))))
                .ThenIsNotNull()
                .AndAreEqual(ex => ex.Message, expectedReason,
                    errorMessage: "Another message expected.")
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(TC.Objects.BuildCannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Return BuildCannotDerive fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ReturnBuildCannotDeriveFactTestCase()
        {
            string expectedReason = $"Parameter outputFactType should not be converted into {typeof(ISpecialFact).FullName}";

            GivenEmpty()
                .When("Create rule.", _ =>
                    ExpectedException<ArgumentException>(() => GetFactRule((IntFact _) => new BuildCannotDerived<Input10Fact>())))
                .ThenIsNotNull()
                .AndAreEqual(ex => ex.Message, expectedReason,
                    errorMessage: "Another message expected.")
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(TC.Objects.BuildNotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Return BuildNotContained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ReturnBuildNotContainedFactTestCase()
        {
            string expectedReason = $"Parameter outputFactType should not be converted into {typeof(ISpecialFact).FullName}";

            GivenEmpty()
                .When("Create rule.", _ =>
                    ExpectedException<ArgumentException>(() => GetFactRule((IntFact _) => new BuildNotContained<Input10Fact>())))
                .ThenIsNotNull()
                .AndAreEqual(ex => ex.Message, expectedReason,
                    errorMessage: "Another message expected.")
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(TC.Objects.BuildContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Return BuildContained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ReturnBuildContainedFactTestCase()
        {
            string expectedReason = $"Parameter outputFactType should not be converted into {typeof(ISpecialFact).FullName}";

            GivenEmpty()
                .When("Create rule.", _ =>
                    ExpectedException<ArgumentException>(() => GetFactRule((IntFact _) => new BuildContained<Input10Fact>())))
                .ThenIsNotNull()
                .AndAreEqual(ex => ex.Message, expectedReason,
                    errorMessage: "Another message expected.")
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Rule), TestCategory(TC.Objects.BuildCanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Return BuildCanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ReturnBuildCanDerivedFactTestCase()
        {
            string expectedReason = $"Parameter outputFactType should not be converted into {typeof(ISpecialFact).FullName}";

            GivenEmpty()
                .When("Create rule.", _ =>
                    ExpectedException<ArgumentException>(() => GetFactRule((IntFact _) => new BuildCanDerived<Input10Fact>())))
                .ThenIsNotNull()
                .AndAreEqual(ex => ex.Message, expectedReason,
                    errorMessage: "Another message expected.")
                .Run();
        }
    }
}
