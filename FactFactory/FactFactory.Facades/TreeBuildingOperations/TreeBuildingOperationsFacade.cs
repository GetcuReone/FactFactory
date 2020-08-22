using GetcuReone.ComboPatterns.Facade;
using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Facades.TreeBuildingOperations
{
    /// <summary>
    /// Tree building operations.
    /// </summary>
    public class TreeBuildingOperationsFacade : FacadeBase, ITreeBuildingOperations
    {
        /// <inheritdoc/>
        public virtual bool TryBuildTreeForFactInfo<TFactRule, TWantAction, TFactContainer>(BuildTreeForFactInfoRequest<TFactRule, TWantAction, TFactContainer> request, out TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeResult, out List<DeriveFactErrorDetail> deriveFactErrorDetails)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var context = request.Context;
            treeResult = null;
            deriveFactErrorDetails = null;

            // find the rules that can calculate the fact
            List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> treesByWantFactType = request.GetTreesByRequest();
            var treeReady = treesByWantFactType.FirstOrDefault(tree => tree.Status == TreeStatus.Built);

            if (treeReady != null)
            {
                treeResult = treeReady;
                return true;
            }

            List<List<IFactType>> notFoundFactSet = treesByWantFactType.ConvertAll(item => new List<IFactType>());
            var allFinichedNodes = new Dictionary<NodeByFactRuleInfo<TFactRule>, NodeByFactRule<TFactRule>>();

            while (true)
            {
                for (int i = treesByWantFactType.Count - 1; i >= 0; i--)
                {
                    var treeByWantFactType = treesByWantFactType[i];

                    if (treeByWantFactType.Status != TreeStatus.BeingBuilt)
                        continue;

                    int lastlevelNumber = treeByWantFactType.Levels.Count - 1;

                    // If after synchronization we can calculate the tree.
                    if (TrySyncTreeLevelsAndFinishedNodes(treeByWantFactType, lastlevelNumber, allFinichedNodes))
                    {
                        treeByWantFactType.Built();
                        continue;
                    }

                    List<NodeByFactRule<TFactRule>> lastTreeLevel = treeByWantFactType.Levels[lastlevelNumber];

                    // If in the last level there are no nodes for calculation, then the tree can be calculated.
                    if (lastTreeLevel.Count == 0)
                    {
                        treeByWantFactType.Built();
                        continue;
                    }

                    // Next level nodes.
                    var nextTreeLevel = new List<NodeByFactRule<TFactRule>>();
                    var currentLevelFinishedNodes = new Dictionary<NodeByFactRuleInfo<TFactRule>, NodeByFactRule<TFactRule>>();
                    bool cannotDerived = false;

                    for (int j = 0; j < lastTreeLevel.Count; j++)
                    {
                        NodeByFactRule<TFactRule> node = lastTreeLevel[j];
                        NodeByFactRuleInfo<TFactRule> nodeInfo = node.Info;
                        Dictionary<NodeByFactRuleInfo<TFactRule>, NodeByFactRule<TFactRule>> copatibleAllFinishedNodes = nodeInfo.GetCompatibleFinishedNodes(allFinichedNodes, context);
                        List<IFactType> needFacts = context
                            .SingleEntity
                            .GetRequiredTypesOfFacts(nodeInfo.Rule, context)
                            .Where(needFactType => !CanRemoveFromNeedFactTypes(needFactType, node, context, copatibleAllFinishedNodes))
                            .ToList();

                        // If the rule can be calculated from the parameters in the container, then add the node to the list of complete.
                        if (needFacts.IsNullOrEmpty())
                        {
                            allFinichedNodes.Add(node.Info, node);
                            currentLevelFinishedNodes.Add(node.Info, node);
                            continue;
                        }

                        bool canTryRemoveNode = false;
                        foreach (var needFact in needFacts)
                        {
                            if (needFact.IsFactType<ISpecialFact>())
                            {
                                if (!canTryRemoveNode)
                                    canTryRemoveNode = true;

                                notFoundFactSet[i].Add(needFact);
                                continue;
                            }

                            var needRules = context
                                .FactRules
                                .Where(rule => rule.OutputFactType.EqualsFactType(needFact) && !rule.RuleContainBranch(node))
                                .ToList();

                            if (needRules.Count > 0)
                            {
                                List<NodeByFactRule<TFactRule>> nodes = needRules.GetNodesByRules(node, treeByWantFactType);
                                nextTreeLevel.AddRange(nodes);
                                node.Childs.AddRange(nodes);
                            }
                            else
                            {
                                if (!canTryRemoveNode)
                                    canTryRemoveNode = true;

                                notFoundFactSet[i].Add(needFact);
                            }
                        }

                        if (canTryRemoveNode)
                        {
                            // Is there a neighboring node capable of deriving this fact.
                            cannotDerived = TryRemoveRootNode(node, treeByWantFactType, lastlevelNumber);
                            j--;
                        }
                    }

                    if (cannotDerived)
                        treeByWantFactType.Cencel();
                    else if (currentLevelFinishedNodes.Count > 0)
                    {
                        if (TrySyncTreeLevelsAndFinishedNodes(treeByWantFactType, lastlevelNumber, currentLevelFinishedNodes))
                            treeByWantFactType.Built();
                        else if (nextTreeLevel.Count > 0)
                        {
                            SyncTreeLevelAndFinishedNodes(nextTreeLevel, currentLevelFinishedNodes, context);
                            treeByWantFactType.Levels.Add(nextTreeLevel);
                        }
                    }
                    else if (nextTreeLevel.Count > 0)
                        treeByWantFactType.Levels.Add(nextTreeLevel);
                    else
                        treeByWantFactType.Built();
                }

                List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> builtTrees = treesByWantFactType
                    .FindAll(tree => tree.Status == TreeStatus.Built);

                if (builtTrees.Count != 0)
                {
                    var countRuleByBuiltTrees = builtTrees.ToDictionary(tree => tree, tree => tree.GetUniqueRulesFromTree().Count);
                    int minRuleCount = countRuleByBuiltTrees.Min(item => item.Value);
                    var suitableTree = countRuleByBuiltTrees.First(item => item.Value == minRuleCount).Key;

                    foreach (var tree in treesByWantFactType)
                        if (tree != suitableTree && tree.Status != TreeStatus.Cencel && tree.GetUniqueRulesFromTree().Count >= minRuleCount)
                            tree.Cencel();

                    if (treesByWantFactType.All(tree => tree.Status != TreeStatus.BeingBuilt))
                    {
                        treeResult = suitableTree;
                        return true;
                    }
                }

                if (treesByWantFactType.All(tree => tree.Status == TreeStatus.Cencel))
                    break;
            }

            deriveFactErrorDetails = new List<DeriveFactErrorDetail>();

            foreach (var factSet in notFoundFactSet)
                if (factSet.Count != 0)
                    deriveFactErrorDetails.Add(new DeriveFactErrorDetail(request.WantFactType, factSet.ToReadOnlyCollection()));

            return false;
        }

        /// <summary>
        /// Synchronize tree levels with years ready for calculation.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="treeByFactRule">Tree whose levels you want to synchronize.</param>
        /// <param name="level">The level at which to start synchronization.</param>
        /// <param name="finishedNodes"></param>
        /// <returns>True - managed to sync root level</returns>
        private bool TrySyncTreeLevelsAndFinishedNodes<TFactRule, TWantAction, TFactContainer>(TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeByFactRule, int level, Dictionary<NodeByFactRuleInfo<TFactRule>, NodeByFactRule<TFactRule>> finishedNodes)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            if (level < 0)
                return true;

            var context = treeByFactRule.Context;
            List<NodeByFactRule<TFactRule>> currentLevel = treeByFactRule.Levels[level];
            var finishedNodesInCurrentLevel = new Dictionary<NodeByFactRuleInfo<TFactRule>, NodeByFactRule<TFactRule>>();

            foreach (var node in currentLevel)
            {
                var rule = node.Info.Rule;
                var copabilitiesFinishedRules = rule
                    .GetCompatibleRulesEx(finishedNodes.Select(item => item.Key.Rule), context)
                    .ToList();

                if (rule.InputFactTypes.Count > 0 && rule.InputFactTypes.All(f => copabilitiesFinishedRules.Any(r => r.OutputFactType.EqualsFactType(f))))
                    finishedNodesInCurrentLevel.Add(node.Info, node);
                else if (copabilitiesFinishedRules.Any(r => r.EqualsWork(rule, context.WantAction, context.Container)))
                    finishedNodesInCurrentLevel.Add(node.Info, node);
            }

            if (finishedNodesInCurrentLevel.IsNullOrEmpty())
                return false;

            SyncTreeLevelAndFinishedNodes(currentLevel, finishedNodesInCurrentLevel, context);

            foreach (var finishedNode in finishedNodesInCurrentLevel)
            {
                if (finishedNodes.Keys.Any(nodeInfo => nodeInfo.Rule.EqualsWork(finishedNode.Key.Rule, context.WantAction, context.Container)))
                    continue;
                finishedNodes.Add(finishedNode.Key, finishedNode.Value);
            }
            return TrySyncTreeLevelsAndFinishedNodes(treeByFactRule, level - 1, finishedNodes);
        }

        /// <summary>
        /// Synchronize the tree level with years ready for calculation.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="treeLevel">Tree level.</param>
        /// <param name="finishedNodes">Nodes by which the rule can already be calculated. Key - node info, value - node</param>
        /// <param name="context">Context.</param>
        private void SyncTreeLevelAndFinishedNodes<TFactRule, TWantAction, TFactContainer>(List<NodeByFactRule<TFactRule>> treeLevel, Dictionary<NodeByFactRuleInfo<TFactRule>, NodeByFactRule<TFactRule>> finishedNodes, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            foreach (var finishedNode in finishedNodes)
            {
                List<NodeByFactRule<TFactRule>> parentNodes = treeLevel
                    .Where(node => node.Info.Rule.EqualsWork(finishedNode.Key.Rule, context.WantAction, context.Container))
                    .Select(node => node.Parent)
                    .Distinct()
                    .ToList();

                foreach (NodeByFactRule<TFactRule> parentNode in parentNodes)
                {
                    if (parentNode == null)
                        continue;

                    for (int i = parentNode.Childs.Count - 1; i >= 0; i--)
                    {
                        NodeByFactRule<TFactRule> childNode = parentNode.Childs[i];
                        if (!childNode.Info.Rule.OutputFactType.EqualsFactType(finishedNode.Key.Rule.OutputFactType))
                            continue;

                        parentNode.Childs.Remove(childNode);
                        int indexNodeInTreeLevel = treeLevel.IndexOf(childNode);
                        if (indexNodeInTreeLevel != -1)
                            treeLevel.RemoveAt(indexNodeInTreeLevel);
                    }

                    parentNode.Childs.Add(finishedNode.Value);
                }
            }
        }

        private bool CanRemoveFromNeedFactTypes<TFactRule, TWantAction, TFactContainer>(IFactType factType, NodeByFactRule<TFactRule> node, IFactRulesContext<TFactRule, TWantAction, TFactContainer> context, Dictionary<NodeByFactRuleInfo<TFactRule>, NodeByFactRule<TFactRule>> copatibleAllFinishedNodes)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            // Exclude condition special facts
            if (factType.IsFactType<IConditionFact>())
            {
                var nodeInfo = node.Info;

                if (nodeInfo.SuccessConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(factType)))
                    return true;
                else if (nodeInfo.FailedConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(factType)))
                    return false;

                var conditionFact = factType.CreateConditionFact<IConditionFact>();

                if (conditionFact.Condition(nodeInfo.Rule, nodeInfo.Rule.GetCompatibleRulesEx(context.FactRules, context), context))
                {
                    nodeInfo.SuccessConditions.Add(conditionFact);
                    return true;
                }
                else
                {
                    nodeInfo.FailedConditions.Add(conditionFact);
                    return false;
                }
            }
            else
            {
                // Exclude facts for which a solution has already been found.
                List<KeyValuePair<NodeByFactRuleInfo<TFactRule>, NodeByFactRule<TFactRule>>> finishedNodesForCurrentFact = copatibleAllFinishedNodes
                    .Where(finishedNode => finishedNode.Key.Rule.OutputFactType.EqualsFactType(factType))
                    .ToList();

                if (finishedNodesForCurrentFact.Count != 0)
                {
                    node.Childs.Insert(0, finishedNodesForCurrentFact[0].Value);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Delete current node. Recursively delete parent nodes if they do not have other nodes calculating the fact from the child node.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="node"></param>
        /// <param name="treeByFactRule"></param>
        /// <param name="level"></param>
        /// <returns>True - remove root node.</returns>
        private bool TryRemoveRootNode<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeByFactRule, int level)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            treeByFactRule.Levels[level].Remove(node);

            if (level == 0)
                return true;

            NodeByFactRule<TFactRule> parent = node.Parent;
            parent.Childs.Remove(node);

            // If the node has a child node that can calculate this fact
            if (parent.Childs.Any(n => n.Info.Rule.OutputFactType.EqualsFactType(node.Info.Rule.OutputFactType)))
                return false;
            else
                return TryRemoveRootNode(parent, treeByFactRule, level - 1);
        }

        /// <inheritdoc/>
        public bool TryBuildTreesForWantAction<TFactRule, TWantAction, TFactContainer>(BuildTreesForWantActionRequest<TFactRule, TWantAction, TFactContainer> request, out BuildTreesForWantActionResult<TFactRule, TWantAction, TFactContainer> result)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var context = request.Context;
            var deriveFactErrorDetails = new List<DeriveFactErrorDetail>();
            var wantActionInfo = new WantActionInfo<TWantAction, TFactContainer>
            {
                FailedConditions = new List<IConditionFact>(),
                SuccessConditions = new List<IConditionFact>(),
                WantAction = context.WantAction,
            };
            result = new BuildTreesForWantActionResult<TFactRule, TWantAction, TFactContainer>
            {
                TreesResult = new List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>>(),
                WantActionInfo = wantActionInfo,
            };

            foreach (var needFactType in context.SingleEntity.GetRequiredTypesOfFacts(context.WantAction, context))
            {
                if (needFactType.IsFactType<IConditionFact>())
                {
                    if (wantActionInfo.SuccessConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(needFactType)) || wantActionInfo.FailedConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(needFactType)))
                        continue;

                    var condition = needFactType.CreateConditionFact<IConditionFact>();

                    if (condition.Condition(context.WantAction, context.WantAction.GetCompatibleRulesEx(request.FactRules, context), context))
                    {
                        result.WantActionInfo.SuccessConditions.Add(condition);
                        continue;
                    }
                    else
                        result.WantActionInfo.FailedConditions.Add(condition);
                }

                var requestFactType = new BuildTreeForFactInfoRequest<TFactRule, TWantAction, TFactContainer>
                {
                    WantFactType = needFactType,
                    Context = new FactRulesContext<TFactRule, TWantAction, TFactContainer>
                    {
                        Cache = context.Cache,
                        Container = context.Container,
                        FactRules = context
                            .WantAction
                            .GetCompatibleRulesEx(request.FactRules, context)
                            .ToList(),
                        SingleEntity = context.SingleEntity,
                        TreeBuilding = context.TreeBuilding,
                        WantAction = context.WantAction,
                    },
                };

                if (TryBuildTreeForFactInfo(requestFactType, out var resultTree, out var errorList))
                {
                    result.TreesResult.Add(resultTree);
                }
                else
                {
                    deriveFactErrorDetails.AddRange(errorList);
                }
            }

            if (deriveFactErrorDetails.Count != 0)
            {
                result.DeriveErrorDetail = new DeriveErrorDetail(
                    ErrorCode.FactCannotDerived,
                    $"Failed to derive one or more facts for the action {context.WantAction}.",
                    context.WantAction,
                    deriveFactErrorDetails);

                return false;
            }

            return true;
        }
    }
}
