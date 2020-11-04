using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactContainer.Env;
using GetcuReone.FactFactory.Constants;
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

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get a fact the first version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactWithFirstVersionTestCase()
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
                    container.GetFactByVersion<FactResult>(version1))
                .ThenAreEqual(factResult1)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("TGet a fact the second version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactWithSecondVersionTestCase()
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
                    container.GetFactByVersion<FactResult>(version2))
                .ThenAreEqual(factResult2)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get a fact with a version not contained in the container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetFactWithVersionNotContainedInContainerTestCase()
        {
            string expectedReason = $"Fact with type {GetFactType<FactResult>().FactName} and version {GetFactType<Version2>().FactName} not found.";

            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(new FactResult(0).SetVersionParam(new Version1()));
                    container.Add(new FactResult(0));
                })
                .When("Try get fact.", container => 
                    ExpectedFactFactoryException(() => container.GetFactByVersion<FactResult>(new Version2())))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason)
                .Run();
        }
    }
}
