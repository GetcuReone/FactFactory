using FactFactoryTests.FactTypeCacheTests.Env;
using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactTypeCacheTests
{
    [TestClass]
    public sealed class GetFactTypeTests : FactTypeCacheTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.FactType), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get fact type from cache.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetTypeFromCahceTestCase()
        {
            IFact fact = new ResultFact(default);
            IFactType expectedValue = null;

            GivenCreateCahce()
                .And("First get type.", cache =>
                {
                    expectedValue = cache.GetFactType(fact);
                })
                .When("Get type from cache.", cache => cache.GetFactType(fact))
                .ThenAreEqual(expectedValue);
        }
    }
}
