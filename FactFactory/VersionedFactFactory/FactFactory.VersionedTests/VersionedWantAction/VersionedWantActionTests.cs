using FactFactory.VersionedTests.CommonFacts;
using FactFactoryTestsCommon;
using GetcuReone.FactFactory.Interfaces;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VWantAction = GetcuReone.FactFactory.Versioned.Entities.VersionedWantAction;

namespace FactFactory.VersionedTests.VersionedWantAction
{
    [TestClass]
    public sealed class VersionedWantActionTests : CommonTestBase
    {
        private VWantAction CreateVersionedWantAction(params IFactType[] factTypes)
        {
            return new VWantAction(ct => { }, factTypes);
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][versioned][rule] create wantAction with version")]
        public void CreateWantActionWithVersionTestCase()
        {
            GivenEmpty()
                .When("Create wantAction with version", _ => CreateVersionedWantAction(GetFactType<V1>(), GetFactType<Fact1>()))
                .Then("Check result", wantAction =>
                {
                    Assert.IsNotNull(wantAction.VersionType, "The rule does not contain version information");
                    Assert.IsTrue(GetFactType<V1>().Compare(wantAction.VersionType), $"{nameof(wantAction.VersionType)} does not store version information");
                });
        }
    }
}
