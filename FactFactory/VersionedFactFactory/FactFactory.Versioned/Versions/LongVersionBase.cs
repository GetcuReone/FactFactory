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
                    return VersionValue.CompareTo(version.VersionValue);
                case VersionBase<long> version:
                    return VersionValue.CompareTo(version.VersionValue);
                case VersionBase<uint> version:
                    return VersionValue.CompareTo(version.VersionValue);
                case VersionBase<ulong> version:
                    return VersionValue.CompareTo(version.VersionValue);

                case FactBase<int> version:
                    return VersionValue.CompareTo(version.Value);
                case FactBase<long> version:
                    return VersionValue.CompareTo(version.Value);
                case FactBase<uint> version:
                    return VersionValue.CompareTo(version.Value);
                case FactBase<ulong> version:
                    return VersionValue.CompareTo(version.Value);

                default:
                    throw CreateIncompatibilityVersionException(other);
            }
        }
    }
}
