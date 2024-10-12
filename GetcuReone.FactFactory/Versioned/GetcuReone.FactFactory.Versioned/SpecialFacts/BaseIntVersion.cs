using GetcuReone.FactFactory.Versioned.Interfaces;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="int"/> based version facts.
    /// </summary>
    public abstract class BaseIntVersion : BaseVersion<int>
    {
        /// <inheritdoc/>
        protected BaseIntVersion(int version) : base(version) { }

        /// <inheritdoc/>
        public override int CompareTo(IVersionFact other)
        {
            switch (other)
            {
                case BaseVersion<int> version:
                    return VersionValue.CompareTo(version.VersionValue);
                case BaseVersion<long> version:
                    return VersionValue.CompareTo(version.VersionValue);
                case BaseVersion<uint> version:
                    return VersionValue.CompareTo(version.VersionValue);
                case BaseVersion<ulong> version:
                    return VersionValue.CompareTo(version.VersionValue);

                case BaseFact<int> version:
                    return VersionValue.CompareTo(version.Value);
                case BaseFact<long> version:
                    return VersionValue.CompareTo(version.Value);
                case BaseFact<uint> version:
                    return VersionValue.CompareTo(version.Value);
                case BaseFact<ulong> version:
                    return VersionValue.CompareTo(version.Value);

                default:
                    throw CreateIncompatibilityVersionException(other);
            }
        }
    }
}
