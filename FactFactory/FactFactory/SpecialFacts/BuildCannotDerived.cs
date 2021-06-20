using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.SpecialFacts
{
    /// <summary>
    /// A fact condition that tests whether a tree cannot be built for the <typeparamref name="TFact"/> fact at the tree building stage.
    /// </summary>
    /// <typeparam name="TFact">The type of fact for which the condition is met.</typeparam>
    public class BuildCannotDerived<TFact> : BuildConditionFactBase<TFact>
        where TFact : IFact
    {
        /// <summary>
        /// Checks if a tree cannot be built for the <typeparamref name="TFact"/> fact.
        /// </summary>
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
