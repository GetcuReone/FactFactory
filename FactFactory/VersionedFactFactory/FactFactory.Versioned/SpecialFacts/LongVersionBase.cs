using System;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <inheritdoc/>
    [Obsolete("Use BaseLongVersion (deprecated in 4.0.2)")]
    public abstract class LongVersionBase : BaseLongVersion
    {
        /// <inheritdoc/>
        protected LongVersionBase(long version) : base(version)
        {
        }
    }
}
