using FactFactory.PriorityTests.CommonFacts;
using FactFactory.PriorityTests.SingleEntityOperations.Env;
using FactFactory.TestsCommon;
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
                .ThenAreEqual(expectedValue);
        }
    }
}
