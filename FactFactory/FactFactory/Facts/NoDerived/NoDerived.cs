using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Contains information about a type of fact that cannot be calculated
    /// </summary>
    public sealed class NoDerived<TFact> : FactBase<IFactType>, INoDerivedFact
        where TFact : IFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NoDerived() : base(FactFactoryHelper.GetFactType<TFact>())
        {
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
            return Value.ContainsContainer(container);
        }
    }
}
