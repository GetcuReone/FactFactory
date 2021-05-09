using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactContainer.Env;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.VersionedFactContainer
{
    [TestClass]
    public sealed class TryGetVersionedFactTests : VersionedFactContrainerTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Try to get a fact without a version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TryGetFactWithoutVersionTestCase()
        {
            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(new FactResult(0).SetVersionParam(new Version1()));
                    container.Add(new FactResult(0).SetVersionParam(new Version2()));
                    container.Add(new FactResult(0));
                })
                .When("Try get fact.", container =>
                {
                    return new
                    {
                        Success = container.TryGetFact(out FactResult fact),
                        Fact = fact,
                    };
                })
                .ThenIsTrue(result => result.Success,
                    errorMessage: "Fact not found.")
                .AndAreNotEqual(result => result.Fact, null,
                    errorMessage: "Fact cannot be null.")
                .AndAreEqual(result => result.Fact.GetVersionOrNull(), null,
                    errorMessage: "Fact cannot be null.")
                .Run();
        }
    }
}
