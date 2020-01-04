using System;

namespace FactFactory.Entities
{
    /// <summary>
    /// Start date for fact finding
    /// </summary>
    public sealed class DateOfDerive : FactBase<DateTime>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fact"></param>
        public DateOfDerive(DateTime fact) : base(fact)
        {
        }
    }
}
