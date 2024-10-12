using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.Fact
{
    [TestClass]
    public sealed class FactTests : CommonTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Set fact value.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Versioned_SetValueTestCase()
        {
            const long expectedValue = 5;

            GivenEmpty()
                .When("Create fact.", _ =>
                    new FactResult(expectedValue))
                .ThenFactValueEquals(expectedValue)
                .Run();
        }
    }
}
