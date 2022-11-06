using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.FactFactory.Versioned.Interfaces;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Base class for version facts.
    /// </summary>
    public abstract class BaseVersion<TVersionValue> : BaseSpecialFact, IVersionFact
    {
        /// <summary>
        /// Value version.
        /// </summary>
        public TVersionValue VersionValue { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version">Value version.</param>
        protected BaseVersion(TVersionValue version)
        {
            VersionValue = version;
        }

        /// <summary>
        /// Error creating version incompatibility.
        /// </summary>
        /// <param name="versionedFact"></param>
        /// <returns></returns>
        protected virtual FactFactoryException CreateIncompatibilityVersionException(IVersionFact versionedFact)
        {
            return CommonHelper.CreateException(ErrorCode.InvalidFactType, $"Unable to compare versions {GetFactType().FactName} and {versionedFact.GetFactType().FactName}.");
        }

        /// <summary>
        /// Compares the version fact to the <paramref name="other"/>.
        /// </summary>
        /// <param name="other">Version fact for comparison</param>
        /// <returns>1 - more, 0 - equal, -1 less.</returns>
        public abstract int CompareTo(IVersionFact other);

        /// <summary>
        /// Extracts <see cref="BaseVersion{TVersionValue}.VersionValue"/>.
        /// </summary>
        /// <param name="fact">Version value.</param>
        public static implicit operator TVersionValue(BaseVersion<TVersionValue> fact)
        {
            return fact.VersionValue;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Version <{VersionValue}>";
        }

        /// <inheritdoc/>
        public override bool EqualsInfo(ISpecialFact specialFact)
        {
            return specialFact != null
                && specialFact is IVersionFact versionedFact
                && CompareTo(versionedFact) == 0;
        }
    }
}
