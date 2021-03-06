﻿using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using VWantAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactory.VersionedTests.VersionedWantAction
{
    [TestClass]
    public sealed class VersionedWantActionTests : CommonTestBase
    {
        private VWantAction CreateVersionedWantAction(params IFactType[] factTypes)
        {
            return new VWantAction(ct => { }, factTypes.ToList(), FactWorkOption.CanExecuteSync);
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.WantAction), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create wantAction with version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateWantActionWithVersionTestCase()
        {
            GivenEmpty()
                .When("Create wantAction with version.", _ => 
                    GetWantAction((Version1 v, Fact1 _) => { }))
                .ThenGetVersionType()
                .AndIsNotNull()
                .And("Check result.", versionType =>
                {
                    Assert.IsTrue(GetFactType<Version1>().EqualsFactType(versionType), $"{nameof(versionType)} does not store version information");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.WantAction), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create wantAction without version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CreateWantActionWithoutVersionTestCase()
        {
            GivenEmpty()
                .When("Create wantAction without version", _ =>
                    CreateVersionedWantAction(GetFactType<Fact1>()))
                .ThenNotContainVersionType()
                .Run();
        }
    }
}
