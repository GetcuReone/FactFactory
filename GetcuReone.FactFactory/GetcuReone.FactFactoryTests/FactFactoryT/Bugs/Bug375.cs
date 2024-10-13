using System.Threading.Tasks;
using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.FactFactoryT;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace GetcuReone.FactFactoryTests.FactFactoryT.Bugs
{
    [TestClass]
    public sealed class Bug375 : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("[Bug 375] The tree is not started from the last rule (https://github.com/GetcuReone/FactFactory/issues/375)")]
        //[Timeout(Timeouts.Second.Five)]
        public async Task Bug375Async()
        {
            Container container =
            [
                new FOrderId(375),
            ];

            await GivenCreateFactFactory()
                .AndAddRules(new Collection
                {
                    async (FOrderId orderId) =>
                    {
                        // imitation of work
                        await Task.Delay(Timeouts.Millisecond.FiveHundred);

                        return new FOrder(new Order(orderId));
                    },
                    (FOrder order) => new FClientId(order.Value.Id),
                    async (FClientId clientId) =>
                    {
                        // imitation of work
                        await Task.Delay(Timeouts.Millisecond.FiveHundred);

                        return new FClient(new Client(clientId));
                    },
                    (FClient cleint) => new FClientProperty(new ClientProperty(cleint))
                })
                .WhenAsync("Derive.", factory =>
                    factory.DeriveFactAsync<FClientProperty>(container))
                .ThenIsNotNull()
                .RunAsync();
        }
    }

    #region Entities

    public sealed record Order(long Id);

    public sealed record Client(long Id);

    public sealed record ClientProperty(Client Client);

    #endregion

    #region Facts

    public sealed class FOrderId(long value) : BaseFact<long>(value);

    public sealed class FOrder(Order value) : BaseFact<Order>(value);

    public sealed class FClientId(long value) : BaseFact<long>(value);

    public sealed class FClient(Client value) : BaseFact<Client>(value);

    public sealed class FClientProperty(ClientProperty value) : BaseFact<ClientProperty>(value);

    #endregion
}
