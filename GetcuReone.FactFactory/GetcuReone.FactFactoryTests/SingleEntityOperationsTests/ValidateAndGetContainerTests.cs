using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.SingleEntityOperationsTests.Env;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using GetcuReone.FactFactory.SpecialFacts.RuntimeCondition;
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
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Container contain IBuildConditionFact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ContainerContainBuildConditionFactTestCase()
        {
            const string expectedReason = "Container contains IBuildConditionFact facts.";
            Container container = new Container
            {
                new BuildCanDerived<DefaultFact>()
            };

            GivenCreateFacade()
                .When("Run method ValidateAndGetRules.", facade =>
                    ExpectedDeriveException(() => facade.ValidateContainer(container)))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason)
                .Run();
        }
        
        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Container contain IRuntimeConditionFact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ContainerContainRuntimeConditionFactTestCase()
        {
            const string expectedReason = "Container contains IRuntimeConditionFact facts.";
            Container container = new Container
            {
                new RCanDerived<DefaultFact>()
            };

            GivenCreateFacade()
                .When("Run method ValidateAndGetRules.", facade =>
                    ExpectedDeriveException(() => facade.ValidateContainer(container)))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason)
                .Run();
        }
    }
}
