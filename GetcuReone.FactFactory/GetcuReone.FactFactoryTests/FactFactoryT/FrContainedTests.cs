﻿using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.SpecialFacts.RuntimeCondition;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace GetcuReone.FactFactoryTests.FactFactoryT
{
    /// <summary>
    /// <see cref="FrContained{TFact}"/> testing class.
    /// </summary>
    [TestClass]
    public sealed class FrContainedTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive ResultFact if Input1Fact contain container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RContained_DeriveResultFactIfInput1FactContainedTestCase()
        {
            const int expectedValue = 1;
            ResultFact expectedFact = null;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (Input1Fact fact) => new ResultFact(fact),
                })
                .And("Want fact.", factory => factory.WantFacts((FrContained<Input1Fact> _, ResultFact fact) =>
                {
                    expectedFact = fact;
                }, new Container()))
                .When("Derive facts.", factory => 
                {
                    factory.Derive();
                    return expectedFact;
                })
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive ResultFact if Input1Fact contain container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RContained_DeriveResultFactIfInput1FactContained_2_TestCase()
        {
            const int expectedValue = 1;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (FrContained<Input1Fact> _, Input1Fact fact) => new ResultFact(fact)
                })
                .When("Derive facts.", factory =>
                    factory.DeriveFact<ResultFact>(new Container()))
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive fact by alternative solution.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RContained_DeriveFactByAlternativeSolutionTestCase()
        {
            const int expectedValue = 1;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (FrContained<Input2Fact> _, Input1Fact fact) => new ResultFact(fact),

                    (Input1Fact fact) => new Input3Fact(fact),
                    (Input3Fact fact) => new ResultFact(fact)
                })
                .When("Derive facts.", factory =>
                    factory.DeriveFact<ResultFact>(new Container()))
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .Run();
        }
        
        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("There is no alternative route.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RContained_ThereIsNoAlternativeRouteTestCase()
        {
            const int expectedValue = 1;

            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (FrContained<Input2Fact> _, Input1Fact fact) => new ResultFact(fact)
                })
                .When("Derive facts.", factory =>
                    ExpectedDeriveException(() => factory.DeriveFact<ResultFact>(new Container())))
                .ThenIsNotNull()
                .AndIsTrue(error => error.Details.Any(d => d.Code == ErrorCode.RuntimeCondition))
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Impossible WantAction request.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RContained_ImpossibleWantActionRequestTestCase()
        {
            GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new ResultFact(default)
                })
                .And("Want facts.", factory =>
                    factory.WantFacts((FrContained<Input1Fact> _, ResultFact fact) => { }, new Container()))
                .When("Derive facts.", factory =>
                    ExpectedDeriveException(factory.Derive))
                .ThenIsNotNull()
                .AndIsTrue(error => error.Details.Any(d => d.Code == ErrorCode.RuntimeCondition))
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive ResultFact if Input1Fact contain container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public async Task RContained_DeriveResultFactIfInput1FactContained_Async_TestCase()
        {
            const int expectedValue = 1;
            ResultFact expectedFact = null;

            await GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (Input1Fact fact) => new ResultFact(fact),
                })
                .And("Want fact.", factory => factory.WantFacts((FrContained<Input1Fact> _, ResultFact fact) =>
                {
                    expectedFact = fact;
                    return default;
                }, new Container()))
                .WhenAsync("Derive facts.", async factory =>
                {
                    await factory.DeriveAsync();
                    return expectedFact;
                })
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive ResultFact if Input1Fact contain container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public async Task RContained_DeriveResultFactIfInput1FactContained_2_Async_TestCase()
        {
            const int expectedValue = 1;

            await GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (FrContained<Input1Fact> _, Input1Fact fact) =>
                    {
                        return new ValueTask<ResultFact>(new ResultFact(fact));
                    }
                })
                .WhenAsync("Derive facts.", factory =>
                    factory.DeriveFactAsync<ResultFact>(new Container()))
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive fact by alternative solution.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public async Task RContained_DeriveFactByAlternativeSolution_Async_TestCase()
        {
            const int expectedValue = 1;

            await GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (FrContained<Input2Fact> _, Input1Fact fact) =>
                    {
                        return new ValueTask<ResultFact>(new ResultFact(fact));
                    },

                    (Input1Fact fact) => new Input3Fact(fact),
                    (Input3Fact fact) => new ResultFact(fact)
                })
                .WhenAsync("Derive facts.", factory =>
                    factory.DeriveFactAsync<ResultFact>(new Container()))
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue)
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("There is no alternative route.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public async Task RContained_ThereIsNoAlternativeRoute_Async_TestCase()
        {
            const int expectedValue = 1;

            await GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new Input1Fact(expectedValue),
                    (FrContained<Input2Fact> _, Input1Fact fact) =>
                    {
                        return new ValueTask<ResultFact>(new ResultFact(fact));
                    }
                })
                .WhenAsync("Derive facts.", async factory =>
                {
                    try
                    {
                        await factory.DeriveFactAsync<ResultFact>(new Container());
                    }
                    catch(InvalidDeriveOperationException ex)
                    {
                        return ex;
                    }

                    return null;
                })
                .ThenIsNotNull()
                .AndIsTrue(error => 
                    error.Details.Any(d => d.Code == ErrorCode.RuntimeCondition))
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Impossible WantAction request.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public async Task RContained_ImpossibleWantActionRequest_Async_TestCase()
        {
            await GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () => new ResultFact(default)
                })
                .And("Want facts.", factory =>
                    factory.WantFacts((FrContained<Input1Fact> _, ResultFact fact) => { return default; }, new Container()))
                .WhenAsync("Derive facts.", async factory =>
                {
                    try
                    {
                        await factory.DeriveAsync();
                    }
                    catch (InvalidDeriveOperationException ex)
                    {
                        return ex;
                    }

                    return null;
                })
                .ThenIsNotNull()
                .AndIsTrue(error => error.Details.Any(d => d.Code == ErrorCode.RuntimeCondition))
                .RunAsync();
        }
    }
}
