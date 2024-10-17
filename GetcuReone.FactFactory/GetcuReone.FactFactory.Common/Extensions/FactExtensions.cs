using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="IFact"/>
    /// </summary>
    public static class FactExtensions
    {
        /// <summary>
        /// Was the fact calculated using the rule.
        /// </summary>
        /// <param name="fact">Fact.</param>
        /// <returns></returns>
        public static bool IsCalculatedByRule(this IFact fact)
        {
            object? value = fact.FindParameter(FactParametersCodes.CalculateByRule)?.Value;

            if (value == null)
                return false;
            if (value is bool valueBool)
                return valueBool;

            return false;
        }

        /// <summary>
        /// Compare facts by <see cref="FactParametersCodes.CalculateByRule"/>.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int CompareTo(this IFact x, IFact y)
        {
            if (x.IsCalculatedByRule())
            {
                if (!y.IsCalculatedByRule())
                    return -1;
            }
            else if (y.IsCalculatedByRule())
                return 1;

            return 0;
        }
    }
}
