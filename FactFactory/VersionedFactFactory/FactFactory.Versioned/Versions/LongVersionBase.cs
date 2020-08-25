using GetcuReone.FactFactory.Versioned.Interfaces;
using GetcuReone.FactFactory.Versioned.SpecialFacts;

namespace GetcuReone.FactFactory.Versioned.Versions
{
    /// <summary>
    /// Base class for <see cref="long"/> based version facts.
    /// </summary>
    public abstract class LongVersionBase : VersionBase<long>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version">version</param>
        protected LongVersionBase(long version) : base(version)
        {
        }

        /// <inheritdoc/>
        public override int CompareTo(IVersionFact other)
        {
            switch (other)
            {
                case VersionBase<int> version:
                    return ValueVersion.CompareTo(version);
                case VersionBase<long> version:
                    return ValueVersion.CompareTo(version);
                case VersionBase<uint> version:
                    return ValueVersion.CompareTo(version);
                case VersionBase<ulong> version:
                    return ValueVersion.CompareTo(version);

                case FactBase<int> version:
                    return ValueVersion.CompareTo(version);
                case FactBase<long> version:
                    return ValueVersion.CompareTo(version);
                case FactBase<uint> version:
                    return ValueVersion.CompareTo(version);
                case FactBase<ulong> version:
                    return ValueVersion.CompareTo(version);

                default:
                    throw CreateIncompatibilityVersionException(other);
            }
        }
    }
}
