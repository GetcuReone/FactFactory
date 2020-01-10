using FactFactory.Entities;
using FactFactory.Interfaces;
using System.Collections.Generic;

namespace FactFactory.Facts
{
    /// <summary>
    /// Current fact finding information
    /// <para>
    /// Only available for request in the rules
    /// </para>
    /// </summary>
    public sealed class CurrentFactsFindingFact : FactBase<IReadOnlyCollection<IFactInfo>>
    {
        /// <inheritdoc />
        public CurrentFactsFindingFact(IReadOnlyCollection<IFactInfo> fact) : base(fact)
        {
        }

        /// <inheritdoc />
        public override IFactInfo GetFactInfo()
        {
            return new FactInfo<CurrentFactsFindingFact>();
        }
    }
}
