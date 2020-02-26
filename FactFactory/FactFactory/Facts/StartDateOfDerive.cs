using System;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Start date for deriving of all facts
    /// </summary>
    public sealed class StartDateOfDerive : FactBase<DateTime>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public StartDateOfDerive(DateTime value) : base(value)
        {
        }
    }
}
