using System;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;

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

        /// <summary>
        /// Get fact type.
        /// </summary>
        /// <returns>fact type</returns>
        public override IFactType GetFactType()
        {
            return new FactType<StartDateOfDerive>();
        }
    }
}
