using FactFactory.Entities;
using FactFactory.Interfaces;
using System.Collections.ObjectModel;

namespace FactFactory.Facts
{
    /// <summary>
    /// Current Calculated Facts
    /// </summary>
    public sealed class DerivingCurrentFactsFact : FactBase<ReadOnlyCollection<IFactInfo>>
    {
        /// <inheritdoc />
        public DerivingCurrentFactsFact(ReadOnlyCollection<IFactInfo> fact) : base(fact)
        {
        }

        /// <inheritdoc />
        public override IFactInfo GetFactInfo()
        {
            return new FactInfo<DerivingCurrentFactsFact>();
        }
    }
}
