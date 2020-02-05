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

        /// <inheritdoc />
        public override IFactType GetFactType()
        {
            return new FactInfo<DerivingCurrentFacts>();
        }
    }
}
