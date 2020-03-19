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

        /// <summary>
        /// True - the version of the current fact is equal <paramref name="versionFact"/>.
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        public abstract bool EqualVersion<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact;

        /// <summary>
        /// True - the version of the current fact is less than <paramref name="versionFact"/>.
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        public abstract bool IsLessThan<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact;

        /// <summary>
        /// True - the version of the current fact is more than <paramref name="versionFact"/>.
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        public abstract bool IsMoreThan<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact;

        /// <summary>
        /// Is the fact contained in the container.
        /// </summary>
        /// <typeparam name="TFact1"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public bool IsFactContained<TFact1>(IFactContainer<TFact1> container)
            where TFact1 : IFact
        {
            return GetFactType().TryGetFact(container, out TFact1 _);
        }
    }
}
