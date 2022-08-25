using System;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <inheritdoc/>
    [Obsolete("Use BaseVersion (deprecated in 4.0.2)")]
    public abstract class VersionBase<TVersionValue> : BaseVersion<TVersionValue>
    {
        /// <inheritdoc/>
        protected VersionBase(TVersionValue version) : base(version)
        {
        }
    }
}
