using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CommonErrorCode = GetcuReone.FactFactory.Constants.ErrorCode;
using CommonHelper = GetcuReone.FactFactory.FactFactoryCommonHelper;

namespace GetcuReone.FactFactory.Versioned.Helpers
{
    /// <summary>
    /// Helper for <see cref="VersionedFactFactoryBase{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
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

        internal static IVersionFact GetVersionFact(this IEnumerable<IFact> facts, IFactType factTypeVersion)
        {
            var versionFact = factTypeVersion.GetFacts(facts).FirstOrDefault();
            if (versionFact == null)
                throw CommonHelper.CreateException(ErrorCode.VersionNotFound, $"No version fact '{factTypeVersion.FactName}' found");

            return versionFact as IVersionFact;
        }

        internal static IFactType SingleOrNullFactVersion(this IEnumerable<IFactType> factTypes)
        {
            List<IFactType> typeFacts = factTypes.Where(factType => factType.IsFactType<IVersionFact>()).ToList();

            if (typeFacts.IsNullOrEmpty())
                return null;
            else if (typeFacts.Count > 1)
                throw CommonHelper.CreateException(ErrorCode.OnlyOneVersionFact, $"You cannot specify more than one version fact\nInputFactTypes: ({string.Join(", ", factTypes)})");

            return typeFacts[0];
        }

        internal static IFact GetRightFactByVersionType(this IFactContainer container, IFactType searchFactType, IFactType versionType)
        {
            if (versionType != null)
            {
                IVersionFact version = GetVersionFact(container, versionType);
                return container.GetRightFactByVersion(searchFactType, version);
            }
            else
                return container.GetRightFactByVersion(searchFactType, null);
        }

        internal static IFact GetRightFactByVersion(this IFactContainer container, IFactType searchFactType, IVersionFact version)
        {
            if (searchFactType.IsFactType<ISpecialFact>())
                return searchFactType.GetFacts(container).FirstOrDefault();
            else
            {
                List<IVersionedFact> facts = container
                    .Where(fact => 
                        fact.GetFactType().EqualsFactType(searchFactType))
                    .Select(fact => (IVersionedFact)fact)
                    .ToList();

                if (facts.Count == 0)
                    return null;

                // List of facts not calculated using a rule.
                List<IVersionedFact> factsCalculatedNotByRule = facts.Where(fact => !fact.CalculatedByRule).ToList();

                if (factsCalculatedNotByRule.Count != 0)
                    return ChooseFactByVersion(factsCalculatedNotByRule, version) ?? factsCalculatedNotByRule.First();
                else
                    return ChooseFactByVersion(facts, version);
            }
        }

        private static IVersionedFact ChooseFactByVersion(List<IVersionedFact> facts, IVersionFact version)
        {
            if (version == null)
            {
                var defaultMaxFact = facts.FirstOrDefault(f => f.Version == null);

                if (defaultMaxFact != null)
                    return defaultMaxFact;

                foreach (var fact in facts)
                {
                    if (facts.All(f => fact.Version.CompareTo(f.Version) > 0 || fact.Equals(f)))
                        return fact;
                }
            }
            else
            {
                List<IVersionedFact> scopeSearch = new List<IVersionedFact>();

                foreach (var fact in facts)
                {
                    if (fact.Version != null && fact.Version.CompareTo(version) <= 0)
                        scopeSearch.Add(fact);
                }

                foreach (var fact in scopeSearch)
                {
                    if (scopeSearch.All(f => fact.Version.CompareTo(f.Version) > 0 || fact.Equals(f)))
                        return fact;
                }
            }

            return null;
        }
    }
}
