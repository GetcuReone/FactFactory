using System;

namespace GetcuReone.FactFactory.Facts
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
    }
}
