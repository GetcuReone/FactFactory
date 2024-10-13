using System.Collections.Generic;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Priority.Interfaces;

namespace GetcuReone.FactFactory.Priority.Common.Extensions
{
    /// <summary>
    /// Extensions methods for array of <see cref="IFact"/>
    /// </summary>
    public static class ArrayOfFactPriorityExtensions
    {
        /// <summary>
        /// Searches for the first occurrence of a priority fact
        /// </summary>
        /// <typeparam name="TFact">Type fact</typeparam>
        /// <param name="facts">Fact list</param>
        /// <param name="factType">Fact type of 'priority'</param>
        /// <param name="cache">Cache</param>
        /// <returns><see cref="IPriorityFact"/> fact or null</returns>
        public static IPriorityFact? FirstPriorityFactByFactType<TFact>(this IEnumerable<TFact> facts, IFactType factType, IFactTypeCache cache)
            where TFact : IFact
        {
            return facts.FirstFactByFactType(factType, cache) as IPriorityFact;
        }
    }
}
