using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.BaseEntities.SpecialFacts
{
    /// <summary>
    /// Is the fact <typeparamref name="TFact"/> contained in the container.
    /// </summary>
    /// <typeparam name="TFact"></typeparam>
    public abstract class ContainedFactBase<TFact> : ConditionFactBase<TFact>
        where TFact : IFact
    {
        /// <inheritdoc/>
        public override bool Condition<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            return true;
        }

        /// <inheritdoc/>
        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
        {
            return context.SingleEntity.CanExtractFact(GetFactType<TFact>(), factWork, context);
        }
    }
}
