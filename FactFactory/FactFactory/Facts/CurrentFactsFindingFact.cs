using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Current fact finding information
    /// <para>
    /// Only available for request in the rules
    /// </para>
    /// </summary>
    public sealed class CurrentFactsFindingFact : FactBase<IReadOnlyCollection<IFactType>>
    {
        /// <inheritdoc />
        public CurrentFactsFindingFact(IReadOnlyCollection<IFactType> fact) : base(fact)
        {
        }

        /// <inheritdoc />
        public override IFactType GetFactType()
        {
            return new FactInfo<CurrentFactsFindingFact>();
        }
    }
}
