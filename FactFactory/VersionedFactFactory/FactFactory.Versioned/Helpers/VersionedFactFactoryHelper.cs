using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.Helpers
{
    /// <summary>
    /// Helper for <see cref="VersionedFactFactoryBase{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
    /// </summary>
    internal static class VersionedFactFactoryHelper
    {
        internal static IVersionFact GetVersionFact(this IEnumerable<IFact> facts, IFactType factTypeVersion)
        {
            var versionFacts = facts.Where(fact => fact.GetFactType().Compare(factTypeVersion)).ToList();

            if (versionFacts.IsNullOrEmpty())
                throw FactFactoryHelper.CreateException(ErrorCode.VersionNotFound, $"No version fact '{factTypeVersion.FactName}' found");

            return versionFacts.First() as IVersionFact;
        }
    }
}
