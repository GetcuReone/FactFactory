﻿using System.Diagnostics.CodeAnalysis;
using GetcuReone.FactFactory.Versioned.Interfaces;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="ulong"/> based version facts.
    /// </summary>
    public abstract class BaseUlongVersion : BaseVersion<ulong>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version">version</param>
        protected BaseUlongVersion(ulong version) : base(version) { }

        /// <inheritdoc/>
        public override int CompareTo([AllowNull] IVersionFact other)
        {
            return other switch
            {
                BaseVersion<int> version => VersionValue.CompareTo(version.VersionValue),
                BaseVersion<long> version => VersionValue.CompareTo(version.VersionValue),
                BaseVersion<uint> version => VersionValue.CompareTo(version.VersionValue),
                BaseVersion<ulong> version => VersionValue.CompareTo(version.VersionValue),
                BaseFact<int> version => VersionValue.CompareTo(version.Value),
                BaseFact<long> version => VersionValue.CompareTo(version.Value),
                BaseFact<uint> version => VersionValue.CompareTo(version.Value),
                BaseFact<ulong> version => VersionValue.CompareTo(version.Value),
                _ => throw CreateIncompatibilityVersionException(other),
            };
        }
    }
}
