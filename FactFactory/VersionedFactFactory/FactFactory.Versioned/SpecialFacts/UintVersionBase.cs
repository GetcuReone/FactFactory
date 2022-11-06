using System;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <inheritdoc/>
    [Obsolete("Use BaseUintVersion (deprecated in 4.0.2)")]
    public abstract class UintVersionBase : BaseUintVersion
    {
        /// <inheritdoc/>
        protected UintVersionBase(uint version) : base(version)
        {
        }
    }
}
