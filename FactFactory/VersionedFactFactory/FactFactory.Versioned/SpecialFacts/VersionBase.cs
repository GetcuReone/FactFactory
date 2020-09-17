using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.FactFactory.Versioned.Interfaces;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Base class for version facts.
    /// </summary>
    public abstract class VersionBase<TVersionValue> : SpecialFactBase, IVersionFact
    {
        /// <summary>
        /// Value version.
        /// </summary>
        public TVersionValue VersionValue { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version">version</param>
        protected VersionBase(TVersionValue version)
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

        /// <inheritdoc/>
        public abstract int CompareTo(IVersionFact other);

        /// <summary>
        /// Extract <see cref="VersionBase{TVersionValue}.VersionValue"/>.
        /// </summary>
        /// <param name="fact"></param>
        public static implicit operator TVersionValue(VersionBase<TVersionValue> fact)
        {
            return fact.VersionValue;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Version <{VersionValue}>";
        }
    }
}
