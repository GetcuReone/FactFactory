using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Versioned.Helpers;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Contains information about a type of fact that cannot be calculated.
    /// </summary>
    public sealed class CannotDerived<TFact> : VersionedFactBase, ICannotDerivedFact
        where TFact : IFact
    {
        /// <inheritdoc/>
        public IFactType FactType { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public CannotDerived()
        {
            FactType = VersionedFactFactoryHelper.GetFactType<TFact>();
        }

        /// <inheritdoc/>
        public override IFactType GetFactType()
        {
            return VersionedFactFactoryHelper.GetFactType<CannotDerived<TFact>>();
        }

        /// <inheritdoc/>
        public bool IsFactContained<TFact1>(IFactContainer<TFact1> container)
            where TFact1 : IFact
        {
            return FactType.TryGetFact(container, out TFact1 _);
        }
    }
}
