using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.BaseEntities.SpecialFacts
{
    /// <summary>
    /// Contains information about a type of fact that cannot be derived.
    /// </summary>
    /// <typeparam name="TFact"></typeparam>
    public abstract class CannotDerivedFactBase<TFact> : ConditionFactBase<TFact>
        where TFact : IFact
    {
        /// <inheritdoc/>
        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
        {
            return !ConditionHelper.CanDeriveFact(
                this,
                GetFactType<TFact>(),
                factWork,
                compatibleRules,
                context);
        }
    }
}
