using GetcuReone.FactFactory.BaseEntities.SpecialFacts;
using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace FactFactory.VersionedTests.CommonFacts
{
    internal sealed class Condition_ContainedFact1 : ConditionFactBase<Fact1>
    {
        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
        {
            return context.Container.Contains<Fact1>();
        }
    }
}
