using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;

namespace GetcuReone.FactFactory.Facades.TreeBuildingOperations
{
    /// <summary>
    /// Tree building operations.
    /// </summary>
    public class TreeBuildingOperationsFacade : ITreeBuildingOperations
    {
        /// <inheritdoc/>
        public virtual bool TryBuildTreeForFactInfo(
            BuildTreeForFactInfoRequest request,
            [NotNullWhen(true)] out TreeByFactRule? treeResult,
            [NotNullWhen(false)] out List<DeriveFactErrorDetail>? deriveFactErrorDetails)
        {
            var context = request.Context;
            treeResult = null;
            deriveFactErrorDetails = null;

            // find the rules that can calculate the fact
            List<TreeByFactRule> treesByWantFactType = request.GetTreesByRequest();
            var treeReady = treesByWantFactType.FirstOrDefault(tree => tree.Status == TreeStatus.Built);

            if (treeReady != null)
            {
                treeResult = treeReady;
                return true;
            }

            List<List<IFactType>> notFoundFactSet = treesByWantFactType.ConvertAll(item => new List<IFactType>());
            var allFinichedNodes = new Dictionary<NodeByFactRuleInfo, NodeByFactRule>();

            while (true)
            {
                for (int i = treesByWantFactType.Count - 1; i >= 0; i--)
                {
                    var treeByWantFactType = treesByWantFactType[i];

                    if (treeByWantFactType.Status != TreeStatus.BeingBuilt)
                        continue;

                    int lastlevelNumber = treeByWantFactType.Levels.Count - 1;

                    // If after synchronization we can calculate the tree.
                    if (TreeBuildingOperationsFacade.TrySyncTreeLevelsAndFinishedNodes(treeByWantFactType, lastlevelNumber, allFinichedNodes))
                    {
                        treeByWantFactType.Built();
                        continue;
                    }

                    List<NodeByFactRule> lastTreeLevel = treeByWantFactType.Levels[lastlevelNumber];

                    // If in the last level there are no nodes for calculation, then the tree can be calculated.
                    if (lastTreeLevel.Count == 0)
                    {
                        treeByWantFactType.Built();
                        continue;
                    }

                    // Next level nodes.
                    var nextTreeLevel = new List<NodeByFactRule>();
                    var currentLevelFinishedNodes = new Dictionary<NodeByFactRuleInfo, NodeByFactRule>();
                    bool cannotDerived = false;

                    for (int j = 0; j < lastTreeLevel.Count; j++)
                    {
                        NodeByFactRule node = lastTreeLevel[j];
                        NodeByFactRuleInfo nodeInfo = node.Info;
                        Dictionary<NodeByFactRuleInfo, NodeByFactRule> copatibleAllFinishedNodes = nodeInfo.GetCompatibleFinishedNodes(allFinichedNodes, context);
                        List<IFactType> needFacts = nodeInfo
                            .RequiredFactTypes
                            .FindAll(needFactType => !CanRemoveFromNeedFactTypes(needFactType, node, context, copatibleAllFinishedNodes));

                        // If the rule can be calculated from the parameters in the container, then add the node to the list of complete.
                        if (needFacts.IsNullOrEmpty())
                        {
                            allFinichedNodes.Add(node.Info, node);
                            currentLevelFinishedNodes.Add(node.Info, node);
                            continue;
                        }

                        bool canTryRemoveNode = false;
                        foreach (var needFact in needFacts!)
                        {
                            if (needFact.IsFactType<ISpecialFact>())
                            {
                                if (!canTryRemoveNode)
                                    canTryRemoveNode = true;

                                notFoundFactSet[i].Add(needFact);
                                continue;
                            }

                            var needRules = nodeInfo
                                .CompatibleRules
                                !.FindAll(rule => rule.OutputFactType.EqualsFactType(needFact) && !rule.RuleContainBranch(node));

                            if (needRules.Count > 0)
                            {
                                List<NodeByFactRule> nodes = needRules.GetNodesByRules(node, treeByWantFactType);
                                nextTreeLevel.AddRange(nodes);
                                node.Childs!.AddRange(nodes);
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
                            cannotDerived = TreeBuildingOperationsFacade.TryRemoveRootNode(node, treeByWantFactType, lastlevelNumber);
                            j--;
                        }
                    }

                    if (cannotDerived)
                        treeByWantFactType.Cencel();
                    else if (currentLevelFinishedNodes.Count > 0)
                    {
                        if (TreeBuildingOperationsFacade.TrySyncTreeLevelsAndFinishedNodes(treeByWantFactType, lastlevelNumber, currentLevelFinishedNodes))
                            treeByWantFactType.Built();
                        else if (nextTreeLevel.Count > 0)
                        {
                            TreeBuildingOperationsFacade.SyncTreeLevelAndFinishedNodes(nextTreeLevel, currentLevelFinishedNodes, context);
                            treeByWantFactType.Levels.Add(nextTreeLevel);
                        }
                    }
                    else if (nextTreeLevel.Count > 0)
                        treeByWantFactType.Levels.Add(nextTreeLevel);
                    else
                        treeByWantFactType.Built();
                }

                List<TreeByFactRule> builtTrees = treesByWantFactType
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
                    deriveFactErrorDetails.Add(new DeriveFactErrorDetail(request.WantFactType, factSet.AsReadOnly()));

            return false;
        }

        /// <summary>
        /// Synchronize tree levels with years ready for calculation.
        /// </summary>
        /// <param name="treeByFactRule">Tree whose levels you want to synchronize.</param>
        /// <param name="level">The level at which to start synchronization.</param>
        /// <param name="finishedNodes"></param>
        /// <returns>True - managed to sync root level</returns>
        private static bool TrySyncTreeLevelsAndFinishedNodes(
            TreeByFactRule treeByFactRule,
            int level,
            Dictionary<NodeByFactRuleInfo,
            NodeByFactRule> finishedNodes)
        {
            if (level < 0)
                return true;

            var context = treeByFactRule.Context;
            List<NodeByFactRule> currentLevel = treeByFactRule.Levels[level];
            var finishedNodesInCurrentLevel = new Dictionary<NodeByFactRuleInfo, NodeByFactRule>();

            foreach (var node in currentLevel)
            {
                IFactRule rule = node.Info.Rule;

                IFactRuleCollection finishedRules = context
                    .FactRules
                    !.FindAll(r => finishedNodes.Any(n =>
                        n.Key.Rule.EqualsWork(r, context.WantAction, context.Container)));

                IFactRuleCollection copabilitiesFinishedRules = rule.GetCompatibleRulesEx(finishedRules, context);

                if (rule.InputFactTypes.Count == 0)
                    finishedNodesInCurrentLevel.Add(node.Info, node);
                else if (node.Info.RequiredFactTypes.All(requiredFactType => !requiredFactType.IsBuildOrRuntimeFact() && copabilitiesFinishedRules.Any(r => r.OutputFactType.EqualsFactType(requiredFactType))))
                    finishedNodesInCurrentLevel.Add(node.Info, node);
                else if (copabilitiesFinishedRules.Any(r => r.EqualsWork(rule, context.WantAction, context.Container)))
                    finishedNodesInCurrentLevel.Add(node.Info, node);
            }

            if (finishedNodesInCurrentLevel.IsNullOrEmpty())
                return false;

            TreeBuildingOperationsFacade.SyncTreeLevelAndFinishedNodes(currentLevel, finishedNodesInCurrentLevel!, context);

            foreach (KeyValuePair<NodeByFactRuleInfo, NodeByFactRule> finishedNode in finishedNodesInCurrentLevel!)
            {
                if (finishedNodes.Keys.Any(nodeInfo => nodeInfo.Rule.EqualsWork(finishedNode.Key.Rule, context.WantAction, context.Container)))
                    continue;
                finishedNodes.Add(finishedNode.Key, finishedNode.Value);
            }
            return TreeBuildingOperationsFacade.TrySyncTreeLevelsAndFinishedNodes(treeByFactRule, level - 1, finishedNodes);
        }

        /// <summary>
        /// Synchronize the tree level with years ready for calculation.
        /// </summary>
        /// <param name="treeLevel">Tree level.</param>
        /// <param name="finishedNodes">Nodes by which the rule can already be calculated. Key - node info, value - node</param>
        /// <param name="context">Context.</param>
        private static void SyncTreeLevelAndFinishedNodes(
            List<NodeByFactRule> treeLevel,
            Dictionary<NodeByFactRuleInfo,
            NodeByFactRule> finishedNodes,
            IWantActionContext context)
        {
            foreach (var finishedNode in finishedNodes)
            {
                List<NodeByFactRule> parentNodes = treeLevel
                    .Where(node => node.Info.Rule.EqualsWork(finishedNode.Key.Rule, context.WantAction, context.Container))
                    .Select(node => node.Parent!)
                    .Distinct()
                    .ToList();

                foreach (NodeByFactRule parentNode in parentNodes)
                {
                    if (parentNode == null)
                        continue;

                    for (int i = parentNode.Childs!.Count - 1; i >= 0; i--)
                    {
                        NodeByFactRule childNode = parentNode.Childs[i];

                        if (!childNode.Info.Rule.OutputFactType.EqualsFactType(finishedNode.Key.Rule.OutputFactType))
                            continue;

                        parentNode.Childs.Remove(childNode);
                        int indexNodeInTreeLevel = treeLevel.IndexOf(childNode);
                        if (indexNodeInTreeLevel != -1)
                            treeLevel.RemoveAt(indexNodeInTreeLevel);
                    }

                    if (parentNode == finishedNode.Value.Parent)
                        parentNode.Childs.Add(finishedNode.Value);
                    else
                        parentNode.Childs.Add(finishedNode.Value.Copy(parentNode));
                }
            }
        }

        /// <summary>
        /// Determines you can no longer consider the <paramref name="factType"/> necessary.
        /// </summary>
        /// <param name="factType">Fact type info.</param>
        /// <param name="node"></param>
        /// <param name="context"></param>
        /// <param name="copatibleAllFinishedNodes"></param>
        /// <returns>True - may not be considered necessary</returns>
        private bool CanRemoveFromNeedFactTypes(
            IFactType factType,
            NodeByFactRule node,
            IFactRulesContext context,
            Dictionary<NodeByFactRuleInfo,
            NodeByFactRule> copatibleAllFinishedNodes)
        {
            // Exclude condition special facts
            if (factType.IsFactType<IBuildConditionFact>())
            {
                NodeByFactRuleInfo nodeInfo = node.Info;

                if (nodeInfo.BuildSuccessConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(factType)))
                    return true;
                else if (nodeInfo.BuildFailedConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(factType)))
                    return false;

                var condition = factType.CreateBuildConditionFact<IBuildConditionFact>();

                if (condition.Condition(nodeInfo.Rule, context, _ => nodeInfo.CompatibleRules!))
                {
                    nodeInfo.BuildSuccessConditions.Add(condition);
                    return true;
                }
                else
                {
                    nodeInfo.BuildFailedConditions.Add(condition);
                    return false;
                }
            }
            else if (factType.IsFactType<IRuntimeConditionFact>())
            {
                NodeByFactRuleInfo nodeInfo = node.Info;

                if (nodeInfo.RuntimeConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(factType)))
                    return true;

                IRuntimeConditionFact condition = factType.CreateRuntimeConditionFact<IRuntimeConditionFact>();

                condition.SetGetRelatedRulesFunc(GetRelatedRules, node.Info.Rule, context.FactRules!);

                nodeInfo.RuntimeConditions.Add(condition);

                return true;
            }
            else
            {
                // Exclude facts for which a solution has already been found.
                List<KeyValuePair<NodeByFactRuleInfo, NodeByFactRule>> finishedNodesForCurrentFact = copatibleAllFinishedNodes
                    .Where(finishedNode => finishedNode.Key.Rule.OutputFactType.EqualsFactType(factType))
                    .ToList();

                if (finishedNodesForCurrentFact.Count != 0)
                {
                    node.Childs!.Insert(0, finishedNodesForCurrentFact[0].Value);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Delete current node.
        /// </summary>
        /// <param name="node">Node to be removed.</param>
        /// <param name="treeByFactRule">Rule tree.</param>
        /// <param name="level">Level in tree.</param>
        /// <returns>True - remove root node.</returns>
        /// <remarks>
        /// Recursively delete parent nodes
        /// if they do not have other nodes calculating the fact from the child node.
        /// </remarks>
        private static bool TryRemoveRootNode(
            NodeByFactRule node,
            TreeByFactRule treeByFactRule, int level)
        {
            treeByFactRule.Levels[level].Remove(node);

            if (level == 0)
                return true;

            NodeByFactRule parent = node.Parent!;

            parent.Childs!.Remove(node);

            // If the node has a child node that can calculate this fact
            if (parent.Childs.Any(n => n.Info.Rule.OutputFactType.EqualsFactType(node.Info.Rule.OutputFactType)))
                return false;
            else
                return TreeBuildingOperationsFacade.TryRemoveRootNode(parent, treeByFactRule, level - 1);
        }

        /// <inheritdoc/>
        public bool TryBuildTreesForWantAction(BuildTreesForWantActionRequest request, out BuildTreesForWantActionResult result)
        {
            var context = request.Context;
            var deriveFactErrorDetails = new List<DeriveFactErrorDetail>();
            var wantActionInfo = new WantActionInfo(context);
            result = new BuildTreesForWantActionResult(wantActionInfo);

            foreach (var needFactType in context.SingleEntity.GetRequiredTypesOfFacts(context.WantAction, context))
            {
                if (needFactType.IsFactType<IBuildConditionFact>())
                {
                    if (wantActionInfo.BuildSuccessConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(needFactType)) || wantActionInfo.BuildFailedConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(needFactType)))
                        continue;

                    var condition = needFactType.CreateBuildConditionFact<IBuildConditionFact>();

                    if (condition.Condition(context.WantAction, context, ct => ct.WantAction.GetCompatibleRulesEx(request.FactRules, context)))
                    {
                        result.WantActionInfo.BuildSuccessConditions.Add(condition);
                    }
                    else
                    {
                        result.WantActionInfo.BuildFailedConditions.Add(condition);
                        deriveFactErrorDetails.Add(new DeriveFactErrorDetail(needFactType, null));
                    }

                    continue;
                }

                if (needFactType.IsFactType<IRuntimeConditionFact>())
                {
                    var condition = needFactType.CreateRuntimeConditionFact<IRuntimeConditionFact>();

                    result.WantActionInfo.RuntimeConditions.Add(condition);

                    continue;
                }

                var newContext = new FactRulesContext(context)
                {
                    FactRules = context
                            .WantAction
                            .GetCompatibleRulesEx(request.FactRules, context),
                };
                var requestFactType = new BuildTreeForFactInfoRequest(needFactType, newContext);

                if (context.TreeBuilding.TryBuildTreeForFactInfo(requestFactType, out var resultTree, out var errorList))
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
                    context.Container,
                    deriveFactErrorDetails);

                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public virtual List<IndependentNodeGroup> GetIndependentNodeGroups(TreeByFactRule treeByFactRule)
        {
            var allGroups = new List<IndependentNodeGroup>();

            FillChildIndependentNodeGroup(treeByFactRule.Root, allGroups);
            allGroups.Add(new IndependentNodeGroup { treeByFactRule.Root });

            return allGroups;
        }

        private static void FillChildIndependentNodeGroup(NodeByFactRule node, List<IndependentNodeGroup> groups)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            if (node.Childs.IsNullOrEmpty())
#pragma warning restore CS8604 // Possible null reference argument.
                return;

            foreach (NodeByFactRule child in node.Childs!)
                FillChildIndependentNodeGroup(child, groups);

            IndependentNodeGroup lastGroup;

            if (groups.Count == 0)
            {
                lastGroup = new IndependentNodeGroup();

                groups.Add(lastGroup);
            }
            else
                lastGroup = groups.Last();

            foreach (var child in node.Childs)
            {
                if (lastGroup.CanAdd(child))
                    lastGroup.Add(child);
                else
                {
                    lastGroup = new IndependentNodeGroup { child };

                    groups.Add(lastGroup);
                }
            }
        }

