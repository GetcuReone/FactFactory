using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations
{
    internal static class VersionedSingleEntityOperationsHelper
    {
        internal static IVersionFact GetMinVersion(params IVersionFact[] versionedFacts)
        {
            return versionedFacts
                .OrderBy(version => version, Comparer<IVersionFact>.Create(Compare))
                .First();
        }

        private static int Compare(IVersionFact first, IVersionFact second)
        {
            if (first == null)
                return second == null ? 0 : 1;
            else if (second == null)
                return first == null ? 0 : -1;

            return first.CompareTo(second);
        }

        internal static IVersionFact GetVersionFact<TWantAction, TFactContainer>(this IEnumerable<IFactType> factTypes, IWantActionContext<TWantAction, TFactContainer> context)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            IFactType versionType = factTypes.SingleOrDefault(type => type.IsFactType<IVersionFact>());
            return versionType != null
                ? (IVersionFact)context.Container.First(fact => context.Cache.GetFactType(fact).EqualsFactType(versionType))
                : null;
        }

        internal static bool CompatibleRule<TFactRule, TWantAction, TFactContainer>(this TFactRule factRule, IVersionFact maxVersion, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var version = factRule.InputFactTypes.GetVersionFact(context);

            if (version == null)
                return false;

            return maxVersion.CompareTo(version) >= 0;
        }

        internal static IEnumerable<IFact> GetFactsFromContainerByFactType<TWantAction, TFactContainer>(this IWantActionContext<TWantAction, TFactContainer> context, IFactType factType)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return context.Container.Where(fact => context.Cache.GetFactType(fact).EqualsFactType(factType));
        }

        /// <summary>
        /// Compatible with version.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="fact"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        internal static bool IsCompatibleWithVersion<TFact>(this TFact fact, IVersionFact version)
            where TFact : IFact
        {
            if (version == null || !fact.IsCalculatedByRule())
                return true;
            if (fact.Parameters.IsNullOrEmpty())
                return false;

            var value = fact.Parameters.FirstOrDefault(p => p.Code == VersionedFactParametersCodes.Version)?.Value;

            if (value == null)
                return false;
            if (value is IVersionFact factVersion)
                return version.CompareTo(factVersion) >= 0;

            return false;
        }
    }
}
