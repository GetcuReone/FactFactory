using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;

namespace GetcuReone.FactFactory.BaseEntities.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="IConditionFact"/>.
    /// </summary>
    public abstract class ConditionFactBase : SpecialFactBase, IConditionFact
    {
        private IFactType _selfFactType;
        /// <inheritdoc/>
        public virtual IFactType FactType { get; protected set; }

        /// <inheritdoc/>
        public abstract bool Condition<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <inheritdoc/>
        public override IFactType GetFactType()
        {
            return _selfFactType ?? (_selfFactType = base.GetFactType());
        }
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
        public override bool IsFactContained<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            return !FactType.GetFacts(container).IsNullOrEmpty();
        }
    }
}
