﻿using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.SpecialFacts.RuntimeCondition
{
    /// <summary>
    /// Fact condition. Checks if a <typeparamref name="TFact"/> fact can be retrieved from a container.
    /// </summary>
    /// <typeparam name="TFact">The type of fact for which the condition is met.</typeparam>
    public class RContained<TFact> : RuntimeConditionFactBase<TFact>
        where TFact : IFact
    {
        /// <summary>
        /// Checks if a <typeparamref name="TFact"/> fact can be retrieved from a container.
        /// </summary>
        /// <inheritdoc/>
        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IFactRulesContext<TFactRule, TWantAction, TFactContainer> context)
        {
            return context.SingleEntity.CanExtractFact(GetFactType<TFact>(), factWork, context);
        }
    }
}