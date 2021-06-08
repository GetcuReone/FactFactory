using FactFactory.Priority.Interfaces;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
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
        /// (<see cref="SingleEntityOperationsFacade.CompareFactRules{TFactRule, TWantAction, TFactContainer}(TFactRule, TFactRule, IWantActionContext{TWantAction, TFactContainer})"/>).
        /// </summary>
        /// <typeparam name="TFactRule">Type rule.</typeparam>
        /// <typeparam name="TWantAction">Type wantAction.</typeparam>
        /// <typeparam name="TFactContainer">Type fact container.</typeparam>
        /// <param name="x">First rule.</param>
        /// <param name="y">Secon role.</param>
        /// <param name="context">Context.</param>
        /// <returns>
        /// 1 - <paramref name="x"/> rule is greater than the <paramref name="y"/>,
        /// 0 - <paramref name="x"/> rule is equal than the <paramref name="y"/>,
        /// -1 - <paramref name="x"/> rule is less than the <paramref name="y"/>.
        /// </returns>
        public override int CompareFactRules<TFactRule, TWantAction, TFactContainer>(TFactRule x, TFactRule y, IWantActionContext<TWantAction, TFactContainer> context)
        {
            int priorityResult = x.CompareByPriority(y, context);

            return priorityResult != 0
                ? priorityResult
                : x.CompareTo(y);
        }

        /// <summary>
        /// Compares fact by priority and base attribute (<see cref="SingleEntityOperationsFacade.CompareFacts(IFact, IFact)"/>).
        /// </summary>
        /// <param name="x">First fact.</param>
        /// <param name="y">Second fact.</param>
        /// <returns>
        /// 1 - <paramref name="x"/> fact is greater than the <paramref name="y"/>,
        /// 0 - <paramref name="x"/> fact is equal than the <paramref name="y"/>,
        /// -1 - <paramref name="x"/> fact is less than the <paramref name="y"/>.
        /// </returns>
        public override int CompareFacts(IFact x, IFact y)
        {
            int defaultCompare = x.CompareTo(y);

            return defaultCompare != 0
                ? defaultCompare
                : x.CompareByPriorityParameter(y);
        }

        /// <summary>
        /// Calculates the fact and adds the priority fact to the parameters.
        /// </summary>
        /// <typeparam name="TFactRule">Type rule.</typeparam>
        /// <typeparam name="TWantAction">Type wantAction.</typeparam>
        /// <typeparam name="TFactContainer">Type fact container.</typeparam>
        /// <param name="node">Node containing information about the calculation rule.</param>
        /// <param name="context">Context</param>
        /// <returns>Fact.</returns>
        public override IFact CalculateFact<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
        {
            IPriorityFact priority = node.Info.Rule.GetPriorityFact(context);
            return base
                .CalculateFact(node, context)
                .AddPriorityParameter(priority);
        }

        /// <summary>
        /// Calculates the fact asynchronously and adds the priority fact to the parameters.
        /// </summary>
        /// <typeparam name="TFactRule">Type rule.</typeparam>
        /// <typeparam name="TWantAction">Type wantAction.</typeparam>
        /// <typeparam name="TFactContainer">Type fact container.</typeparam>
        /// <param name="node">Node containing information about the calculation rule.</param>
        /// <param name="context">Context</param>
        /// <returns>Fact.</returns>
        public override async ValueTask<IFact> CalculateFactAsync<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
        {
            IPriorityFact priority = node.Info.Rule.GetPriorityFact(context);
            return (await base.CalculateFactAsync(node, context).ConfigureAwait(false)).AddPriorityParameter(priority);
        }
    }
}
