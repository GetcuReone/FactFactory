using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts.BuildCondition;
using System;

namespace FactFactoryTests.FactType.Env
{
    internal class NotContainedWithoutConstructor : BuildConditionFactBase, IBuildConditionFact
    {
        private NotContainedWithoutConstructor()
        {

        }

        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context, Func<IWantActionContext<TWantAction, TFactContainer>, IFactRuleCollection<TFactRule>> getCompatibleRules)
        {
            throw new NotImplementedException();
        }

        public bool IsFactContained(IFactContainer container)
        {
            throw new NotImplementedException();
        }
    }
}
