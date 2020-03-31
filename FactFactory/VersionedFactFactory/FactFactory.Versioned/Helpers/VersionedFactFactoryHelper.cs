using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CommonErrorCode = GetcuReone.FactFactory.Constants.ErrorCode;

namespace GetcuReone.FactFactory.Versioned.Helpers
{
    /// <summary>
    /// Helper for <see cref="VersionedFactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
    /// </summary>
    internal static class VersionedFactFactoryHelper
    {
        internal static IVersionFact GetVersionFact<TFact>(this IEnumerable<TFact> facts, IFactType factTypeVersion)
            where TFact : IVersionedFact
        {
            if (!factTypeVersion.TryGetFact(facts, out TFact fact))
                throw FactFactoryHelper.CreateException(ErrorCode.VersionNotFound, $"No version fact '{factTypeVersion.FactName}' found");

            return fact as IVersionFact;
        }

        internal static IFactType SingleOrNullFactVersion(this IEnumerable<IFactType> factTypes)
        {
            List<IFactType> typeFacts = factTypes.Where(factType => factType.IsFactType<IVersionFact>()).ToList();

            if (typeFacts.IsNullOrEmpty())
                return null;
            else if (typeFacts.Count > 1)
                throw FactFactoryHelper.CreateException(ErrorCode.OnlyOneVersionFact, $"You cannot specify more than one version fact\nInputFactTypes: ({string.Join(", ", factTypes)})");

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

            throw FactFactoryHelper.CreateDeriveException<TFact>(
                    CommonErrorCode.InvalidFactType, 
                    $"Fact {fact.GetFactType().FactName} should not be converted into {typeof(TFact).FullName}");
        }

        internal static IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        internal static TFactBase GetRightFactByVersionType<TFactBase>(this IFactContainer<TFactBase> container, IFactType searchFactType, IFactType versionType)
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

        internal static TFactBase GetRightFactByVersion<TFactBase>(this IFactContainer<TFactBase> container, IFactType searchFactType, IVersionFact version)
            where TFactBase : class, IVersionedFact
        {
            if (searchFactType.IsFactType<ISpecialFact>())
            {
                if (searchFactType.TryGetFact(container, out var fact))
                    return fact;

                return null;
            }
            else
            {
                List<TFactBase> facts = container.Where(fact => fact.GetFactType().Compare(searchFactType)).ToList();

                if (facts.Count == 0)
                    return null;

                // List of facts not calculated using a rule.
                List<TFactBase> factsCalculatedNotByRule = facts.Where(fact => !fact.CalculatedByRule).ToList();

                if (factsCalculatedNotByRule.Count != 0)
                    return ChooseFactByVersion(factsCalculatedNotByRule, version) ?? factsCalculatedNotByRule.First();
                else
                    return ChooseFactByVersion(facts, version);
            }
        }

        private static TFactBase ChooseFactByVersion<TFactBase>(List<TFactBase> facts, IVersionFact version)
            where TFactBase : class, IVersionedFact
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
                List<TFactBase> scopeSearch = new List<TFactBase>();

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

        internal static bool IsMorePriorityThan<TFactBase, TWorkFact, TFactContainer>(IWorkFact<TFactBase> firstWork, TWorkFact secondWork, TFactContainer container)
            where TFactBase : IVersionedFact
            where TWorkFact : IWorkFact<TFactBase>
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

        internal static bool IsLessPriorityThan<TFactBase, TWorkFact, TFactContainer>(IWorkFact<TFactBase> firstWork, TWorkFact secondWork, TFactContainer container)
            where TFactBase : IVersionedFact
            where TWorkFact : IWorkFact<TFactBase>
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
    }
}
