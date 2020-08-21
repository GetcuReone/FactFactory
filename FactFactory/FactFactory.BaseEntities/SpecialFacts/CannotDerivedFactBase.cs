using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.BaseEntities.SpecialFacts
{
    /// <summary>
    /// Contains information about a type of fact that cannot be derived.
    /// </summary>
    /// <typeparam name="TFact"></typeparam>
    public abstract class CannotDerivedFactBase<TFact> : ConditionFactBase<TFact>, ICannotDerivedFact
        where TFact : IFact
    {
        /// <inheritdoc/>
        public override bool Condition<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            return !IsFactContained(factWork, wantAction, container);
        }

        /// <inheritdoc/>
        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
        {
            return !ConditionHelper.CanDeriveFact(
                GetFactType<TFact>(),
                factWork,
                compatibleRules,
                context);
        }
    }
}
