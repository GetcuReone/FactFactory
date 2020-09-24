﻿using GetcuReone.FactFactory.Entities;
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

        internal static IEnumerable<IFact> GetFactsFromContainerByFactTypes<TWantAction, TFactContainer>(this IWantActionContext<TWantAction, TFactContainer> context, IEnumerable<IFactType> factTypes)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            if (factTypes.IsNullOrEmpty())
                return Enumerable.Empty<IFact>();

            return context.Container.Where(fact => 
            {
                IFactType factType = context.Cache.GetFactType(fact);
                return factTypes.Any(type => type.EqualsFactType(factType));
            });
        }
    }
}
