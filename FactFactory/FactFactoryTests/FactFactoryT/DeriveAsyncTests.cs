using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class DeriveAsyncTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Rule run asynchronously.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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
                    Assert.AreEqual(fact16, expectedValue);
                })
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Calling synchronous rules.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public async Task CallingSynchronousRulesTestCase()
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
        [Timeout(Timeouts.Millisecond.FiveHundred)]
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
    }
}
