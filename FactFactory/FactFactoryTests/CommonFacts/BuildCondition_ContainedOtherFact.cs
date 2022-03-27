using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class BuildCondition_ContainedOtherFact : BuildConditionFactBase<OtherFact>
    {
        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context, Func<IWantActionContext<TWantAction, TFactContainer>, IFactRuleCollection<TFactRule>> getCompatibleRules)
        {
            return context.Container.Contains<OtherFact>();
        }
    }
}
