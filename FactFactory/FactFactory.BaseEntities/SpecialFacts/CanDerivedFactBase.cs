using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;

namespace GetcuReone.FactFactory.BaseEntities.SpecialFacts
{
    /// <summary>
    /// Contains information about a type of fact that can be derived.
    /// </summary>
    /// <typeparam name="TFact"></typeparam>
    public abstract class CanDerivedFactBase<TFact> : ConditionFactBase<TFact>, ICanDerivedFact
        where TFact : IFact
    {
        /// <inheritdoc/>
        public override bool Condition<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            return IsFactContained(factWork, wantAction, container);
        }
    }
}
