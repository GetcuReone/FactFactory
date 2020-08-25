using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactContainer.Env;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FactFactory.VersionedTests.VersionedFactContainer
{
    [TestClass]
    public sealed class AddVersionedFactTests : VersionedFactContrainerTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add versioned fact to container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddVersionedFactContainerTestCase()
        {
            GivenCreateContainer()
                .When("added versioned fact.", container => 
                    container.Add(new Version1()))
                .Then("Check result.", container =>
                {
                    Assert.IsTrue(container.Contains<Version1>(), "Version fact not contained in container.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add two versioned facts to the container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddTwoVersionedFactsContainerTestCase()
        {
            GivenCreateContainer()
                .When("added versioned fact.", container =>
                {
                    container.Add(new Version1());
                    container.Add(new Version2());
                })
                .Then("Check result.", container =>
                {
                    Assert.IsTrue(container.Contains<Version1>(), "Version fact not contained in container.");
                    Assert.IsTrue(container.Contains<Version2>(), "Version fact not contained in container.");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add two identical versioned facts to the container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddTwoIdenticalVersionedFactsContainerTestCase()
        {
            string expectedReason = $"The fact container already contains {typeof(Version1).Name} type of fact.";

            GivenCreateContainer()
                .And("first addition of versioned fact.", container => 
                    container.Add(new Version1()))
                .When("second addition of versioned fact.", container => 
                    ExpectedFactFactoryException(() => container.Add(new Version1())))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add two facts with identical versions to the container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddTwoFactsWithIdenticalVersionsContainerTestCase()
        {
            string expectedReason = $"The container already contains fact type {GetFactType<FactResult>().FactName} with version equal to version {GetFactType<Version1>().FactName}.";

            GivenCreateContainer()
                .And("first addition of versioned fact.", container => 
                    container.Add(new FactResult(0).SetVersionParam(new Version1())))
                .When("second addition of versioned fact.", container => 
                    ExpectedFactFactoryException(() => container.Add(new FactResult(0).SetVersionParam(new Version1()))))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add one fact with different versions.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddOneFactWithDifferentVersionsTestCase()
        {
            GivenCreateContainer()
                .When("added versioned fact.", container =>
                {
                    container.Add(new FactResult(0).SetVersionParam(new Version1()));
                    container.Add(new FactResult(0).SetVersionParam(new Version2()));
                })
                .ThenAreEqual(container => 
                    container.Count(), 2, errorMessage: "The container must contain two facts.")
                .AndIsTrue(container =>
                    container.All(fact => fact is FactResult), errorMessage: "Only one type of fact was expected.")
                .AndIsTrue(container => 
                    container.First().GetVersionOrNull() is Version1, errorMessage: "FactResult with 1 version not contained in container.")
                .AndIsTrue(container =>
                    container.Last().GetVersionOrNull() is Version2, errorMessage: "FactResult with 2 version not contained in container.");
        }
    }
}
