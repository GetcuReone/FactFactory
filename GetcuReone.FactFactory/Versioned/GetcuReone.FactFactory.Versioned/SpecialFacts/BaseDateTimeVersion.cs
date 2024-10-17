using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="DateTime"/> based version facts.
    /// </summary>
    public abstract class BaseDateTimeVersion : BaseVersion<DateTime>
    {
        /// <inheritdoc/>
        protected BaseDateTimeVersion(DateTime version) : base(version) { }

        /// <inheritdoc/>
        public override int CompareTo([AllowNull] IVersionFact other)
        {
            return other switch
            {
                BaseVersion<DateTime> version => VersionValue.CompareTo(version.VersionValue),
                BaseFact<DateTime> version => VersionValue.CompareTo(version.Value),
                _ => throw CreateIncompatibilityVersionException(other),
            };
        }
    }
}
