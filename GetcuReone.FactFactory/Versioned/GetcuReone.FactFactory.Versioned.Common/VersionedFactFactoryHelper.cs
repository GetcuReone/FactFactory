using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Helper for VersionedFactFactory.
    /// </summary>
    public static class VersionedFactFactoryHelper
    {
        /// <summary>
        /// Find parameter by <see cref="VersionedFactParametersCodes.Version"/>.
        /// </summary>
        /// <typeparam name="TFact">Type fact.</typeparam>
        /// <param name="fact">Fact.</param>
        /// <returns><see cref="IVersionFact"/> fact or null.</returns>
        public static IVersionFact? FindVersionParameter<TFact>(this TFact fact)
            where TFact : IFact
        {
            return fact.FindParameter(VersionedFactParametersCodes.Version)?.Value as IVersionFact;
        }

        /// <summary>
        /// Checks the value of the version of the <paramref name="fact"/>.
        /// </summary>
        /// <typeparam name="TFact">Type fact.</typeparam>
        /// <param name="fact">Fact.</param>
        /// <param name="version">Version fact.</param>
        /// <returns>Does the version match the fact of the <paramref name="version"/>?</returns>
        public static bool HasVersionParameter<TFact>(this TFact fact, IVersionFact version)
            where TFact : IFact
        {
            var factVersion = fact.FindVersionParameter();

            if (version == null)
                return factVersion == null;
            if (factVersion == null)
                return false;

            return version.CompareTo(factVersion) == 0;
        }

        /// <summary>
        /// Returns the first type of fact that implements the <see cref="IVersionFact"/> type.
        /// </summary>
        /// <param name="factTypes">List fact types.</param>
        /// <returns>First found fact type inherited from <see cref="IVersionFact"/></returns>
        public static IFactType? FirstVersionFactType(this IEnumerable<IFactType> factTypes)
        {
            return factTypes.FirstOrDefault(type => type.IsFactType<IVersionFact>());
        }

        /// <summary>
        /// Searches for the first occurrence of a version fact.
        /// </summary>
        /// <typeparam name="TFact">Type fact.</typeparam>
        /// <param name="facts">Fact list.</param>
        /// <param name="factType">Fact type of <see cref="IVersionFact"/>.</param>
        /// <param name="cache">Cache.</param>
        /// <returns><see cref="IVersionFact"/> fact or null.</returns>
        public static IVersionFact? FirstVersionFactByFactType<TFact>(this IEnumerable<TFact> facts, IFactType factType, IFactTypeCache cache)
            where TFact : IFact
        {
            return facts.FirstFactByFactType(factType, cache) as IVersionFact;
        }

        /// <summary>
        /// Compares rules based on version facts.
        /// </summary>
        /// <param name="firstRule">First rule.</param>
        /// <param name="secondRule">Second rule.</param>
        /// <param name="context">Context.</param>
        /// <returns>
        /// 1 - <paramref name="firstRule"/> rule is greater than the <paramref name="secondRule"/>,
        /// 0 - <paramref name="firstRule"/> rule is equal than the <paramref name="secondRule"/>,
        /// -1 - <paramref name="firstRule"/> rule is less than the <paramref name="secondRule"/>.
        /// </returns>
        public static int CompareByVersion(this IFactRule firstRule, IFactRule secondRule, IWantActionContext context)
        {
            var xVersionType = firstRule.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IVersionFact>());
            var yVersionType = secondRule.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IVersionFact>());

            if (xVersionType == null)
                return yVersionType == null ? 0 : 1;
            if (yVersionType == null)
                return -1;

            IVersionFact xVersion = context.Container.FirstVersionFactByFactType(xVersionType, context.Cache)!;
            IVersionFact yVersion = context.Container.FirstVersionFactByFactType(yVersionType, context.Cache)!;

            return xVersion.CompareTo(yVersion);
        }

        /// <summary>
        /// Compares facts by version facts in parameters.
        /// </summary>
        /// <param name="x">Fist fact.</param>
        /// <param name="y">Second fact.</param>
        /// <returns>
        /// 1 - <paramref name="x"/> fact is greater than the <paramref name="y"/>,
        /// 0 - <paramref name="x"/> fact is equal than the <paramref name="y"/>,
        /// -1 - <paramref name="x"/> fact is less than the <paramref name="y"/>.
        /// </returns>
        public static int CompareByVersionParameter(this IFact x, IFact y)
        {
            IVersionFact? xVersion = x.FindParameter(VersionedFactParametersCodes.Version)?.Value as IVersionFact;
            IVersionFact? yVersion = y.FindParameter(VersionedFactParametersCodes.Version)?.Value as IVersionFact;

            if (xVersion == null)
                return yVersion == null ? 0 : 1;
            if (yVersion == null)
                return -1;

            return xVersion.CompareTo(yVersion);
        }

        /// <summary>
        /// Adds a version fact to parameters.
        /// </summary>
        /// <param name="fact">Fact.</param>
        /// <param name="version">Verion fact.</param>
        /// <param name="parameterCache">Fact parameter cache.</param>
        /// <returns><paramref name="fact"/>.</returns>
        public static IFact AddVerionParameter(this IFact fact, IVersionFact version, IFactParameterCache parameterCache)
        {
            fact.AddParameter(parameterCache.GetOrCreate(VersionedFactParametersCodes.Version, version));

            return fact;
        }

        /// <summary>
        /// Checks if a fact contains a valid version.
        /// </summary>
        /// <typeparam name="TFact">Type fact.</typeparam>
        /// <param name="fact">Fact.</param>
        /// <param name="maxVersion">Max version (optional).</param>
        /// <returns>Whether the version of the fact is within the valid versions?</returns>
        public static bool IsRelevantFactByVersioned<TFact>(this TFact fact, IVersionFact? maxVersion)
            where TFact : IFact
        {
            if (maxVersion == null || !fact.IsCalculatedByRule())
                return true;

            var value = fact.FindParameter(VersionedFactParametersCodes.Version)?.Value;

            if (value == null)
                return false;
            if (value is IVersionFact factVersion)
                return maxVersion.CompareTo(factVersion) >= 0;

            return false;
        }
    }
}
