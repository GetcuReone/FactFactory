using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.SpecialFacts
{
    /// <summary>
    /// Contains information about a type of fact that cannot be calculated.
    /// </summary>
    public sealed class NoDerived<TFact> : FactBase<IFactType>, INoDerivedFact
        where TFact : IFact
    {
        /// <summary>
        /// Value fact.
        /// </summary>
        public override IFactType Value { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public NoDerived() : base(null)
        {
            Value = DefaultFactFactoryHelper.GetFactType<TFact>();
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
            return Value.TryGetFact(container, out TFact1 _);
        }
    }
}
