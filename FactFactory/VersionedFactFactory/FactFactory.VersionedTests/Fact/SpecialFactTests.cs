using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.DefaultTests.Fact
{
    [TestClass]
    public sealed class SpecialFactTests : CommonTestBase
    {
        private const string _checkFactTypeBlockName = "Check type special fact.";
        private const string _checkFactTypeErrorMessage = "Expected another FactType.";

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.BuildNotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for BuildNotContained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Versioned_GetFactTypeForBuildNotContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet.", () => 
                    new BuildNotContained<FactResult>())
                .ThenIsTrue(fact => 
                    fact.GetFactType() is FactType<BuildNotContained<FactResult>>, _checkFactTypeBlockName, _checkFactTypeErrorMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.BuildContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for BuildContained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Versioned_GetFactTypeForBuildContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet.", () 
                    => new BuildContained<FactResult>())
                .ThenIsTrue(fact => 
                    fact.GetFactType() is FactType<BuildContained<FactResult>>, _checkFactTypeBlockName, _checkFactTypeErrorMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.BuildCannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for BuildCannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Versioned_GetFactTypeForBuildCannotDerivedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet.", () => 
                    new BuildCannotDerived<FactResult>())
                .ThenIsTrue(fact => 
                    fact.GetFactType() is FactType<BuildCannotDerived<FactResult>>, _checkFactTypeBlockName, _checkFactTypeErrorMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.BuildCanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for BuildCanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Versioned_GetFactTypeForBuildCanDerivedFactTestCase()
        {
            GivenEmpty()
                .When("Create BuildCanDerived.", () 
                    => new BuildCanDerived<FactResult>())
                .ThenIsTrue(fact => 
                    fact.GetFactType() is FactType<BuildCanDerived<FactResult>>, _checkFactTypeBlockName, _checkFactTypeErrorMessage)
                .Run();
        }
    }
}
