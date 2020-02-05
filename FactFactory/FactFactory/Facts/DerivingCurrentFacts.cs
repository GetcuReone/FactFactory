using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.ObjectModel;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Current calculated facts
    /// </summary>
    public sealed class DerivingCurrentFacts : FactBase<ReadOnlyCollection<IFactType>>
    {
        /// <inheritdoc />
        public DerivingCurrentFacts(ReadOnlyCollection<IFactType> fact) : base(fact)
        {
        }

        /// <summary>
        /// Get fact type
        /// </summary>
        /// <returns>fact type</returns>
        public override IFactType GetFactType()
        {
            return new FactInfo<DerivingCurrentFacts>();
        }
    }
}
