using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Versioned.Interfaces
{
    /// <summary>
    /// Fact containing version information
    /// </summary>
    public interface IVersionFact : IVersionedFact
    {
        /// <summary>
        /// True - the version of the current fact is less than <paramref name="versionFact"/>
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        bool IsLessThan<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact;

        /// <summary>
        /// True - the version of the current fact is more than <paramref name="versionFact"/>
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        bool IsMoreThan<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact;
    }
}
