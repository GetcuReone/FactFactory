using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactContainer.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.VersionedFactContainer
{
    [TestClass]
    public sealed class GetVersionedFactTests : VersionedFactContrainerTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get a fact without a version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactWithoutVersionTestCase()
        {
            var version1 = new Version1();
            var version2 = new Version2();

            var factResult1 = new FactResult(0).SetVersionParam(version1);
            var factResult2 = new FactResult(0).SetVersionParam(version2);
            var factResultWithoutVersion = new FactResult(0);

            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(factResult1);
                    container.Add(factResult2);
                    container.Add(factResultWithoutVersion);
                })
                .When("Try get fact.", container => container.GetFact<FactResult>())
                .ThenAreEqual(factResultWithoutVersion)
                .Run();
        }
    }
}
