using GetcuReone.FactFactory.BaseEntities.SpecialFacts;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Versioned.Interfaces;
using CommonHelper = GetcuReone.FactFactory.FactFactoryCommonHelper;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Base class for version facts.
    /// </summary>
    public abstract class VersionBase<TVersion> : SpecialFactBase, IVersionFact
    {
        /// <summary>
        /// Value version.
        /// </summary>
        public TVersion ValueVersion { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version">version</param>
        protected VersionBase(TVersion version)
        {
            ValueVersion = version;
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
        /// Extract <see cref="VersionBase{TVersion}.ValueVersion"/>.
        /// </summary>
        /// <param name="fact"></param>
        public static implicit operator TVersion(VersionBase<TVersion> fact)
        {
            return fact.ValueVersion;
        }
    }
}
