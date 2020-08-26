using FactFactory.Priority.Interfaces;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Priority.Constants;

namespace GetcuReone.FactFactory.Priority
{
    /// <summary>
    /// Helper for PriorityFactFactory.
    /// </summary>
    public static class PriorityFactFactoryHelper
    {
        /// <summary>
        /// Get priority fact.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        public static IPriorityFact GetPriorityOrNull<TFact>(this TFact fact)
            where TFact : IFact
        {
            return fact.GetParameter(PriorityFactParametersCodes.Priority)?.Value as IPriorityFact;
        }

        /// <summary>
        /// Set parameter 'priority'.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <typeparam name="TPriority"></typeparam>
        /// <param name="fact"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public static TFact SetPriority<TFact, TPriority>(this TFact fact, TPriority priority)
            where TFact : IFact
            where TPriority : IPriorityFact
        {
            fact.AddParameter(new FactParameter(PriorityFactParametersCodes.Priority, priority));
            return fact;
        }
    }
}
