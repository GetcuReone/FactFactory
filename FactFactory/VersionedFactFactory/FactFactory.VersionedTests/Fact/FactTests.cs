using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.Fact
{
    [TestClass]
    public sealed class FactTests : CommonTestBase<VersionedFactBase>
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Set fact value.")]
        [Timeout(Timeouts.Millisecond.Hundred)]
        public void Versioned_SetValueTestCase()
        {
            long factValue = 5;

            GivenEmpty()
                .When("Create fact", _ => new FactResult(factValue))
                .Then("Check fact value", fact =>
                {
                    Assert.AreEqual(factValue, fact.Value, "Expected another fact value.");
                });
        }
    }
}
