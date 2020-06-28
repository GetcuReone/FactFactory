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
        public virtual bool IsFactContained<TFact1>(IFactContainer<TFact1> container)
            where TFact1 : IFact
        {
            return FactType.TryGetFact(container, out TFact1 _);
        }
    }
}
