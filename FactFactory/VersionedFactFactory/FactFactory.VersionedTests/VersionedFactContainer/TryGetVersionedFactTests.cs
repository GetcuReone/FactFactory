using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactContainer.Env;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.VersionedFactContainer
{
    [TestClass]
    [Ignore]
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
                .Then("Check result.", result =>
                {
                    Assert.IsTrue(result.Success, "Fact not found.");
                    Assert.IsNotNull(result.Fact, "Fact cannot be null.");
                    Assert.IsNull(result.Fact.Version, "Version must be null.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Try to get a fact the first version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TryGetFactWithFirstVersionTestCase()
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
                        Success = container.TryGetFactByVersion(out FactResult fact, new Version1()),
                        Fact = fact,
                    };
                })
                .Then("Check result.", result =>
                {
                    Assert.IsTrue(result.Success, "Fact not found.");
                    Assert.IsNotNull(result.Fact, "Fact cannot be null.");
                    Assert.IsTrue(result.Fact.GetVersionOrNull() is Version1, "Expected different version.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Try to get a fact the second version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TryGetFactWithSecondVersionTestCase()
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
                        Success = container.TryGetFactByVersion(out FactResult fact, new Version2()),
                        Fact = fact,
                    };
                })
                .Then("Check result.", result =>
                {
                    Assert.IsTrue(result.Success, "Fact not found.");
                    Assert.IsNotNull(result.Fact, "Fact cannot be null.");
                    Assert.IsTrue(result.Fact.GetVersionOrNull() is Version2, "Expected different version.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Trying to get a fact with a version not contained in the container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TryingGetFactWithVersionNotContainedInContainerTestCase()
        {
            GivenCreateContainer()
                .And("Added versioned fact.", container =>
                {
                    container.Add(new FactResult(0).SetVersionParam(new Version1()));
                    container.Add(new FactResult(0));
                })
                .When("Try get fact.", container =>
                {
                    return new
                    {
                        Success = container.TryGetFactByVersion(out FactResult fact, new Version2()),
                        Fact = fact,
                    };
                })
                .Then("Check result.", result =>
                {
                    Assert.IsFalse(result.Success, "Fact not found.");
                    Assert.IsNull(result.Fact, "Fact must be null.");
                });
        }
    }
}
