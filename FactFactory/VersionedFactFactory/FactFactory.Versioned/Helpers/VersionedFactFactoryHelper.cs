using GetcuReone.FactFactory.Helpers;
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
    /// Helper for <see cref="VersionedFactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
    /// </summary>
    internal static class VersionedFactFactoryHelper
    {
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

        internal static IFactType CannotIsType<TFact>(this IFactType type, string paramName)
            where TFact : IFact
        {
            if (type.IsFactType<TFact>())
                throw new ArgumentException($"Parameter {paramName} should not be converted into {typeof(TFact).FullName}");

            return type;
        }

        internal static TFact ConvertFact<TFact>(this IFact fact)
            where TFact : IFact
        {
            if (fact is TFact fact1)
                return fact1;

            throw CommonHelper.CreateDeriveException<TFact>(
                    CommonErrorCode.InvalidFactType, 
                    $"Fact {fact.GetFactType().FactName} should not be converted into {typeof(TFact).FullName}");
        }

        internal static IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        internal static IFact GetRightFactByVersionType<TFactBase>(this IFactContainer<TFactBase> container, IFactType searchFactType, IFactType versionType)
            where TFactBase : class, IVersionedFact
        {
            if (versionType != null)
            {
                IVersionFact version = GetVersionFact(container, versionType);
                return container.GetRightFactByVersion(searchFactType, version);
            }
            else
                return container.GetRightFactByVersion(searchFactType, null);
        }

        internal static IFact GetRightFactByVersion<TFactBase>(this IFactContainer<TFactBase> container, IFactType searchFactType, IVersionFact version)
            where TFactBase : class, IVersionedFact
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
                    if (facts.All(f => fact.Version.IsMoreThan(f.Version) || fact.Equals(f)))
                        return fact;
                }
            }
            else
            {
                List<IVersionedFact> scopeSearch = new List<IVersionedFact>();

                foreach (var fact in facts)
                {
                    if (fact.Version != null && !fact.Version.IsMoreThan(version))
                        scopeSearch.Add(fact);
                }

                foreach (var fact in scopeSearch)
                {
                    if (scopeSearch.All(f => fact.Version.IsMoreThan(f.Version) || fact.Equals(f)))
                        return fact;
                }
            }

            return null;
        }

        internal static bool IsMorePriorityThan<TFactBase, TFactWork, TFactContainer>(IFactWork<TFactBase> firstWork, TFactWork secondWork, TFactContainer container)
            where TFactBase : IVersionedFact
            where TFactWork : IFactWork<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            if (firstWork is IFactTypeVersionInfo firstVersionInfo)
            {
                if (secondWork is IFactTypeVersionInfo secondVersionInfo)
                {
                    if (firstVersionInfo.VersionType == null)
                        return secondVersionInfo.VersionType != null;
                    else
                    {
                        if (secondVersionInfo.VersionType == null)
                            return false;

                        IVersionFact firstVersion = container.GetVersionFact(firstVersionInfo.VersionType);
                        IVersionFact secondVersion = container.GetVersionFact(secondVersionInfo.VersionType);

                        return firstVersion.IsMoreThan(secondVersion);
                    }
                } 
            }

            return false;
        }

        internal static bool IsLessPriorityThan<TFactBase, TFactWork, TFactContainer>(IFactWork<TFactBase> firstWork, TFactWork secondWork, TFactContainer container)
            where TFactBase : IVersionedFact
            where TFactWork : IFactWork<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            if (firstWork is IFactTypeVersionInfo firstVersionInfo)
            {
                if (secondWork is IFactTypeVersionInfo secondVersionInfo)
                {
                    if (firstVersionInfo.VersionType == null)
                        return false;
                    else
                    {
                        if (secondVersionInfo.VersionType == null)
                            return true;

                        IVersionFact firstVersion = container.GetVersionFact(firstVersionInfo.VersionType);
                        IVersionFact secondVersion = container.GetVersionFact(secondVersionInfo.VersionType);

                        return firstVersion.IsLessThan(secondVersion);
                    }
                }
            }

            return false;
        }

        internal static bool СompatibilityWithRuleByVersion<TFactBase, TFactWork, TFactRule, TWantAction, TFactContainer>(this TFactWork work, TFactRule rule, TWantAction wantAction, TFactContainer container)
            where TFactBase : class, IVersionedFact
            where TFactWork : IFactWork<TFactBase>, IFactTypeVersionInfo
            where TFactRule : IFactRule<TFactBase>, IFactTypeVersionInfo
            where TWantAction : IWantAction<TFactBase>, IFactTypeVersionInfo
            where TFactContainer : IFactContainer<TFactBase>
        {
            // If the current work or action has an installed version and the rule has no version limit.
            if (rule.VersionType == null)
                return wantAction.VersionType == null;
            else if (wantAction.VersionType == null)
                return true;

            IVersionFact maxVersion = container.GetVersionFact(wantAction.VersionType);
            IVersionFact potentialVersion = container.GetVersionFact(rule.VersionType);

            if (potentialVersion.IsMoreThan(maxVersion))
                return false;

            return true;
        }
    }
}
