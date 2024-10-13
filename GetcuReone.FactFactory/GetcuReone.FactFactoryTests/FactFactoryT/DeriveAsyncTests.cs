using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace GetcuReone.FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class DeriveAsyncTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rule run asynchronously.")]
        [Timeout(Timeouts.Second.One)]
        public async Task RuleRunAsynchronouslyTestCase()
        {
            Input16Fact fact16 = null;
            const int expectedValue = 16;

            await GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    async () =>
                    {
                        await Task.Delay(Timeouts.Millisecond.Hundred);
                        return new Input16Fact(expectedValue);
                    }
                })
                .And("Want actions.", factory => factory.WantFacts((Input16Fact fact) => fact16 = fact))
                .WhenAsync("Derive.", factory => factory.DeriveAsync())
                .Then("Check result.", () =>
                {
                    Assert.AreEqual(expectedValue, fact16);
                })
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Calling synchronous rule.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public async Task CallingSynchronousRuleTestCase()
        {
            Input16Fact fact16 = null;
            const int expectedValue = 16;

            await GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    () =>
                    {
                        return new Input16Fact(expectedValue);
                    }
                })
                .And("Want actions.", factory => factory.WantFacts((Input16Fact fact) => fact16 = fact))
                .WhenAsync("Derive.", factory => factory.DeriveAsync())
                .Then("Check result.", () =>
                {
                    Assert.AreEqual(fact16, expectedValue);
                })
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("WantAction run asynchronously.")]
        [Timeout(Timeouts.Second.Five)]
        public async Task WantActionRunAsynchronouslyTestCase()
        {
            Input16Fact fact16 = null;
            const int expectedValue = 16;

            await GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    async () =>
                    {
                        await Task.Delay(Timeouts.Millisecond.Hundred);
                        return new Input16Fact(expectedValue);
                    }
                })
                .And("Want actions.", factory => factory.WantFacts(async (Input16Fact fact) =>
                {
                    await Task.Delay(Timeouts.Millisecond.Hundred);
                    fact16 = fact;
                }))
                .WhenAsync("Derive.", factory => factory.DeriveAsync())
                .Then("Check result.", () =>
                {
                    Assert.AreEqual(fact16, expectedValue);
                })
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Calling synchronous wantAction.")]
        [Timeout(Timeouts.Second.One)]
        public async Task CallingSynchronousWantActionTestCase()
        {
            Input16Fact fact16 = null;
            const int expectedValue = 16;

            await GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    async () =>
                    {
                        await Task.Delay(Timeouts.Millisecond.Hundred);
                        return new Input16Fact(expectedValue);
                    }
                })
                .And("Want actions.", factory => factory.WantFacts((Input16Fact fact) =>
                {
                    fact16 = fact;
                }))
                .WhenAsync("Derive.", factory => factory.DeriveAsync())
                .Then("Check result.", () =>
                {
                    Assert.AreEqual(fact16, expectedValue);
                })
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Running asynchronous rules in parallel.")]
        [Timeout(Timeouts.Second.Two)]
        public async Task RunningAsynchronousRulesInParallelTestCase()
        {
            Input16Fact fact16 = null;
            const int expectedValue = 16;

            await GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    {
                        async () =>
                        {
                            await Task.Delay(Timeouts.Millisecond.Hundred);
                            return new Input10Fact(10);
                        }, FactWorkOption.CanExcecuteParallel | FactWorkOption.CanExecuteAsync
                    },
                    {
                        async () =>
                        {
                            await Task.Delay(Timeouts.Millisecond.Hundred);
                            return new Input6Fact(6);
                        }, FactWorkOption.CanExcecuteParallel | FactWorkOption.CanExecuteAsync
                    },
                    (Input6Fact fact6, Input10Fact fact10) =>
                    {
                        return new Input16Fact(fact6 + fact10);
                    }
                })
                .And("Want actions.", factory => factory.WantFacts((Input16Fact fact) =>
                {
                    fact16 = fact;
                }))
                .WhenAsync("Derive.", factory => factory.DeriveAsync())
                .Then("Check result.", () =>
                {
                    Assert.AreEqual(fact16, expectedValue);
                })
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive default cancellationToken.")]
        [Timeout(Timeouts.Second.Two)]
        public async Task DeriveDefaultCancellationTokenTestCase()
        {
            FCancellationToken fCancellationToken = null;

            await GivenCreateFactFactory()
                .AndAddRules(new Collection())
                .And("Want actions.", factory => factory.WantFacts((FCancellationToken fact) =>
                {
                    fCancellationToken = fact;
                }))
                .WhenAsync("Derive.", factory => factory.DeriveAsync())
                .Then("Check result.", () =>
                {
                    Assert.IsNotNull(fCancellationToken);
                })
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Derive cancellationToken.")]
        [Timeout(Timeouts.Second.Two)]
        public async Task DeriveCancellationTokenTestCase()
        {
            FCancellationToken fCancellationToken = null;
            CancellationTokenSource src = new();
            CancellationToken cancellationToken = src.Token;

            await GivenCreateFactFactory()
                .AndAddRules(new Collection())
                .And("Want actions.", factory => factory.WantFacts((FCancellationToken fact) =>
                {
                    fCancellationToken = fact;
                }))
                .WhenAsync("Derive.", factory => factory.DeriveAsync(cancellationToken))
                .Then("Check result.", () =>
                {
                    Assert.AreEqual(cancellationToken, fCancellationToken);
                })
                .RunAsync();
        }
    }
}
