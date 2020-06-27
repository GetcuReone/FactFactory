using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactContainer.Env;
using GetcuReone.FactFactory.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FactFactory.VersionedTests.VersionedFactContainer
{
    [TestClass]
    public sealed class AddVersionedFactTests : VersionedFactContrainerTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Add versioned fact to container.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void AddVersionedFactContainerTestCase()
        {
            GivenCreateContainer()
                .When("added versioned fact", container => container.Add(new Version1()))
                .Then("Check result", container =>
                {
                    Assert.IsTrue(container.Contains<Version1>(), "Version fact not contained in container");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Add two versioned facts to the container.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void AddTwoVersionedFactsContainerTestCase()
        {
            GivenCreateContainer()
                .When("added versioned fact", container =>
                {
                    container.Add(new Version1());
                    container.Add(new Version2());
                })
                .Then("Check result", container =>
                {
                    Assert.IsTrue(container.Contains<Version1>(), "Version fact not contained in container");
                    Assert.IsTrue(container.Contains<Version2>(), "Version fact not contained in container");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Add two identical versioned facts to the container.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void AddTwoIdenticalVersionedFactsContainerTestCase()
        {
            string expectedReason = $"The container already contains fact type {typeof(Version1).FullName} without version.";

            GivenCreateContainer()
                .And("first addition of versioned fact", container => container.Add(new Version1()))
                .When("second addition of versioned fact", container => ExpectedFactFactoryException(() => container.Add(new Version1())))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Add two facts with identical versions to the container.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void AddTwoFactsWithIdenticalVersionsContainerTestCase()
        {
            string expectedReason = $"The container already contains fact type {typeof(FactResult).FullName} with version equal to version {typeof(Version1).FullName}.";

            GivenCreateContainer()
                .And("first addition of versioned fact", container => container.Add(new FactResult(0, new Version1())))
                .When("second addition of versioned fact", container => ExpectedFactFactoryException(() => container.Add(new FactResult(0, new Version1()))))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Add one fact with different versions.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void AddOneFactWithDifferentVersionsTestCase()
        {
            GivenCreateContainer()
                .When("added versioned fact", container =>
                {
                    container.Add(new FactResult(0, new Version1()));
                    container.Add(new FactResult(0, new Version2()));
                })
                .Then("Check result", container =>
                {
                    Assert.AreEqual(2, container.Count(), "The container must contain two facts.");

                    foreach (var fact in container)
                        Assert.IsTrue(fact is FactResult, "Only one type of fact was expected.");

                    var fact1 = container.First();
                    var fact2 = container.Last();

                    Assert.IsTrue(fact1.Version is Version1, "FactResult with 1 version not contained in container");
                    Assert.IsTrue(fact2.Version is Version2, "FactResult with 2 version not contained in container");
                });
        }
    }
}
