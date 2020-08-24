using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedSingleEntityOperations.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Collection = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRuleCollection;

namespace FactFactory.VersionedTests.VersionedSingleEntityOperations
{
    [TestClass]
    [Ignore]
    public sealed class GetCompatibleRulesTests : VersionedSingleEntityOperationsTestBase
    {
        public Collection Collection { get; private set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            Collection = new Collection
            {
                (Fact1 f1, Fact2 f2) => new FactResult(default),
                (Fact1 f1) => new FactResult(default),
                (Version1 v, Fact1 f1) => new FactResult(default),
                (Version2 v, Fact1 f1) => new FactResult(default),
            };
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(TC.Projects.Versioned), TestCategory(GetcuReoneTC.Unit)]
        [Description("Target and action without version.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TargetAndActionWithoutVersionTestCase()
        {
            var wantAction = GetWantAction((Fact1 f1) => { });
            var context = GetWantActionContext(wantAction, Container);

            GivenCreateFacade()
                .When("Get compatible rules.", facade =>
                    facade.GetCompatibleRules(wantAction, Collection, context))
                .ThenIsNotNull()
                .AndAreEqual(Collection);
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(TC.Projects.Versioned), TestCategory(GetcuReoneTC.Unit)]
        [Description("Target without version (1).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TargetWithoutVersion_1_TestCase()
        {
            var wantAction = GetWantAction((Version1 v) => { });
            var target = GetFactRule((Fact1 f1) => new FactResult(default));
            var context = GetWantActionContext(wantAction, Container);

            GivenCreateFacade()
                .When("Get compatible rules.", facade =>
                    facade.GetCompatibleRules(target, Collection, context))
                .ThenIsNotNull()
                .AndAreNotEqual(Collection)
                .And("Check result.", collection => 
                {
                    collection = collection.ToList();
                    Assert.AreEqual(1, collection.Count());
                    return collection.First();
                })
                .AndAreEqual(Collection[2]);
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(TC.Projects.Versioned), TestCategory(GetcuReoneTC.Unit)]
        [Description("Target without version (2).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TargetWithoutVersion_2_TestCase()
        {
            var wantAction = GetWantAction((Version2 v) => { });
            var target = GetFactRule((Fact1 f1) => new FactResult(default));
            var context = GetWantActionContext(wantAction, Container);

            GivenCreateFacade()
                .When("Get compatible rules.", facade =>
                    facade.GetCompatibleRules(target, Collection, context))
                .ThenIsNotNull()
                .AndAreNotEqual(Collection)
                .And("Check result.", collection =>
                {
                    collection = collection.ToList();
                    Assert.AreEqual(2, collection.Count());
                    return collection.Last();
                })
                .AndAreEqual(Collection[3]);
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(TC.Projects.Versioned), TestCategory(GetcuReoneTC.Unit)]
        [Description("Target with version 1.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TargetWithVersion1TestCase()
        {
            var wantAction = GetWantAction((Version1 v) => { });
            var target = GetFactRule((Version1 v) => new FactResult(default));
            var context = GetWantActionContext(wantAction, Container);

            GivenCreateFacade()
                .When("Get compatible rules.", facade =>
                    facade.GetCompatibleRules(target, Collection, context))
                .ThenIsNotNull()
                .AndAreNotEqual(Collection)
                .And("Check result.", collection =>
                {
                    collection = collection.ToList();
                    Assert.AreEqual(1, collection.Count());
                    return collection.First();
                })
                .AndAreEqual(Collection[2]);
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(TC.Projects.Versioned), TestCategory(GetcuReoneTC.Unit)]
        [Description("Target with version 2.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TargetWithVersion2TestCase()
        {
            var wantAction = GetWantAction((Version2 v) => { });
            var target = GetFactRule((Version2 v) => new FactResult(default));
            var context = GetWantActionContext(wantAction, Container);

            GivenCreateFacade()
                .When("Get compatible rules.", facade =>
                    facade.GetCompatibleRules(target, Collection, context))
                .ThenIsNotNull()
                .AndAreNotEqual(Collection)
                .And("Check result.", collection =>
                {
                    collection = collection.ToList();
                    Assert.AreEqual(2, collection.Count());
                    return collection.Last();
                })
                .AndAreEqual(Collection[3]);
        }
    }
}
