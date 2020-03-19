using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactContainer.Env;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.VersionedFactContainer
{
    [TestClass]
    public class ContainsVersionedFactTests : VersionedFactContrainerTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("A fact without a version is contained in the container.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void FactWithoutVersionContainedContainerTestCase()
        {
            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(new FactResult(0, new Version1()));
                    container.Add(new FactResult(0));
                })
                .When("Run Contains method", container => container.Contains<FactResult>())
                .Then("Check result.", result =>
                {
                    Assert.IsTrue(result, "Fact not contained");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("A fact with a version is contained in the container.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void FactWithVersionContainedContainerTestCase()
        {
            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(new FactResult(0, new Version1()));
                    container.Add(new FactResult(0));
                })
                .When("Run Contains method", container => container.ContainsByVersion<FactResult>(new Version1()))
                .Then("Check result.", result =>
                {
                    Assert.IsTrue(result, "Fact not contained");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("A fact without a version is not contained in the container.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void FactWithoutVersionNotContainedContainerTestCase()
        {
            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(new FactResult(0, new Version1()));
                })
                .When("Run Contains method", container => container.Contains<FactResult>())
                .Then("Check result.", result =>
                {
                    Assert.IsFalse(result, "Fact contained");
                });
        }
    }
}
