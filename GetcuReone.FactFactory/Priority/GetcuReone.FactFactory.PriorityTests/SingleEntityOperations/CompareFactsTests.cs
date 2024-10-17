using FactFactory.PriorityTests.CommonFacts;
using FactFactory.PriorityTests.SingleEntityOperations.Env;
using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Priority.Common.Extensions;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.PriorityTests.SingleEntityOperations
{
    [TestClass]
    public sealed class CompareFactsTests : PrioritySingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Projects.Priority), TestCategory(GetcuReoneTC.Unit)]
        [Description("Compare facts witouht priority parameters.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void WithoutPriorityTestCase()
        {
            var fact1 = new FactResult(default);
            var fact2 = new FactResult(default);
            const int expectedValue = 0;

            GivenCreateFacade()
                .When("Compare fact.", facade => facade.CompareFacts(fact1, fact2))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Projects.Priority), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparing facts with the same priority.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void WithSamePriorityTestCase()
        {
            const int expectedValue = 0;

            var parameterCache = new FactParameterCache();

            var fact1 = new FactResult(default)
                .AddPriorityParameter(new Priority1(), parameterCache);

            var fact2 = new FactResult(default)
                .AddPriorityParameter(new Priority1(), parameterCache);
            

            GivenCreateFacade()
                .When("Compare fact.", facade => facade.CompareFacts(fact1, fact2))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Projects.Priority), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of facts with the first and second priorities.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void WithFirstAndSecondPrioritiesTestCase()
        {
            const int expectedValue = 1;

            var parameterCache = new FactParameterCache();

            var fact1 = new FactResult(default)
                .AddPriorityParameter(new Priority1(), parameterCache);

            var fact2 = new FactResult(default)
                .AddPriorityParameter(new Priority2(), parameterCache);

            GivenCreateFacade()
                .When("Compare fact.", facade => facade.CompareFacts(fact1, fact2))
                .ThenAreEqual(expectedValue)
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Projects.Priority), TestCategory(GetcuReoneTC.Unit)]
        [Description("Comparison of facts with the second and first priorities.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void WithSecondAndFirstPrioritiesTestCase()
        {
            const int expectedValue = -1;

            var parameterCache = new FactParameterCache();

            var fact1 = new FactResult(default)
                .AddPriorityParameter(new Priority2(), parameterCache);

            var fact2 = new FactResult(default)
                .AddPriorityParameter(new Priority1(), parameterCache);

            GivenCreateFacade()
                .When("Compare fact.", facade => facade.CompareFacts(fact1, fact2))
                .ThenAreEqual(expectedValue)
                .Run();
        }
    }
}
