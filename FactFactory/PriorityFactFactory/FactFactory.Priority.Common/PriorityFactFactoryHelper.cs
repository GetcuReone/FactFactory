using FactFactory.Priority.Interfaces;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Priority.Constants;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Priority
{
    /// <summary>
    /// Helper for PriorityFactFactory.
    /// </summary>
    public static class PriorityFactFactoryHelper
    {
        /// <summary>
        /// Find parameter by <see cref="PriorityFactParametersCodes.Priority"/>.
        /// </summary>
        /// <typeparam name="TFact">Type fact.</typeparam>
        /// <param name="fact">Fact.</param>
        /// <returns><see cref="IPriorityFact"/> fact or null.</returns>
        public static IPriorityFact FindPriorityParameter<TFact>(this TFact fact)
            where TFact : IFact
        {
            return fact.GetParameter(PriorityFactParametersCodes.Priority)?.Value as IPriorityFact;
        }

        /// <summary>
        /// Adds a priority fact to parameters.
        /// </summary>
        /// <typeparam name="TFact">Type fact</typeparam>
        /// <typeparam name="TPriority">Type priority fact.</typeparam>
        /// <param name="fact">Fact.</param>
        /// <param name="priority">Priority fact.</param>
        /// <returns><paramref name="fact"/>.</returns>
        public static TFact AddPriorityParameter<TFact, TPriority>(this TFact fact, TPriority priority)
            where TFact : IFact
            where TPriority : IPriorityFact
        {
            fact.AddParameter(new FactParameter(PriorityFactParametersCodes.Priority, priority));
            return fact;
        }

        /// <summary>
        /// Searches for the first occurrence of a priority fact.
        /// </summary>
        /// <typeparam name="TFact">Type fact.</typeparam>
        /// <param name="facts">Fact list.</param>
        /// <param name="factType">Fact type of 'priority'.</param>
        /// <param name="cache">Cache.</param>
        /// <returns><see cref="IPriorityFact"/> fact or null.</returns>
        public static IPriorityFact FirstPriorityFactByFactType<TFact>(this IEnumerable<TFact> facts, IFactType factType, IFactTypeCache cache)
            where TFact : IFact
        {
            return facts.FirstFactByFactType(factType, cache) as IPriorityFact;
        }

        /// <summary>
        /// Compares rules based on priority facts.
        /// </summary>
        /// <typeparam name="TFactRule">Type rule.</typeparam>
        /// <typeparam name="TWantAction">Type wantAction.</typeparam>
        /// <typeparam name="TFactContainer">Type fact container.</typeparam>
        /// <param name="x">First rule.</param>
        /// <param name="y">Second rule.</param>
        /// <param name="context">Context.</param>
        /// <returns>
        /// 1 - <paramref name="x"/> rule is greater than the <paramref name="y"/>,
        /// 0 - <paramref name="x"/> rule is equal than the <paramref name="y"/>,
        /// -1 - <paramref name="x"/> rule is less than the <paramref name="y"/>.
        /// </returns>
        public static int CompareByPriority<TFactRule, TWantAction, TFactContainer>(this TFactRule x, TFactRule y, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var xPriorityType = x.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IPriorityFact>());
            var yPriorityType = y.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IPriorityFact>());

            if (xPriorityType == null)
                return yPriorityType == null ? 0 : -1;
            if (yPriorityType == null)
                return 1;

            IPriorityFact xPriority = context.Container.FirstPriorityFactByFactType(xPriorityType, context.Cache);
            IPriorityFact yPriority = context.Container.FirstPriorityFactByFactType(yPriorityType, context.Cache);

            return xPriority.CompareTo(yPriority);
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
            var xPriority = x.GetParameter(PriorityFactParametersCodes.Priority)?.Value as IPriorityFact;
            var yPriority = y.GetParameter(PriorityFactParametersCodes.Priority)?.Value as IPriorityFact;

            if (xPriority == null)
                return yPriority != null ? -1 : 0;
            if (yPriority == null)
                return 1;

            return xPriority.CompareTo(yPriority);
        }
    }
}