        /// <inheritdoc/>
        public virtual void CalculateTreeAndDeriveWantFacts(WantActionInfo wantActionInfo, IEnumerable<TreeByFactRule> treeByFactRules)
        {
            foreach (var tree in treeByFactRules)
            {
                (var context, var singleOperations, var treeOperations, var container) =
                    (tree.Context, tree.Context.SingleEntity, tree.Context.TreeBuilding, tree.Context.Container);

                foreach (var group in treeOperations.GetIndependentNodeGroups(tree))
                {
                    var syncNodes = new List<NodeByFactRule>();
                    var syncAndParallelNodes = new List<NodeByFactRule>();

                    foreach (var node in group)
                    {
                        if (!singleOperations.NeedCalculateFact(node, context))
                            continue;

                        if (node.Info.Rule.Option.HasFlag(FactWorkOption.CanExecuteSync))
                        {
                            if (node.Info.Rule.Option.HasFlag(FactWorkOption.CanExcecuteParallel))
                                syncAndParallelNodes.Add(node);
                            else
                                syncNodes.Add(node);
                        }
                        else
                            throw FactFactoryHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"The tree contains non-synchronous rule <{node.Info.Rule}>.");
                    }

                    if (syncNodes.Count != 0)
                        syncNodes.ForEach(node => 
                        {
                            IFact fact = singleOperations.CalculateFact(node, context);
                            using FactContainerWriter writer = container.GetWriter();
                            writer.Add(fact);
                        });

                    if (syncAndParallelNodes.Count != 0)
                        Parallel.ForEach(syncAndParallelNodes, node => 
                        {
                            IFact fact = singleOperations.CalculateFact(node, context);
                            using FactContainerWriter writer = container.GetWriter();
                            writer.Add(fact);
                        });
                }
            }

