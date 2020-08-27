using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;

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
        public override bool TryCalculateFact<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context, out IFact fact)
        {
            var result = base.TryCalculateFact(node, context, out fact);

            if (result)
            {
                var priority = node.Info.Rule.GetPriorityFact(context);
                if (priority != null)
                    fact.SetPriority(priority);
            }

            return result;
        }
    }
}
