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
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="treeResult">Build tree.</param>
        /// <param name="deriveFactErrorDetails">Errors that occurred while building a tree.</param>
        /// <returns>True - build tree. False - not build tree.</returns>
        bool TryBuildTreeForFactInfo<TFactRule, TWantAction, TFactContainer>(BuildTreeForFactInfoRequest<TFactRule, TWantAction, TFactContainer> request, out TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeResult, out List<DeriveFactErrorDetail> deriveFactErrorDetails)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Try build trees for wantAction.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="result">Result.</param>
        /// <returns>True - build trees. False - not build trees.</returns>
        bool TryBuildTreesForWantAction<TFactRule, TWantAction, TFactContainer>(BuildTreesForWantActionRequest<TFactRule, TWantAction, TFactContainer> request, out BuildTreesForWantActionResult<TFactRule, TWantAction, TFactContainer> result)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Try build trees for wantActions.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <typeparam name="TFactRuleCollection">Rule collection type.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="result">Result.</param>
        /// <returns>Did you manage to build a tree?</returns>
        bool TryBuildTrees<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>(BuildTreesRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> request, out BuildTreesResult<TFactRule, TWantAction, TFactContainer> result)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// List of groups of independent nodes.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="treeByFactRule">Decision tree built for the rule.</param>
        /// <returns>Independent node groups.</returns>
        List<IndependentNodeGroup<TFactRule>> GetIndependentNodeGroups<TFactRule, TWantAction, TFactContainer>(TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeByFactRule)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Calculate trees and derive fact.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="wantActionInfo">Information about the WantAction.</param>
        /// <param name="treeByFactRules">Trees that need to be calculated to output a facts.</param>
        void CalculateTreeAndDeriveWantFacts<TFactRule, TWantAction, TFactContainer>(WantActionInfo<TWantAction, TFactContainer> wantActionInfo, IEnumerable<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> treeByFactRules)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Async calculate trees and derive fact.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="wantActionInfo">Information about the WantAction.</param>
        /// <param name="treeByFactRules">Trees that need to be calculated to output a facts.</param>
        ValueTask CalculateTreeAndDeriveWantFactsAsync<TFactRule, TWantAction, TFactContainer>(WantActionInfo<TWantAction, TFactContainer> wantActionInfo, IEnumerable<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> treeByFactRules)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;
    }
}
