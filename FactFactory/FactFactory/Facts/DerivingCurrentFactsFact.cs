using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.ObjectModel;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Current Calculated Facts
    /// </summary>
    public sealed class DerivingCurrentFactsFact : FactBase<ReadOnlyCollection<IFactType>>
    {
        /// <inheritdoc />
        public DerivingCurrentFactsFact(ReadOnlyCollection<IFactType> fact) : base(fact)
        {
        }

        /// <inheritdoc />
        public override IFactType GeTFactType()
        {
            return new FactInfo<DerivingCurrentFactsFact>();
        }
    }
}
