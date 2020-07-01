using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using VWantAction = GetcuReone.FactFactory.Versioned.Entities.VersionedWantAction;

namespace FactFactory.VersionedTests.VersionedWantAction
{
    [TestClass]
    public sealed class VersionedWantActionTests : CommonTestBase<VersionedFactBase>
    {
        private VWantAction CreateVersionedWantAction(params IFactType[] factTypes)
        {
            return new VWantAction(ct => { }, factTypes.ToList());
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.WantAction), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create wantAction with version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateWantActionWithVersionTestCase()
        {
            GivenEmpty()
                .When("Create wantAction with version", _ => CreateVersionedWantAction(GetFactType<Version1>(), GetFactType<Fact1>()))
                .Then("Check result", wantAction =>
                {
                    Assert.IsNotNull(wantAction.VersionType, "The rule does not contain version information");
                    Assert.IsTrue(GetFactType<Version1>().Compare(wantAction.VersionType), $"{nameof(wantAction.VersionType)} does not store version information");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.WantAction), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create wantAction without version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateWantActionWithoutVersionTestCase()
        {
            GivenEmpty()
                .When("Create wantAction without version", _ => CreateVersionedWantAction(GetFactType<Fact1>()))
                .Then("Check result", wantAction =>
                {
                    Assert.IsNull(wantAction.VersionType, "The rule does not contain version information");
                });
        }
    }
}
