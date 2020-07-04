using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Versioned.Helpers;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Information about a fact that is not contained in the container at the time of the function call <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>.
    /// </summary>
    public sealed class NotContained<TFact> : VersionedFactBase, INotContainedFact
        where TFact : IFact
    {
        /// <inheritdoc/>
        public IFactType FactType { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public NotContained() : base(null)
        {
            FactType = VersionedFactFactoryHelper.GetFactType<TFact>();
        }

        /// <inheritdoc/>
        public override IFactType GetFactType()
        {
            return VersionedFactFactoryHelper.GetFactType<NotContained<TFact>>();
        }

        /// <inheritdoc/>
        public bool Condition<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return !IsFactContained<TFactBase, TFactWork, TWantAction, TFactContainer>(factWork, wantAction, container);
        }

        /// <inheritdoc/>
        public bool IsFactContained<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return !FactType.GetFacts(container).IsNullOrEmpty();
        }
    }
}
