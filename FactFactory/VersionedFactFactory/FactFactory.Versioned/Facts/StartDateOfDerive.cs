using System;

namespace GetcuReone.FactFactory.Versioned.Facts
{
    /// <summary>
    /// Start date for deriving of all facts
    /// </summary>
    public sealed class StartDateOfDerive : VersionedFactBase<DateTime>
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
