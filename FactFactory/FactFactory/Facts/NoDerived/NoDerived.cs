using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Contains information about a type of fact that cannot be calculated
    /// </summary>
    public sealed class NoDerived<TFact> : NoDerivedBase
        where TFact : IFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NoDerived() : base(FactFactoryHelper.GetFactType<TFact>())
        {
        }
    }
}
