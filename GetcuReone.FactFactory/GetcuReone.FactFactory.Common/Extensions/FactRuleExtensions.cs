using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Linq;

namespace GetcuReone.FactFactory.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="IFactRule"/>
    /// </summary>
    public static class FactRuleExtensions
    {
        /// <summary>
        /// Compare fact rules.
        /// </summary>
        /// <param name="firstRule"></param>
        /// <param name="secondRule"></param>
        /// <returns></returns>
        public static int CompareTo(this IFactRule firstRule, IFactRule secondRule)
        {
            if (firstRule is IWantAction || secondRule is IWantAction)
                return 0;

            if (firstRule.InputFactTypes.IsNullOrEmpty())
            {
                if (secondRule.InputFactTypes.IsNullOrEmpty())
                    return 0;

                return secondRule.InputFactTypes.Any(factType => factType.IsFactType<ISpecialFact>())
                    ? -1
                    : 1;
            }

            if (secondRule.InputFactTypes.IsNullOrEmpty())
            {
                return firstRule.InputFactTypes.Any(factType => factType.IsFactType<ISpecialFact>())
                    ? 1
                    : -1;
            }

            int xCountCondition = firstRule.InputFactTypes.Count(factType => factType.IsFactType<IBuildConditionFact>());
            int yCountCondition = secondRule.InputFactTypes.Count(factType => factType.IsFactType<IBuildConditionFact>());

            if (xCountCondition != yCountCondition)
            {
                return xCountCondition > yCountCondition
                    ? 1
                    : -1;
            }

            int xCountSpecial = firstRule.InputFactTypes.Count(factType => factType.IsFactType<ISpecialFact>());
            int yCountSpecial = secondRule.InputFactTypes.Count(factType => factType.IsFactType<ISpecialFact>());

            if (xCountSpecial != yCountSpecial)
            {
                return xCountSpecial > yCountSpecial
                    ? 1
                    : -1;
            }

            if (firstRule.InputFactTypes.Count > secondRule.InputFactTypes.Count)
                return -1;
            if (firstRule.InputFactTypes.Count < secondRule.InputFactTypes.Count)
                return 1;
            return 0;
        }
    }
}
