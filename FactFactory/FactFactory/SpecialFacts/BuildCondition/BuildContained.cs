using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System;

namespace GetcuReone.FactFactory.SpecialFacts.BuildCondition
{
    /// <summary>
    /// Fact condition. Checks if a <typeparamref name="TFact"/> fact can be retrieved from a container at the tree building stage.
    /// </summary>
    /// <typeparam name="TFact">The type of fact for which the condition is met.</typeparam>
    public class BuildContained<TFact> : BuildConditionFactBase<TFact>
        where TFact : IFact
    {
        /// <summary>
        /// Checks if a <typeparamref name="TFact"/> fact can be retrieved from a container.
        /// </summary>
        /// <inheritdoc/>
        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context, Func<IWantActionContext<TWantAction, TFactContainer>, IFactRuleCollection<TFactRule>> getCompatibleRules)
        {
            return context.SingleEntity.CanExtractFact(GetFactType<TFact>(), factWork, context);
        }
    }
}
