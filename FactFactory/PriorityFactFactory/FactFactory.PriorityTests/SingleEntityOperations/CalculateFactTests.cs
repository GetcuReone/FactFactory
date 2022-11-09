using FactFactory.Priority.Interfaces;
using FactFactory.PriorityTests.CommonFacts;
using FactFactory.PriorityTests.SingleEntityOperations.Env;
using FactFactory.TestsCommon;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Priority;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FactFactory.PriorityTests.SingleEntityOperations
{
    [TestClass]
    public sealed class CalculateFactTests : PrioritySingleEntityOperationsTestBase
    {
        public FactRule Rule { get; set; }
        public NodeByFactRuleInfo<FactRule> NodeInfo { get; set; }
        public NodeByFactRule<FactRule> Node { get; set; }
        public IWantActionContext<WantAction> Context { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Rule = GetFactRule((Priority1 p, Fact1 f) => new FactResult(f.Value + p));
            NodeInfo = new NodeByFactRuleInfo<FactRule>
            {
                BuildFailedConditions = new List<IBuildConditionFact>(),
                Rule = Rule,
                BuildSuccessConditions = new List<IBuildConditionFact>(),
                RuntimeConditions = new List<IRuntimeConditionFact>(),
            };
            Node = new NodeByFactRule<FactRule>
            {
                Childs = new List<NodeByFactRule<FactRule>>(),
                Info = NodeInfo,
                Parent = null,
            };
            Context = GetWantActionContext(
                GetWantAction((FactResult result) => { }),
                new FactContainer 
                {
                    new Priority1(),
                    new Priority2(),
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Fact), TestCategory(TC.Projects.Priority), TestCategory(GetcuReoneTC.Unit)]
        [Description("Calculate fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void CalculateFactTestCase()
        {
            var fact = new Fact1(1);
            const long expectedValue = 2;

            GivenCreateFacade()
                .And("Add fact1.", _ =>
                    Context.Container.Add(fact))
                .When("Check TryCalculateFact method.", facade =>
                    (BaseFact<long>)facade.CalculateFact(Node, Context))
                .ThenIsNotNull()
                .AndIsTrue(fact => fact is FactResult, 
                    errorMessage: "result must have type FactResult.")
                .AndAreEqual(fact => fact.Value, expectedValue)
                .AndIsTrue(fact => fact.FindPriorityParameter() != null)
                .AndIsTrue(fact => fact.FindPriorityParameter() is IPriorityFact)
                .Run();
        }
    }
}
