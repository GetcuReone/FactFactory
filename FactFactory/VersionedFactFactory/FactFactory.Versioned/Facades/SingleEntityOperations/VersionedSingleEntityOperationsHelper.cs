﻿using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
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

        internal static IVersionFact GetVersionFact(this IEnumerable<IFactType> factTypes, IWantActionContext context)
        {
            IFactType versionType = factTypes.SingleOrDefault(type => type.IsFactType<IVersionFact>());
            return versionType != null
                ? (IVersionFact)context.Container.First(fact => context.Cache.GetFactType(fact).EqualsFactType(versionType))
                : null;
        }

        internal static bool CompatibleRule(this IFactRule factRule, IVersionFact maxVersion, IWantActionContext context)
        {
            var version = factRule.InputFactTypes.GetVersionFact(context);

            if (version == null)
                return false;

            return maxVersion.CompareTo(version) >= 0;
        }
    }
}
