using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
    }
}
