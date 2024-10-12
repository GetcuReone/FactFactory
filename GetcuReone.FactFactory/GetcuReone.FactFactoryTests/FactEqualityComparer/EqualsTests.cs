using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.FactFactoryTests.CommonFacts;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.FactFactoryTests.FactEqualityComparer
{
    [TestClass]
    public sealed class EqualsTests : FactEqualityComparerTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Empty facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void EmptyFactsTestCase()
        {
            GivenCreateComparer()
                .When("Run Equals.", comparer =>
                    comparer.Equals(null, null))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("First fact is null.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FirstFactIsNullTestCase()
        {
            GivenCreateComparer()
                .When("Run Equals.", comparer =>
                    comparer.Equals(new IntFact(1), null))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Second fact is null.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SecondFactIsNullTestCase()
        {
            GivenCreateComparer()
                .When("Run Equals.", comparer =>
                    comparer.Equals(null, new IntFact(1)))
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

            GivenCreateComparer()
                .When("Run Equals.", comparer =>
                    comparer.Equals(fact1, fact2))
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

            GivenCreateComparer()
                .When("Run Equals.", comparer =>
                    comparer.Equals(fact1, fact2))
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

            GivenCreateComparer()
                .When("Run Equals.", comparer =>
                    comparer.Equals(fact1, fact2))
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

            GivenCreateComparer()
                .When("Run Equals.", comparer =>
                    comparer.Equals(fact1, fact2))
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

            GivenCreateComparer()
                .When("Run Equals.", comparer =>
                    comparer.Equals(fact1, fact2))
                .ThenIsTrue()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Different build condition fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void DifferentBuildConditionFactTestCase()
        {
            var fact1 = new BuildContained<IntFact>();
            var fact2 = new BuildContained<OtherFact>();

            GivenCreateComparer()
                .When("Run Equals.", comparer =>
                    comparer.Equals(fact1, fact2))
                .ThenIsFalse()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Same build condition fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SameBuildConditionFactTestCase()
        {
            var fact1 = new BuildContained<OtherFact>();
            var fact2 = new BuildContained<OtherFact>();

            GivenCreateComparer()
                .When("Run Equals.", comparer =>
                    comparer.Equals(fact1, fact2))
                .ThenIsFalse()
                .Run();
        }
    }
}
