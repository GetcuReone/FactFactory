using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;

namespace GetcuReone.FactFactory.BaseEntities.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="IConditionFact"/>.
    /// </summary>
    public abstract class ConditionFactBase : SpecialFactBase, IConditionFact
    {
        /// <inheritdoc/>
        public virtual IFactType FactType { get; protected set; }

        /// <inheritdoc/>
        public abstract bool Condition<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>;
    }

    /// <inheritdoc/>
    /// <typeparam name="TFact">Type for <see cref="IConditionFact.FactType"/>.</typeparam>
    public abstract class ConditionFactBase<TFact> : ConditionFactBase, IFactTypeCreation
        where TFact : IFact
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ConditionFactBase()
        {
            FactType = GetFactType<TFact>();
        }

        /// <inheritdoc/>
        public virtual IFactType GetFactType<TFact1>() where TFact1 : IFact
        {
            return new FactType<TFact1>();
        }

        /// <inheritdoc/>
        public override bool IsFactContained<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            return !FactType.GetFacts(container).IsNullOrEmpty();
        }
    }
}
