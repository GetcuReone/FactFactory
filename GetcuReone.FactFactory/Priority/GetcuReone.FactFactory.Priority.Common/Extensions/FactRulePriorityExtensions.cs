using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Priority.Interfaces;
using System.Linq;

namespace GetcuReone.FactFactory.Priority.Common.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="IFactRule"/>
    /// </summary>
    public static class FactRulePriorityExtensions
    {
        /// <summary>
        /// Compares rules based on priority facts.
        /// </summary>
        /// <param name="firstRule">First rule.</param>
        /// <param name="secondRule">Second rule.</param>
        /// <param name="context">Context.</param>
        /// <returns>
        /// 1 - <paramref name="firstRule"/> rule is greater than the <paramref name="secondRule"/>,
        /// 0 - <paramref name="firstRule"/> rule is equal than the <paramref name="secondRule"/>,
        /// -1 - <paramref name="firstRule"/> rule is less than the <paramref name="secondRule"/>.
        /// </returns>
        public static int CompareByPriority(this IFactRule firstRule, IFactRule secondRule, IWantActionContext context)
        {
            var xPriorityType = firstRule.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IPriorityFact>());
            var yPriorityType = secondRule.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IPriorityFact>());

            if (xPriorityType == null)
                return yPriorityType == null ? 0 : -1;
            if (yPriorityType == null)
                return 1;

            IPriorityFact xPriority = context.Container.FirstPriorityFactByFactType(xPriorityType, context.Cache)!;
            IPriorityFact yPriority = context.Container.FirstPriorityFactByFactType(yPriorityType, context.Cache)!;

            return xPriority.CompareTo(yPriority);
        }
    }
}
