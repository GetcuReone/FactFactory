using GetcuReone.FactFactory.Interfaces;
using System.Linq;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;

namespace FactFactory.VersionedTests.VersionedFactRule
{
    public static class VersionedFactRuleHelper
    {
        public static Rule CreateRule(params IFactType[] factTypes)
        {
            return new Rule(ct => { return default; }, factTypes.ToList(), null);
        }
    }
}
