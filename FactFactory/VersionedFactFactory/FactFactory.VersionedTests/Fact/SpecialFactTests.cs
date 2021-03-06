﻿using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.SpecialFacts;
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
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.NotContained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for NotContained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Versioned_GetFactTypeForNotContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet.", () => 
                    new NotContained<FactResult>())
                .ThenIsTrue(fact => 
                    fact.GetFactType() is FactType<NotContained<FactResult>>, _checkFactTypeBlockName, _checkFactTypeErrorMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.Contained), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for Contained fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Versioned_GetFactTypeForContainedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet.", () 
                    => new Contained<FactResult>())
                .ThenIsTrue(fact => 
                    fact.GetFactType() is FactType<Contained<FactResult>>, _checkFactTypeBlockName, _checkFactTypeErrorMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.CannotDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for CannotDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Versioned_GetFactTypeForCannotDerivedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet.", () => 
                    new CannotDerived<FactResult>())
                .ThenIsTrue(fact => 
                    fact.GetFactType() is FactType<CannotDerived<FactResult>>, _checkFactTypeBlockName, _checkFactTypeErrorMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(TC.Objects.CanDerived), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get FactType for CanDerived fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Versioned_GetFactTypeForCanDerivedFactTestCase()
        {
            GivenEmpty()
                .When("Create NotContainet.", () 
                    => new CanDerived<FactResult>())
                .ThenIsTrue(fact => 
                    fact.GetFactType() is FactType<CanDerived<FactResult>>, _checkFactTypeBlockName, _checkFactTypeErrorMessage)
                .Run();
        }
    }
}
