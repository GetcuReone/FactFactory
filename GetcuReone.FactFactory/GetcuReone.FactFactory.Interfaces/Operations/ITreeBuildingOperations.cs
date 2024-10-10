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
        /// <param name="request">Request.</param>
        /// <param name="treeResult">Build tree.</param>
        /// <param name="deriveFactErrorDetails">Errors that occurred while building a tree.</param>
        /// <returns>True - build tree. False - not build tree.</returns>
        bool TryBuildTreeForFactInfo(
            BuildTreeForFactInfoRequest request,
            out TreeByFactRule treeResult,
            out List<DeriveFactErrorDetail> deriveFactErrorDetails);

        /// <summary>
        /// Try build trees for wantAction.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="result">Result.</param>
        /// <returns>True - build trees. False - not build trees.</returns>
        bool TryBuildTreesForWantAction(BuildTreesForWantActionRequest request, out BuildTreesForWantActionResult result);

        /// <summary>
        /// List of groups of independent nodes.
        /// </summary>
        /// <param name="treeByFactRule">Decision tree built for the rule.</param>
        /// <returns>Independent node groups.</returns>
        List<IndependentNodeGroup> GetIndependentNodeGroups(TreeByFactRule treeByFactRule);

        /// <summary>
        /// Calculate trees and derive fact.
        /// </summary>
        /// <param name="wantActionInfo">Information about the WantAction.</param>
        /// <param name="treeByFactRules">Trees that need to be calculated to output a facts.</param>
        void CalculateTreeAndDeriveWantFacts(WantActionInfo wantActionInfo, IEnumerable<TreeByFactRule> treeByFactRules);

        /// <summary>
        /// Async calculate trees and derive fact.
        /// </summary>
        /// <param name="wantActionInfo">Information about the WantAction.</param>
        /// <param name="treeByFactRules">Trees that need to be calculated to output a facts.</param>
        ValueTask CalculateTreeAndDeriveWantFactsAsync(WantActionInfo wantActionInfo, IEnumerable<TreeByFactRule> treeByFactRules);
    }
}
