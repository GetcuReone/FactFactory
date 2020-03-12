using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Default
{
    /// <summary>
    /// Contains information about a type of fact that cannot be calculated
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
            Value = GetFactType();
        }

        /// <summary>
        /// Get fact type.
        /// </summary>
        /// <returns>fact type</returns>
        public override IFactType GetFactType()
        {
            return new FactType<NoDerived<TFact>>();
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
