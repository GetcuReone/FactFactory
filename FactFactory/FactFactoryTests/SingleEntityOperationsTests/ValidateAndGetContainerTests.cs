using FactFactoryTests.SingleEntityOperationsTests.Env;
using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using GetcuReone.FactFactory.Constants;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.SingleEntityOperationsTests
{
    [TestClass]
    public sealed class ValidateAndGetContainerTests : SingleEntityOperationsTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Container cannot be null.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ContainerCannotBeNullTestCase()
        {
            const string expectedReason = "Container cannot be null.";
            Container container = null;

            GivenCreateFacade()
                .When("Run method ValidateAndGetRules.", facade =>
                    ExpectedDeriveException(() => facade.ValidateContainer(container)))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }
    }
}
