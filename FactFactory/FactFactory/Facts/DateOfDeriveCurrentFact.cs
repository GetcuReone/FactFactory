using FactFactory.Entities;
using FactFactory.Interfaces;
using System;

namespace FactFactory.Facts
{
    /// <summary>
    /// Start date for deriving of current fact
    /// <para>
    /// Only available for request in the rules
    /// </para>
    /// </summary>
    public sealed class DateOfDeriveCurrentFact : FactBase<DateTime>
    {
        /// <inheritdoc />
        public DateOfDeriveCurrentFact(DateTime fact) : base(fact)
        {
        }

        /// <inheritdoc />
        public override IFactInfo GetFactInfo()
        {
            return new FactInfo<DateOfDeriveCurrentFact>();
        }
    }
}
