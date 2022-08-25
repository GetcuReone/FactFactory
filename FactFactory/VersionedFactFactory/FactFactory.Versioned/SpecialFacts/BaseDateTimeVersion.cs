using GetcuReone.FactFactory.Versioned.Interfaces;
using System;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="DateTime"/> based version facts.
    /// </summary>
    public abstract class BaseDateTimeVersion : BaseVersion<DateTime>
    {
        /// <inheritdoc/>
        protected BaseDateTimeVersion(DateTime version) : base(version)
        {
        }

        /// <inheritdoc/>
        public override int CompareTo(IVersionFact other)
        {
            switch (other)
            {
                case BaseVersion<DateTime> version:
                    return VersionValue.CompareTo(version.VersionValue);
                case FactBase<DateTime> version:
                    return VersionValue.CompareTo(version.Value);

                default:
                    throw CreateIncompatibilityVersionException(other);
            }
        }
    }
}
