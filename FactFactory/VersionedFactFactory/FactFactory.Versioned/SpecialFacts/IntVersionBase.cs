using System;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <inheritdoc/>
    [Obsolete("Use BaseIntVersion (deprecated in 4.0.2)")]
    public abstract class IntVersionBase : BaseIntVersion
    {
        /// <inheritdoc/>
        protected IntVersionBase(int version) : base(version)
        {
        }
    }
}
