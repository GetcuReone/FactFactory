using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Priority.Constants;
using GetcuReone.FactFactory.Priority.Interfaces;

namespace GetcuReone.FactFactory.Priority.Common.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="IFact"/>.
    /// </summary>
    public static class FactPriorityExtensions
    {
        /// <summary>
        /// Find parameter by <see cref="PriorityFactParametersCodes.Priority"/>.
        /// </summary>
        /// <param name="fact">Fact.</param>
        /// <returns><see cref="IPriorityFact"/> fact or null.</returns>
        public static IPriorityFact? FindPriorityParameter(this IFact fact)
        {
            return fact.FindParameter(PriorityFactParametersCodes.Priority)?.Value as IPriorityFact;
        }

        /// <summary>
        /// Adds a priority fact to parameters.
        /// </summary>
        /// <typeparam name="TFact">Type fact</typeparam>
        /// <param name="fact">Fact.</param>
        /// <param name="priority">Priority fact.</param>
        /// <param name="parameterCache">Fact parameter cache.</param>
        /// <returns><paramref name="fact"/>.</returns>
        public static TFact AddPriorityParameter<TFact>(this TFact fact, IPriorityFact priority, IFactParameterCache parameterCache)
            where TFact : IFact
        {
            fact.AddParameter(parameterCache.GetOrCreate(PriorityFactParametersCodes.Priority, priority));

            return fact;
        }

        /// <summary>
        /// Compares facts by priority facts in parameters.
        /// </summary>
        /// <param name="x">Fist fact.</param>
        /// <param name="y">Second fact.</param>
        /// <returns>
        /// 1 - <paramref name="x"/> fact is greater than the <paramref name="y"/>,
        /// 0 - <paramref name="x"/> fact is equal than the <paramref name="y"/>,
        /// -1 - <paramref name="x"/> fact is less than the <paramref name="y"/>.
        /// </returns>
        public static int CompareByPriorityParameter(this IFact x, IFact y)
        {
            IPriorityFact? xPriority = x.FindParameter(PriorityFactParametersCodes.Priority)?.Value as IPriorityFact;
            IPriorityFact? yPriority = y.FindParameter(PriorityFactParametersCodes.Priority)?.Value as IPriorityFact;

            if (xPriority == null)
                return yPriority != null ? -1 : 0;
            if (yPriority == null)
                return 1;

            return xPriority.CompareTo(yPriority);
        }
    }
}
