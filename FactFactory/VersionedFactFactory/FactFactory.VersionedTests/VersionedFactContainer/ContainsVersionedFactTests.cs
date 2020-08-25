using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactContainer.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.VersionedFactContainer
{
    [TestClass]
    public class ContainsVersionedFactTests : VersionedFactContrainerTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("A fact without a version is contained in the container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FactWithoutVersionContainedContainerTestCase()
        {
            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(new FactResult(0).SetVersionParam(new Version1()));
                    container.Add(new FactResult(0));
                })
                .When("Run Contains method", container => container.Contains<FactResult>())
                .ThenIsTrue(errorMessage: "Fact not contained");
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("A fact with a version is contained in the container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FactWithVersionContainedContainerTestCase()
        {
            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(new FactResult(0).SetVersionParam(new Version1()));
                    container.Add(new FactResult(0));
                })
                .When("Run Contains method", container => container.ContainsByVersion<FactResult>(new Version1()))
                .ThenIsTrue(errorMessage: "Fact not contained");
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("A fact without a version is not contained in the container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FactWithoutVersionNotContainedContainerTestCase()
        {
            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(new FactResult(0).SetVersionParam(new Version1()));
                })
                .When("Run Contains method", container => container.Contains<FactResult>())
                .ThenIsFalse(errorMessage: "Fact contained");
        }
    }
}
