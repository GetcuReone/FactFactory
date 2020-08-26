using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

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
        /// The first version fact of the same type.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="facts">Fact list.</param>
        /// <param name="factType">Fact type of version.</param>
        /// <param name="cache">Cache.</param>
        /// <returns>Version or null.</returns>
        public static IVersionFact FirstVersionByFactType<TFact>(this IEnumerable<TFact> facts, IFactType factType, IFactTypeCache cache)
            where TFact : IFact
        {
            return facts.FirstFactByFactType(factType, cache) as IVersionFact;
        }

        /// <summary>
        /// Compare fact rules by version.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int CompareByVersion<TFactRule, TWantAction, TFactContainer>(this TFactRule x, TFactRule y, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var xVersionType = x.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IVersionFact>());
            var yVersionType = y.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IVersionFact>());

            if (xVersionType == null)
                return yVersionType == null ? 0 : 1;
            if (yVersionType == null)
                return -1;

            IVersionFact xVersion = context.Container.FirstVersionByFactType(xVersionType, context.Cache);
            IVersionFact yVersion = context.Container.FirstVersionByFactType(yVersionType, context.Cache);

            return xVersion.CompareTo(yVersion);
        }
    }
}
