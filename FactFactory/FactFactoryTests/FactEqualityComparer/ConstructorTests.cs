using FactFactory.TestsCommon;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using F_EqualityComparer = GetcuReone.FactFactory.BaseEntities.FactEqualityComparer;

namespace GetcuReone.FactFactoryTests.FactEqualityComparer
{
    [TestClass]
    public sealed class ConstructorTests : FactEqualityComparerTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create object without cache.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateObjectWithoutCacheTestCase()
        {
            GivenEmpty()
                .When("Create object.", () =>
                    ExpectedException<ArgumentNullException>(() => new F_EqualityComparer(null)))
                .ThenIsNotNull()
                .Run();
        }
    }
}
