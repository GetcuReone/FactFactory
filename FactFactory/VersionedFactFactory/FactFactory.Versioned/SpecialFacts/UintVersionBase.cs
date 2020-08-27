using GetcuReone.FactFactory.Versioned.Interfaces;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="uint"/> based version facts.
    /// </summary>
    public abstract class UintVersionBase : VersionBase<uint>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version">version</param>
        protected UintVersionBase(uint version) : base(version)
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
