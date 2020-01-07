using FactFactory.Entities;
using FactFactory.Interfaces;

namespace FactFactory.Facts
{
    /// <summary>
    /// Current fact finding information
    /// <para>
    /// Only available for request in the rules
    /// </para>
    /// </summary>
    public sealed class CurrentFactInfoFindingFact : FactBase<IFactInfo>
    {
        /// <inheritdoc />
        public CurrentFactInfoFindingFact(IFactInfo fact) : base(fact)
        {
        }

        /// <inheritdoc />
        public override IFactInfo GetFactInfo()
        {
            return new FactInfo<CurrentFactInfoFindingFact>();
        }
    }
}
