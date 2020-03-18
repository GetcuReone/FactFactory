using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;

namespace FactFactory.VersionedTests.VersionedFactContainer
{
    [TestClass]
    public sealed class VersionedFactContainerTests : CommonTestBase<VersionedFactBase>
    {
        private GivenBlock<Container> GivenCreateContainer()
        {
            return Given("Create container", () => new Container());
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Add versioned fact to container.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
        [TestCategory(TC.Negative), TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Add two identical versioned facts to the container.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddTwoIdenticalVersionedFactsContainerTestCase()
        {
            string expectedReason = $"The fact container already contains {typeof(Version1).FullName} type of fact.";

            GivenCreateContainer()
                .And("first addition of versioned fact", container => container.Add(new Version1()))
                .When("second addition of versioned fact", container => ExpectedFactFactoryException(() => container.Add(new Version1())))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Get copied container.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void VersionedFactContainer_GetCopiedContainerTestCase()
        {
            Fact1 fact1 = new Fact1(1);

            Container originalContainer = null;
            IFactContainer<VersionedFactBase> copyContainer = null;

            Given("Create container", () => originalContainer = new Container())
                .And("Add facts", _ =>
                {
                    originalContainer.Add(fact1);
                })
                .When("Get value", _ => copyContainer = originalContainer.Copy())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(copyContainer, "container cannot be null");
                    Assert.AreNotEqual(originalContainer, copyContainer, "Containers should not be equal");
                    Assert.AreEqual(originalContainer.Count(), copyContainer.Count(), "Containers should have the same amount of facts");

                    Assert.IsTrue(copyContainer.TryGetFact(out Fact1 fact), $"{nameof(Fact1)} must be contained in a container");
                    Assert.AreEqual(fact1, fact, $"Original copy of {nameof(Fact1)} fact expected");
                });
        }
    }
}
