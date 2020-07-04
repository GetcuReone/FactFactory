using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Interfaces;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Base class for version facts.
    /// </summary>
    public abstract class VersionBase<TVersion> : VersionedFactBase<TVersion>, IVersionFact
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version">version</param>
        protected VersionBase(TVersion version) : base(version)
        {
        }

        /// <inheritdoc/>
        public abstract bool EqualVersion<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact;

        /// <inheritdoc/>
        public abstract bool IsLessThan<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact;

        /// <inheritdoc/>
        public abstract bool IsMoreThan<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact;

        /// <inheritdoc/>
        public bool IsFactContained<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return GetFactType().TryGetFact(container, out TFactBase _);
        }
    }
}
