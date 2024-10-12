using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.SingleEntityOperationsTests.Env;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.FactFactoryTests.CommonFacts;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.FactFactoryTests.SingleEntityOperationsTests
{
    [TestClass]
    public sealed class EqualsFactsTests : SingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Empty facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void EmptyFactsTestCase()
        {
            var context = GetWantActionContext(null, null);

            GivenCreateFacade()
                .When("Run Equals.", facade =>
                    facade.EqualsFacts(null, null, context))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("First fact is null.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FirstFactIsNullTestCase()
        {
            var context = GetWantActionContext((IWantAction)null, (IFactContainer)null);

            GivenCreateFacade()
                .When("Run Equals.", facade =>
                    facade.EqualsFacts(new IntFact(1), null, context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Second fact is null.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SecondFactIsNullTestCase()
        {
            var context = GetWantActionContext((IWantAction)null, (IFactContainer)null);

            GivenCreateFacade()
                .When("Run Equals.", facade =>
                    facade.EqualsFacts(null, new IntFact(1), context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Identical facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void IdenticalFactIsNullTestCase()
        {
            var fact1 = new IntFact(default);
            var fact2 = new IntFact(default);
            var context = GetWantActionContext((IWantAction)null, (IFactContainer)null);

            GivenCreateFacade()
                .When("Run Equals.", facade =>
                    facade.EqualsFacts(fact1, fact2, context))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Different number of parameters.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DifferentNumberParametersTestCase()
        {
            var fact1 = new IntFact(default);
            fact1.AddParameter(new FactParameter("code", new object()));
            var fact2 = new IntFact(default);
            var context = GetWantActionContext((IWantAction)null, (IFactContainer)null);

            GivenCreateFacade()
                .When("Run Equals.", facade =>
                    facade.EqualsFacts(fact1, fact2, context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Different type.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DifferentTypeTestCase()
        {
            var fact1 = new IntFact(default);
            var fact2 = new OtherFact(default);
            var context = GetWantActionContext((IWantAction)null, (IFactContainer)null);

            GivenCreateFacade()
                .When("Run Equals.", facade =>
                    facade.EqualsFacts(fact1, fact2, context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Different special fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DifferentSpecialFactTestCase()
        {
            var fact1 = new SpecialFact1();
            var fact2 = new SpecialFact2();
            var context = GetWantActionContext((IWantAction)null, (IFactContainer)null);

            GivenCreateFacade()
                .When("Run Equals.", facade =>
                    facade.EqualsFacts(fact1, fact2, context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Same special fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SameSpecialFactTestCase()
        {
            var fact1 = new SpecialFact();
            var fact2 = new SpecialFact();
            var context = GetWantActionContext((IWantAction)null, (IFactContainer)null);

            GivenCreateFacade()
                .When("Run Equals.", facade =>
                    facade.EqualsFacts(fact1, fact2, context))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Different build condition fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DifferentConditionFactTestCase()
        {
            var fact1 = new BuildContained<IntFact>();
            var fact2 = new BuildContained<OtherFact>();
            var context = GetWantActionContext((IWantAction)null, (IFactContainer)null);

            GivenCreateFacade()
                .When("Run Equals.", facade =>
                    facade.EqualsFacts(fact1, fact2, context))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Same build condition fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SameConditionFactTestCase()
        {
            var fact1 = new BuildContained<OtherFact>();
            var fact2 = new BuildContained<OtherFact>();
            var context = GetWantActionContext((IWantAction)null, (IFactContainer)null);

            GivenCreateFacade()
                .When("Run Equals.", facade =>
                    facade.EqualsFacts(fact1, fact2, context))
                .ThenIsFalse()
                .Run();
        }
    }
}
