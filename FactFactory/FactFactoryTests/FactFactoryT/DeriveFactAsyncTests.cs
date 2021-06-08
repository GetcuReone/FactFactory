using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class DeriveFactAsyncTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rule run asynchronously.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public async Task RunDeriveFactAsyncTestCase()
        {
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
                .WhenAsync("Derive.", factory => factory.DeriveFactAsync<Input16Fact>())
                .ThenFactValueEquals(expectedValue)
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Running asynchronous rules in parallel with facts and conditions.")]
        [Timeout(Timeouts.Second.One)]
        public async Task RunningAsynchronousRulesInParallelWithFactConditionsTestCase()
        {
            const int expectedValue = 16;
            var container = new Container
            {
                new Input1Fact(1),
            };

            await GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    {
                        async (Input1Fact fact, Contained<Input1Fact> _) =>
                        {
                            return await Task.Run(() => new Input6Fact(fact * 6));
                        },
                        FactWorkOption.CanExecuteAsync | FactWorkOption.CanExcecuteParallel
                    },
                    {
                        async (Input1Fact fact, Contained<Input1Fact> _) =>
                        {
                            return await Task.Run(() => new Input10Fact(fact * 10));
                        },
                        FactWorkOption.CanExecuteAsync | FactWorkOption.CanExcecuteParallel
                    },
                    {
                        async (Input6Fact fact6, Input10Fact fact10) =>
                        {
                            return await Task.Run(() => new Input16Fact(fact6 + fact10));
                        },
                        FactWorkOption.CanExecuteAsync | FactWorkOption.CanExcecuteParallel
                    }
                })
                .WhenAsync("Derive.", factory => factory.DeriveFactAsync<Input16Fact>(container))
                .ThenFactValueEquals(expectedValue)
                .RunAsync();
        }
    }
}
