using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.SpecialFacts;
using System.Collections.Generic;

namespace FactFactory.VersionedTests.CommonFacts
{
    internal sealed class BuildCondition_ContainedFact1 : BuildConditionFactBase<Fact1>
    {
        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
        {
            return context.Container.Contains<Fact1>();
        }
    }
}
