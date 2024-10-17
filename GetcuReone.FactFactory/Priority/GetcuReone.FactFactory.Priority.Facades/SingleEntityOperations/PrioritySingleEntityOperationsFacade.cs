using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Priority.Common.Extensions;
using GetcuReone.FactFactory.Priority.Interfaces;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations
{
    /// <summary>
    /// Single operations on entities of the FactFactory. Sharpened for work with <see cref="IPriorityFact"/>.
    /// </summary>
    public class PrioritySingleEntityOperationsFacade : SingleEntityOperationsFacade
    {
        /// <summary>
        /// Compares rules by priority and base attribute
        /// (<see cref="SingleEntityOperationsFacade.CompareFactRules(IFactRule, IFactRule, IWantActionContext)"/>).
        /// </summary>
        /// <param name="firstRule">First rule.</param>
        /// <param name="secondRule">Secon role.</param>
        /// <param name="context">Context.</param>
        /// <returns>
        /// 1 - <paramref name="firstRule"/> rule is greater than the <paramref name="secondRule"/>,
        /// 0 - <paramref name="firstRule"/> rule is equal than the <paramref name="secondRule"/>,
        /// -1 - <paramref name="firstRule"/> rule is less than the <paramref name="secondRule"/>.
        /// </returns>
        public override int CompareFactRules(IFactRule firstRule, IFactRule secondRule, IWantActionContext context)
        {
            int priorityResult = firstRule.CompareByPriority(secondRule, context);

            return priorityResult != 0
                ? priorityResult
                : firstRule.CompareTo(secondRule);
        }

        /// <summary>
        /// Compares fact by priority and base attribute (<see cref="SingleEntityOperationsFacade.CompareFacts(IFact, IFact)"/>).
        /// </summary>
        /// <param name="firstFact">First fact.</param>
        /// <param name="secondFact">Second fact.</param>
        /// <returns>
        /// 1 - <paramref name="firstFact"/> fact is greater than the <paramref name="secondFact"/>,
        /// 0 - <paramref name="firstFact"/> fact is equal than the <paramref name="secondFact"/>,
        /// -1 - <paramref name="firstFact"/> fact is less than the <paramref name="secondFact"/>.
        /// </returns>
        public override int CompareFacts(IFact firstFact, IFact secondFact)
        {
            int defaultCompare = firstFact.CompareTo(secondFact);

            return defaultCompare != 0
                ? defaultCompare
                : firstFact.CompareByPriorityParameter(secondFact);
        }

        /// <summary>
        /// Calculates the fact and adds the priority fact to the parameters.
        /// </summary>
        /// <param name="node">Node containing information about the calculation rule.</param>
        /// <param name="context">Context</param>
        /// <returns>Fact.</returns>
        public override IFact CalculateFact(NodeByFactRule node, IWantActionContext context)
        {
            IPriorityFact? priority = node.Info.Rule.FindPriorityFact(context);

            IFact fact = base.CalculateFact(node, context);

            if (priority != null)
                fact.AddPriorityParameter(priority, context.ParameterCache);

            return fact;
        }

        /// <summary>
        /// Calculates the fact asynchronously and adds the priority fact to the parameters.
        /// </summary>
        /// <param name="node">Node containing information about the calculation rule.</param>
        /// <param name="context">Context</param>
        /// <returns>Fact.</returns>
        public override async ValueTask<IFact> CalculateFactAsync(NodeByFactRule node, IWantActionContext context)
        {
            IPriorityFact? priority = node.Info.Rule.FindPriorityFact(context);

            IFact fact = await base.CalculateFactAsync(node, context)
                .ConfigureAwait(false);

            if (priority != null)
                fact.AddPriorityParameter(priority, context.ParameterCache);

            return fact;
        }
    }
}
