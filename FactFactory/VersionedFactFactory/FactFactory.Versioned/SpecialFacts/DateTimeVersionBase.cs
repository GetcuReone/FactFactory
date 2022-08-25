using System;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <inheritdoc/>
    [Obsolete("Use BaseDateTimeVersion (deprecated in 4.0.2)")]
    public abstract class DateTimeVersionBase : BaseDateTimeVersion
    {
        /// <inheritdoc/>
        protected DateTimeVersionBase(DateTime version) : base(version)
        {
        }
    }
}
