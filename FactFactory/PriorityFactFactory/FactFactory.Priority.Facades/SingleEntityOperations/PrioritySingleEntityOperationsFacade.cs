using FactFactory.Priority.Interfaces;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations
{
    /// <inheritdoc/>
    public class PrioritySingleEntityOperationsFacade : SingleEntityOperationsFacade
    {
        /// <inheritdoc/>
        public override int CompareFactRules<TFactRule, TWantAction, TFactContainer>(TFactRule x, TFactRule y, IWantActionContext<TWantAction, TFactContainer> context)
        {
            int priorityResult = x.CompareByPriority(y, context);

            return priorityResult != 0
                ? priorityResult
                : x.CompareTo(y);
        }

        /// <inheritdoc/>
        public override int CompareFacts(IFact x, IFact y)
        {
            int defaultCompare = x.CompareTo(y);

            return defaultCompare != 0
                ? defaultCompare
                : x.CompareByPriority(y);
        }

        /// <inheritdoc/>
        public override IFact CalculateFact<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
        {
            IPriorityFact priority = node.Info.Rule.GetPriorityFact(context);
            return base.CalculateFact(node, context).SetPriority(priority);
        }

        /// <inheritdoc/>
        public override async ValueTask<IFact> CalculateFactAsync<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
        {
            IPriorityFact priority = node.Info.Rule.GetPriorityFact(context);
            return (await base.CalculateFactAsync(node, context).ConfigureAwait(false)).SetPriority(priority);
        }
    }
}