            if (wantActionInfo.Context.WantAction.Option.HasFlag(FactWorkOption.CanExecuteSync))
                wantActionInfo.Context.SingleEntity.DeriveWantFacts(wantActionInfo);
            else
                throw FactFactoryHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"Non-synchronous wantAction <{wantActionInfo}>.");
        }

        /// <inheritdoc/>
        public virtual async ValueTask CalculateTreeAndDeriveWantFactsAsync(WantActionInfo wantActionInfo, IEnumerable<TreeByFactRule> treeByFactRules)
        {
            foreach (var tree in treeByFactRules)
            {
                var context = tree.Context;
                foreach (var group in GetIndependentNodeGroups(tree))
                {
                    var syncNodes = new List<NodeByFactRule>();
                    var syncAndParallelNodes = new List<NodeByFactRule>();
                    var asyncNodes = new List<NodeByFactRule>();
                    var asyncAndParallelNodes = new List<NodeByFactRule>();

                    foreach (var node in group)
                    {
                        if (!context.SingleEntity.NeedCalculateFact(node, context))
                            continue;

                        if (node.Info.Rule.Option.HasFlag(FactWorkOption.CanExecuteSync))
                        {
                            if (node.Info.Rule.Option.HasFlag(FactWorkOption.CanExcecuteParallel))
                                syncAndParallelNodes.Add(node);
                            else
                                syncNodes.Add(node);
                        }
                        else if (node.Info.Rule.Option.HasFlag(FactWorkOption.CanExecuteAsync))
                        {
                            if (node.Info.Rule.Option.HasFlag(FactWorkOption.CanExcecuteParallel))
                                asyncAndParallelNodes.Add(node);
                            else
                                asyncNodes.Add(node);
                        }
                        else
                            throw FactFactoryHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"The tree contains non-synchronous and non-asynchronous rule <{node.Info.Rule}>.");
                    }

                    if (syncNodes.Count != 0)
                        syncNodes.ForEach(node =>
                        {
                            IFact fact = context.SingleEntity.CalculateFact(node, context);
                            using FactContainerWriter writer = context.Container.GetWriter();
                            writer.Add(fact);
                        });

                    if (syncAndParallelNodes.Count != 0)
                        Parallel.ForEach(syncAndParallelNodes, node =>
                        {
                            IFact fact = context.SingleEntity.CalculateFact(node, context);
                            using FactContainerWriter writer = context.Container.GetWriter();
                            writer.Add(fact);
                        });

                    if (asyncNodes.Count != 0)
                        foreach(var node in asyncNodes)
                        {
                            IFact fact = await context.SingleEntity.CalculateFactAsync(node, context).ConfigureAwait(false);
                            using FactContainerWriter writer = context.Container.GetWriter();
                            writer.Add(fact);
                        }

                    if (asyncAndParallelNodes.Count != 0)
                    {
                        IReadOnlyCollection<IFact> facts = await asyncAndParallelNodes
                            .ConvertAll(node => context.SingleEntity.CalculateFactAsync(node, context))
                            .WhenAll()
                            .ConfigureAwait(false);

                        foreach(var fact in facts)
                            using (var writer = context.Container.GetWriter())
                                writer.Add(fact);
                    }
                }
            }

            if (wantActionInfo.Context.WantAction.Option.HasFlag(FactWorkOption.CanExecuteSync))
                wantActionInfo.Context.SingleEntity.DeriveWantFacts(wantActionInfo);
            else if (wantActionInfo.Context.WantAction.Option.HasFlag(FactWorkOption.CanExecuteAsync))
                await wantActionInfo.Context.SingleEntity.DeriveWantFactsAsync(wantActionInfo).ConfigureAwait(false);
            else
                throw FactFactoryHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"Non-synchronous and non-asynchronous wantAction <{wantActionInfo}>.");
        }

        /// <summary>
        /// Return related facts.
        /// </summary>
        /// <param name="rule">Fact rule.</param>
        /// <param name="rules">Fact rules.</param>
        /// <param name="context">Context.</param>
        /// <returns>Related fact rules.</returns>
        private IFactRuleCollection GetRelatedRules(
            IFactRule rule,
            IFactRuleCollection rules,
            IWantActionContext context)
        {
            return rules.FindAll(r => !r.EqualsWork(rule, context.WantAction, context.Container));
        }
    }
}
