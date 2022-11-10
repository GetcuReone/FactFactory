using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class BuildCondition_ContainedOtherFact : BaseBuildConditionFact<OtherFact>
    {
        public override bool Condition<TFactWork>(
            TFactWork factWork, IWantActionContext context,
            Func<IWantActionContext, IFactRuleCollection> getCompatibleRules)
        {
            return context.Container.Contains<OtherFact>();
        }
    }
}
