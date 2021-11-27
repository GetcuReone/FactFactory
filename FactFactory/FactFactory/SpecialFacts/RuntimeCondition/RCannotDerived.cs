using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.SpecialFacts.RuntimeCondition
{
    /// <summary>
    /// Fact condition that checks if a tree can be built for the fact <typeparamref name = "TFact" />.
    /// </summary>
    /// <typeparam name="TFact">The type of fact for which the condition is met.</typeparam>
    public class RCannotDerived<TFact> : RuntimeConditionFactBase<TFact>
        where TFact : IFact
    {
        /// <summary>
        /// Checks if a <typeparamref name="TFact"/> fact can be retrieved from a container.
        /// </summary>
        /// <inheritdoc/>
        public override bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IFactRulesContext<TFactRule, TWantAction, TFactContainer> context)
        {
            return !ConditionHelper.CanDeriveFact(
                this,
                GetFactType<TFact>(),
                factWork,
                context);
        }
    }
}
