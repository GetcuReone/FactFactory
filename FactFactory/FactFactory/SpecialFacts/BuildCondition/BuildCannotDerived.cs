using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System;

namespace GetcuReone.FactFactory.SpecialFacts.BuildCondition
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
        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context, Func<IWantActionContext<TWantAction, TFactContainer>, IFactRuleCollection<TFactRule>> getCompatibleRules)
        {
            return !ConditionHelper.CanDeriveFact(
                this,
                GetFactType<TFact>(),
                factWork,
                getCompatibleRules(context),
                context);
        }
    }
}
