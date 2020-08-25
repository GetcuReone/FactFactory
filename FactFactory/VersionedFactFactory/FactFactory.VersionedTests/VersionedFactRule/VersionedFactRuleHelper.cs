using GetcuReone.FactFactory.Interfaces;
using System.Linq;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;

namespace FactFactory.VersionedTests.VersionedFactRule
{
    public static class VersionedFactRuleHelper
    {
        public static Rule CreateRule(params IFactType[] factTypes)
        {
            return new Rule(facts => { return default; }, factTypes.Skip(1).ToList(), factTypes.First());
        }
    }
}
