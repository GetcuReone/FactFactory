using System;
using FactFactory.Entities;
using FactFactory.Interfaces;

namespace FactFactory.Facts
{
    /// <summary>
    /// Start date for deriving of all facts
    /// </summary>
    public sealed class DateOfDeriveFact : FactBase<DateTime>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fact"></param>
        public DateOfDeriveFact(DateTime fact) : base(fact)
        {
        }

        /// <inheritdoc />
        public override IFactInfo GetFactInfo()
        {
            return new FactInfo<DateOfDeriveFact>();
        }
    }
}
