using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Interfaces.Operations
{
    /// <summary>
    /// Tree building operations.
    /// </summary>
    public interface ITreeBuildingOperations
    {
        /// <summary>
        /// Try build tree for wantFact.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="treeResult">Build tree.</param>
        /// <param name="deriveFactErrorDetails">Errors that occurred while building a tree.</param>
        /// <returns>True - build tree. False - not build tree.</returns>
        bool TryBuildTreeForFactInfo<TFactRule, TWantAction>(
            BuildTreeForFactInfoRequest<TFactRule, TWantAction> request,
            out TreeByFactRule<TFactRule, TWantAction> treeResult,
            out List<DeriveFactErrorDetail> deriveFactErrorDetails)
            where TFactRule : IFactRule
            where TWantAction : IWantAction;

        /// <summary>
        /// Try build trees for wantAction.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="result">Result.</param>
        /// <returns>True - build trees. False - not build trees.</returns>
        bool TryBuildTreesForWantAction<TFactRule, TWantAction>(
            BuildTreesForWantActionRequest<TFactRule, TWantAction> request,
            out BuildTreesForWantActionResult<TFactRule, TWantAction> result)
            where TFactRule : IFactRule
            where TWantAction : IWantAction;

        /// <summary>
        /// List of groups of independent nodes.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <param name="treeByFactRule">Decision tree built for the rule.</param>
        /// <returns>Independent node groups.</returns>
        List<IndependentNodeGroup<TFactRule>> GetIndependentNodeGroups<TFactRule, TWantAction>(TreeByFactRule<TFactRule, TWantAction> treeByFactRule)
            where TFactRule : IFactRule
            where TWantAction : IWantAction;

        /// <summary>
        /// Calculate trees and derive fact.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <param name="wantActionInfo">Information about the WantAction.</param>
        /// <param name="treeByFactRules">Trees that need to be calculated to output a facts.</param>
        void CalculateTreeAndDeriveWantFacts<TFactRule, TWantAction>(
            WantActionInfo<TWantAction> wantActionInfo,
            IEnumerable<TreeByFactRule<TFactRule, TWantAction>> treeByFactRules)
            where TFactRule : IFactRule
            where TWantAction : IWantAction;

        /// <summary>
        /// Async calculate trees and derive fact.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <param name="wantActionInfo">Information about the WantAction.</param>
        /// <param name="treeByFactRules">Trees that need to be calculated to output a facts.</param>
        ValueTask CalculateTreeAndDeriveWantFactsAsync<TFactRule, TWantAction>(
            WantActionInfo<TWantAction> wantActionInfo,
            IEnumerable<TreeByFactRule<TFactRule, TWantAction>> treeByFactRules)
            where TFactRule : IFactRule
            where TWantAction : IWantAction;
    }
}
