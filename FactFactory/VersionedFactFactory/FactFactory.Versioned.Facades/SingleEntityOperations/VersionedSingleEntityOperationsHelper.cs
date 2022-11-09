using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations
{
    internal static class VersionedSingleEntityOperationsHelper
    {
        internal static IVersionFact GetVersionFact<TWantAction>(this IEnumerable<IFactType> factTypes, IWantActionContext<TWantAction> context)
            where TWantAction : IWantAction
        {
            IFactType versionType = factTypes.SingleOrDefault(type => type.IsFactType<IVersionFact>());
            return versionType != null
                ? (IVersionFact)context.Container.First(fact => context.Cache.GetFactType(fact).EqualsFactType(versionType))
                : null;
        }

        internal static bool CompatibleRule<TFactRule, TWantAction>(this TFactRule factRule, IVersionFact maxVersion, IWantActionContext<TWantAction> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
        {
            var version = factRule.InputFactTypes.GetVersionFact(context);

            if (version == null)
                return false;

            return maxVersion.CompareTo(version) >= 0;
        }
    }
}
