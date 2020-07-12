using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;

namespace GetcuReone.FactFactory.Versioned.Interfaces
{
    /// <summary>
    /// Fact containing version information.
    /// </summary>
    public interface IVersionFact : ISpecialFact
    {
        /// <summary>
        /// True - the version of the current fact is less than <paramref name="versionFact"/>.
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        bool IsLessThan<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact;

        /// <summary>
        /// True - the version of the current fact is more than <paramref name="versionFact"/>.
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        bool IsMoreThan<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact;

        /// <summary>
        /// True - the version of the current fact is equal <paramref name="versionFact"/>.
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        bool EqualVersion<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact;
    }
}
