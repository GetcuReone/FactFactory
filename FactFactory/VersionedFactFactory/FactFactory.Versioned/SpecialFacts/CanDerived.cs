using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Versioned.Helpers;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Contains information about a type of fact that can be derived.
    /// </summary>
    /// <typeparam name="TFact"></typeparam>
    public class CanDerived<TFact> : VersionedFactBase, ICanDerivedFact
        where TFact : IFact
    {
        /// <inheritdoc/>
        public IFactType FactType { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public CanDerived()
        {
            FactType = VersionedFactFactoryHelper.GetFactType<TFact>();
        }

        /// <inheritdoc/>
        public override IFactType GetFactType()
        {
            return VersionedFactFactoryHelper.GetFactType<CanDerived<TFact>>();
        }

        /// <inheritdoc/>
        /// <remarks>
        /// For the current fact, there are additional actions built into the fact factory.
        /// </remarks>
        public bool Condition<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return IsFactContained<TFactBase, TFactWork, TWantAction, TFactContainer>(factWork, wantAction, container);
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
