using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class FbCondition_ContainedOtherFact : BaseBuildConditionFact<OtherFact>
    {
        public override bool Condition(
            IFactWork factWork,
            IWantActionContext context,
            Func<IWantActionContext, IFactRuleCollection> getCompatibleRules)
        {
            return context.Container.Contains<OtherFact>();
        }
    }
}
