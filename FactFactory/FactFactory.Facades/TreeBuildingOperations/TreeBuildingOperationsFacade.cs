using GetcuReone.ComboPatterns.Facade;
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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                        foreach (var needFact in needFacts)
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
                                .FindAll(rule => rule.OutputFactType.EqualsFactType(needFact) && !rule.RuleContainBranch(node));

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
                    deriveFactErrorDetails.Add(new DeriveFactErrorDetail(request.WantFactType, factSet.AsReadOnly()));

            return false;
        }

        /// <summary>
        /// Synchronize tree levels with years ready for calculation.
        /// </summary>
        /// <typeparam name="TFactRule">FatcRule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">FactContainer type.</typeparam>
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
                TFactRule rule = node.Info.Rule;
                IFactRuleCollection<TFactRule> finishedRules = context
                    .FactRules
                    .FindAll(r => finishedNodes.Any(n =>
                        n.Key.Rule.EqualsWork(r, context.WantAction, context.Container)));
                IFactRuleCollection<TFactRule> copabilitiesFinishedRules = rule.GetCompatibleRulesEx(finishedRules, context);

                if (rule.InputFactTypes.Count == 0)
                    finishedNodesInCurrentLevel.Add(node.Info, node);
                else if (node.Info.RequiredFactTypes.All(requiredFactType => !requiredFactType.IsBuildOrRuntimeFact() && copabilitiesFinishedRules.Any(r => r.OutputFactType.EqualsFactType(requiredFactType))))
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
        /// <typeparam name="TFactRule">FactRole type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">FactContainer type.</typeparam>
        /// <param name="factType">Fact type info.</param>
        /// <param name="node"></param>
        /// <param name="context"></param>
        /// <param name="copatibleAllFinishedNodes"></param>
        /// <returns>True - may not be considered necessary</returns>
        private bool CanRemoveFromNeedFactTypes<TFactRule, TWantAction, TFactContainer>(IFactType factType, NodeByFactRule<TFactRule> node, IFactRulesContext<TFactRule, TWantAction, TFactContainer> context, Dictionary<NodeByFactRuleInfo<TFactRule>, NodeByFactRule<TFactRule>> copatibleAllFinishedNodes)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            // Exclude condition special facts
            if (factType.IsFactType<IBuildConditionFact>())
            {
                var nodeInfo = node.Info;

                if (nodeInfo.BuildSuccessConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(factType)))
                    return true;
                else if (nodeInfo.BuildFailedConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(factType)))
                    return false;

                var condition = Factory.CreateObject(
                    type => type.CreateBuildConditionFact<IBuildConditionFact>(),
                    factType
                );

                if (condition.Condition(nodeInfo.Rule, context, _ => nodeInfo.CompatibleRules))
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
                var nodeInfo = node.Info;

                if (nodeInfo.RuntimeConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(factType)))
                    return true;

                var condition = Factory.CreateObject(
                    type => type.CreateRuntimeConditionFact<IRuntimeConditionFact>(),
                    factType
                );

                condition.SetGetRelatedRulesFunc<TFactRule, TWantAction, TFactContainer>(GetRelatedRules, node.Info.Rule, context.FactRules);

                nodeInfo.RuntimeConditions.Add(condition);

                return true;
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
        /// Delete current node.
        /// </summary>
        /// <typeparam name="TFactRule">FatcRule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">FactContainer type.</typeparam>
        /// <param name="node">Node to be removed.</param>
        /// <param name="treeByFactRule">Rule tree.</param>
        /// <param name="level">Level in tree.</param>
        /// <returns>True - remove root node.</returns>
        /// <remarks>
        /// Recursively delete parent nodes
        /// if they do not have other nodes calculating the fact from the child node.
        /// </remarks>
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
                BuildFailedConditions = new List<IBuildConditionFact>(),
                BuildSuccessConditions = new List<IBuildConditionFact>(),
                RuntimeConditions = new List<IRuntimeConditionFact>(),
                Context = context,
            };
            result = new BuildTreesForWantActionResult<TFactRule, TWantAction, TFactContainer>
            {
                TreesResult = new List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>>(),
                WantActionInfo = wantActionInfo,
            };

            foreach (var needFactType in context.SingleEntity.GetRequiredTypesOfFacts(context.WantAction, context))
            {
                if (needFactType.IsFactType<IBuildConditionFact>())
                {
                    if (wantActionInfo.BuildSuccessConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(needFactType)) || wantActionInfo.BuildFailedConditions.Exists(fact => context.Cache.GetFactType(fact).EqualsFactType(needFactType)))
                        continue;

                    var condition = Factory.CreateObject(
                        type => type.CreateBuildConditionFact<IBuildConditionFact>(),
                        needFactType
                    );

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
                    var condition = Factory.CreateObject(
                        type => type.CreateRuntimeConditionFact<IRuntimeConditionFact>(),
                        needFactType);

                    result.WantActionInfo.RuntimeConditions.Add(condition);

                    continue;
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
                            .GetCompatibleRulesEx(request.FactRules, context),
                        SingleEntity = context.SingleEntity,
                        TreeBuilding = context.TreeBuilding,
                        WantAction = context.WantAction,
                        Engine = context.Engine,
                    },
                };

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
        public virtual List<IndependentNodeGroup<TFactRule>> GetIndependentNodeGroups<TFactRule, TWantAction, TFactContainer>(TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeByFactRule)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var allGroups = new List<IndependentNodeGroup<TFactRule>>();
            FillChildIndependentNodeGroup(treeByFactRule.Root, allGroups);
            allGroups.Add(new IndependentNodeGroup<TFactRule> { treeByFactRule.Root });
            return allGroups;
        }

        private void FillChildIndependentNodeGroup<TFactRule>(NodeByFactRule<TFactRule> node, List<IndependentNodeGroup<TFactRule>> groups)
            where TFactRule : IFactRule
        {
            if (node.Childs.IsNullOrEmpty())
                return;

            foreach (var child in node.Childs)
                FillChildIndependentNodeGroup(child, groups);

            IndependentNodeGroup<TFactRule> lastGroup;

            if (groups.Count == 0)
            {
                lastGroup = new IndependentNodeGroup<TFactRule>();
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
                    lastGroup = new IndependentNodeGroup<TFactRule> { child };
                    groups.Add(lastGroup);
                }
            }
        }

        /// <inheritdoc/>
        public virtual void CalculateTreeAndDeriveWantFacts<TFactRule, TWantAction, TFactContainer>(WantActionInfo<TWantAction, TFactContainer> wantActionInfo, IEnumerable<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> treeByFactRules)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            foreach (var tree in treeByFactRules)
            {
                (var context, var singleOperations, var treeOperations, var container) =
                    (tree.Context, tree.Context.SingleEntity, tree.Context.TreeBuilding, tree.Context.Container);

                foreach (var group in treeOperations.GetIndependentNodeGroups(tree))
                {
                    var syncNodes = new List<NodeByFactRule<TFactRule>>();
                    var syncAndParallelNodes = new List<NodeByFactRule<TFactRule>>();

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
                            var fact = singleOperations.CalculateFact(node, context);
                            using (var writer = container.GetWriter())
                                writer.Add(fact);
                        });

                    if (syncAndParallelNodes.Count != 0)
                        Parallel.ForEach(syncAndParallelNodes, node => 
                        {
                            var fact = singleOperations.CalculateFact(node, context);
                            using (var writer = container.GetWriter())
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
        public virtual async ValueTask CalculateTreeAndDeriveWantFactsAsync<TFactRule, TWantAction, TFactContainer>(WantActionInfo<TWantAction, TFactContainer> wantActionInfo, IEnumerable<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> treeByFactRules)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            foreach (var tree in treeByFactRules)
            {
                var context = tree.Context;
                foreach (var group in GetIndependentNodeGroups(tree))
                {
                    var syncNodes = new List<NodeByFactRule<TFactRule>>();
                    var syncAndParallelNodes = new List<NodeByFactRule<TFactRule>>();
                    var asyncNodes = new List<NodeByFactRule<TFactRule>>();
                    var asyncAndParallelNodes = new List<NodeByFactRule<TFactRule>>();

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
                            var fact = context.SingleEntity.CalculateFact(node, context);
                            using (var writer = context.Container.GetWriter())
                                writer.Add(fact);
                        });

                    if (syncAndParallelNodes.Count != 0)
                        Parallel.ForEach(syncAndParallelNodes, node =>
                        {
                            var fact = context.SingleEntity.CalculateFact(node, context);
                            using (var writer = context.Container.GetWriter())
                                writer.Add(fact);
                        });

                    if (asyncNodes.Count != 0)
                        foreach(var node in asyncNodes)
                        {
                            var fact = await context.SingleEntity.CalculateFactAsync(node, context).ConfigureAwait(false);
                            using (var writer = context.Container.GetWriter())
                                writer.Add(fact);
                        }

                    if (asyncAndParallelNodes.Count != 0)
                    {
                        var facts = await asyncAndParallelNodes
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
        /// <typeparam name="TFactRule">Type rule.</typeparam>
        /// <typeparam name="TWantAction">Type wantAction.</typeparam>
        /// <typeparam name="TFactContainer">Type fact container.</typeparam>
        /// <param name="rule">Fact rule.</param>
        /// <param name="rules">Fact rules.</param>
        /// <param name="context">Context.</param>
        /// <returns>Related fact rules.</returns>
        private IFactRuleCollection<TFactRule> GetRelatedRules<TFactRule, TWantAction, TFactContainer>(TFactRule rule, IFactRuleCollection<TFactRule> rules, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return rules.FindAll(r => !r.EqualsWork(rule, context.WantAction, context.Container));
        }
    }
}
