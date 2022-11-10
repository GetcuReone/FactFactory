using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using System;

namespace FactFactory.VersionedTests.CommonFacts
{
    internal sealed class BuildCondition_ContainedFact1 : BaseBuildConditionFact<Fact1>
    {
        public override bool Condition(
            IFactWork factWork,
            IWantActionContext context,
            Func<IWantActionContext, IFactRuleCollection> getCompatibleRules)
        {
            return context.Container.Contains<Fact1>();
        }
    }
}
