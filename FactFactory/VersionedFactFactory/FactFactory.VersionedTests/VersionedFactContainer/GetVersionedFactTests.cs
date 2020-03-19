﻿using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactContainer.Env;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;

namespace FactFactory.VersionedTests.VersionedFactContainer
{
    [TestClass]
    public sealed class GetVersionedFactTests : VersionedFactContrainerTestBase
    {
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

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Get a fact without a version.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetFactWithoutVersionTestCase()
        {
            var version1 = new Version1();
            var version2 = new Version2();

            var factResult1 = new FactResult(0, version1);
            var factResult2 = new FactResult(0, version2);
            var factResultWithoutVersion = new FactResult(0);

            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(factResult1);
                    container.Add(factResult2);
                    container.Add(factResultWithoutVersion);
                })
                .When("Try get fact.", container => container.GetFact<FactResult>())
                .Then("Check result.", fact =>
                {
                    Assert.AreEqual(factResultWithoutVersion, fact, "Expected another fact.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Get a fact the first version.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetFactWithFirstVersionTestCase()
        {
            var version1 = new Version1();
            var version2 = new Version2();

            var factResult1 = new FactResult(0, version1);
            var factResult2 = new FactResult(0, version2);
            var factResultWithoutVersion = new FactResult(0);

            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(factResult1);
                    container.Add(factResult2);
                    container.Add(factResultWithoutVersion);
                })
                .When("Try get fact.", container => container.GetFactByVersion<FactResult>(version1))
                .Then("Check result.", fact =>
                {
                    Assert.AreEqual(factResult1, fact, "Expected another fact.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("TGet a fact the second version.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetFactWithSecondVersionTestCase()
        {
            var version1 = new Version1();
            var version2 = new Version2();

            var factResult1 = new FactResult(0, version1);
            var factResult2 = new FactResult(0, version2);
            var factResultWithoutVersion = new FactResult(0);

            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(factResult1);
                    container.Add(factResult2);
                    container.Add(factResultWithoutVersion);
                })
                .When("Try get fact.", container => container.GetFactByVersion<FactResult>(version2))
                .Then("Check result.", fact =>
                {
                    Assert.AreEqual(factResult2, fact, "Expected another fact.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Get a fact with a version not contained in the container.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetFactWithVersionNotContainedInContainerTestCase()
        {
            string expectedReason = $"Fact with type {GetFactType<FactResult>().FactName} and version {GetFactType<Version2>().FactName} not found.";

            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(new FactResult(0, new Version1()));
                    container.Add(new FactResult(0));
                })
                .When("Try get fact.", container => ExpectedFactFactoryException(() => container.GetFactByVersion<FactResult>(new Version2())))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }
    }
}