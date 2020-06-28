using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;

namespace GetcuReone.FactFactory.SpecialFacts
{
    /// <summary>
    /// Contains information about a type of fact that cannot be calculated.
    /// </summary>
    public sealed class NoDerived<TFact> : FactBase, INoDerivedFact
        where TFact : IFact
    {
        /// <inheritdoc/>
        public IFactType FactType { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public NoDerived()
        {
            FactType = DefaultFactFactoryHelper.GetFactType<TFact>();
        }

        /// <summary>
        /// Get fact type.
        /// </summary>
        /// <returns>Fact type.</returns>
        public override IFactType GetFactType()
        {
            return DefaultFactFactoryHelper.GetFactType<NoDerived<TFact>>();
        }

        /// <summary>
        /// Is the fact contained in the container.
        /// </summary>
        /// <typeparam name="TFact1"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public bool IsFactContained<TFact1>(IFactContainer<TFact1> container)
            where TFact1 : IFact
        {
            return FactType.TryGetFact(container, out TFact1 _);
        }
    }
}
