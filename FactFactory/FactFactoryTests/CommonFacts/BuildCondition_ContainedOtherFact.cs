using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.SpecialFacts;
using System.Collections.Generic;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class BuildCondition_ContainedOtherFact : BuildConditionFactBase<OtherFact>
    {
        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
        {
            return context.Container.Contains<OtherFact>();
        }
    }
}
