using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using System;

namespace FactFactoryTests.FactType.Env
{
    internal class NotContainedWithoutConstructor : BaseBuildConditionFact, IBuildConditionFact
    {
        private NotContainedWithoutConstructor() { }

        public override bool Condition<TFactWork, TFactRule>(TFactWork factWork, IWantActionContext context, Func<IWantActionContext, IFactRuleCollection<TFactRule>> getCompatibleRules)
        {
            throw new NotImplementedException();
        }

        public bool IsFactContained(IFactContainer container)
        {
            throw new NotImplementedException();
        }
    }
}
