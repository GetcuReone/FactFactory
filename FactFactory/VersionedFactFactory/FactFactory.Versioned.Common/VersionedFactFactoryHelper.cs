using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;
using CommonHelper = GetcuReone.FactFactory.FactFactoryCommonHelper;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Helper for <see cref="IVersionedFactFactory{TFactRule, TFactRuleCollection, TWantAction, TFactContainer}"/>.
    /// </summary>
    public static class VersionedFactFactoryHelper
    {
        /// <summary>
        /// Get version fact.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        public static IVersionFact GetVersionOrNull<TFact>(this TFact fact)
            where TFact : IFact
        {
            return fact.GetParameter(VersionedFactParametersCodes.Version)?.Value as IVersionFact;
        }

        /// <summary>
        /// The fact has a version.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="fact"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static bool HasVersion<TFact>(this TFact fact, IVersionFact version)
            where TFact : IFact
        {
            var factVersion = fact.GetVersionOrNull();

            if (version == null)
                return factVersion == null;
            if (factVersion == null)
                return false;

            return version.CompareTo(factVersion) == 0;
        }

        /// <summary>
        /// Return the fact type of a version.
        /// </summary>
        /// <param name="factTypes"></param>
        /// <returns></returns>
        public static IFactType GetVersionFactType(this IEnumerable<IFactType> factTypes)
        {
            return factTypes.FirstOrDefault(type => type.IsFactType<IVersionFact>());
        }

        /// <summary>
        /// Get version fact by type.
        /// </summary>
        /// <param name="facts"></param>
        /// <param name="factTypeVersion"></param>
        /// <returns></returns>
        public static IVersionFact GetVersionByType(this IEnumerable<IFact> facts, IFactType factTypeVersion)
        {
            var versionFact = factTypeVersion.GetFacts(facts).FirstOrDefault();
            if (versionFact == null)
                throw CommonHelper.CreateException(VersionedErrorCode.VersionNotFound, $"No version fact '{factTypeVersion.FactName}' found");

            return versionFact as IVersionFact;
        }
    }
}
