using FactFactory.DefaultTests.SingleEntityOperationsTests.Env;
using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Constants;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests
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
                    ExpectedDeriveException(() => facade.ValidateAndGetContainer<Container>(container)))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get original container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetOriginalContainerTestCase()
        {
            const string expectedReason = "IFactContainer.Copy method return original container.";
            var container = new FactContainerGetOriginal();

            GivenCreateFacade()
                .When("Run method ValidateAndGetRules.", facade =>
                    ExpectedDeriveException(() => facade.ValidateAndGetContainer<Container>(container)))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get null container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetNullContainerTestCase()
        {
            const string expectedReason = "IFactContainer.Copy method return null.";
            var container = new FactContainerGetNull();

            GivenCreateFacade()
                .When("Run method ValidateAndGetRules.", facade =>
                    ExpectedDeriveException(() => facade.ValidateAndGetContainer<Container>(container)))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Returned a different type of container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetDifferentContainerTestCase()
        {
            const string expectedReason = "IFactContainer.Copy method returned a different type of container.";
            var container = new FactContainerGetDifferent();

            GivenCreateFacade()
                .When("Run method ValidateAndGetRules.", facade =>
                    ExpectedDeriveException(() => facade.ValidateAndGetContainer<Container>(container)))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }
    }
}
