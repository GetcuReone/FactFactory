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
    }
}
