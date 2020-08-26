using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactContainer.Env;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.VersionedFactContainer
{
    [TestClass]
    public sealed class RemoveVersionedFactTests : VersionedFactContrainerTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Remove a fact without a version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RemoveFactWithoutVersionTestCase()
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
                .When("Try get fact.", container => 
                    container.Remove<FactResult>())
                .Then("Check result.", container =>
                {
                    foreach (var fact in container)
                        Assert.AreNotEqual(factResultWithoutVersion, fact, "Fact without version not removed.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Remove a fact the first version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RemoveFactWithFirstVersionTestCase()
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
                .When("Try get fact.", container => 
                    container.RemoveByVersion<FactResult>(version1))
                .Then("Check result.", container =>
                {
                    foreach (var fact in container)
                        Assert.AreNotEqual(factResult1, fact, "Fact with first version not removed.");
                });
        }
    }
}
