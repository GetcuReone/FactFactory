using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.BaseEntities.SpecialFacts
{
    /// <summary>
    /// Is the fact <typeparamref name="TFact"/> not contained in the container.
    /// </summary>
    /// <typeparam name="TFact"></typeparam>
    public abstract class NotContainedFactBase<TFact> : ConditionFactBase<TFact>
        where TFact : IFact
    {
        /// <inheritdoc/>
        public override bool Condition<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            return !IsFactContained<TFactBase, TFactWork, TWantAction, TFactContainer>(factWork, wantAction, container);
        }
    }
}
