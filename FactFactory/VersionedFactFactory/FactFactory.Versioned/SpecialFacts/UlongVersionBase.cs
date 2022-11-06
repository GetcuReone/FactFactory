using System;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <inheritdoc/>
    [Obsolete("Use BaseUlongVersion (deprecated in 4.0.2)")]
    public abstract class UlongVersionBase : BaseUlongVersion
    {
        /// <inheritdoc/>
        protected UlongVersionBase(ulong version) : base(version)
        {
        }
    }
}
