using GetcuReone.ComboPatterns.Facade;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Entities.Trees;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;
using System.Linq;
using CommonHelper = GetcuReone.FactFactory.FactFactoryCommonHelper;

namespace GetcuReone.FactFactory.Facades.TreesOperations
{
    /// <summary>
    /// Facade for trees operations.
    /// </summary>
    public sealed class TreesOperationsFacade : FacadeBase
    {
        private void FillNodeRulesFromTree<TFactRule>(NodeByFactRule<TFactRule> node, List<NodeByFactRule<TFactRule>> rules)
            where TFactRule : FactRuleBase
        {
            foreach (var child in node.Childs)
                FillNodeRulesFromTree(child, rules);

            rules.Add(node);
        }

        private void FillUniqueRulesFromTree<TFactRule>(NodeByFactRule<TFactRule> node, HashSet<TFactRule> eniqueRules)
            where TFactRule : FactRuleBase
        {
            foreach (var child in node.Childs)
                FillUniqueRulesFromTree(child, eniqueRules);

            if (!eniqueRules.Contains(node.Info.Rule))
                eniqueRules.Add(node.Info.Rule);
        }

        /// <summary>
        /// Get <see cref="TreeByFactRule{TFactRule, TWantAction, TFactContainer}"/> by <paramref name="request"/>.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> GetTreesByBuildTreeRequest<TFactRule, TWantAction, TFactContainer>(BuildTreeForFactTypeRequest<TFactRule, TWantAction, TFactContainer> request)
            where TFactRule : FactRuleBase
            where TWantAction : WantActionBase
            where TFactContainer : FactContainerBase
        {
            if (request.FactRules.IsNullOrEmpty())
                throw CommonHelper.CreateDeriveException(ErrorCode.EmptyRuleCollection, "Rules cannot be null.");

            var needRules = request.FactRules.FindAll(rule => rule.OutputFactType.EqualsFactType(request.WantFactType));

            if (needRules.IsNullOrEmpty())
                throw CommonHelper.CreateDeriveException(ErrorCode.RuleNotFound, $"No rules found able to calculate fact {request.WantFactType.FactName}.");

            var nodeInfos = needRules.ConvertAll(rule => new NodeInfoByFactRyle<TFactRule>
            {
                SuccessConditions = new List<IConditionFact>(),
                FailedConditions = new List<IConditionFact>(),
                FactRules = request.FactRules.FindAll(r => rule.СompatibilityWithRule(r, request.WantActionInfo.WantAction, request.WantActionInfo.Container)),
                Rule = rule,
            });

            return nodeInfos.ConvertAll(info => 
            {
                var node = new NodeByFactRule<TFactRule>
                {
                    Childs = new List<NodeByFactRule<TFactRule>>(),
                    Info = info,
                };

                var tree = new TreeByFactRule<TFactRule, TWantAction, TFactContainer>
                {
                    Levels = new List<List<NodeByFactRule<TFactRule>>>
                    {
                        new List<NodeByFactRule<TFactRule>> { node },
                    },
                    NodeInfos = nodeInfos,
                    Root = node,
                    WantActionInfo = request.WantActionInfo,
                };

                if (info.Rule.CanCalculate(request.WantActionInfo.Container, request.WantActionInfo.WantAction))
                    tree.Built();

                return tree;
            });
        }

        /// <summary>
        /// Synchronize the tree level with years ready for calculation.
        /// </summary>

        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="treeLevel">Tree level.</param>
        /// <param name="finishedNodes">Nodes by which the rule can already be calculated. Key - node info, value - node</param>
        /// <param name="wantAction">Action within which synchronization occurs.</param>
        /// <param name="container">Fact container.</param>
        public void SyncTreeLevelAndFinishedNodes<TFactRule, TWantAction, TFactContainer>(List<NodeByFactRule<TFactRule>> treeLevel, Dictionary<NodeInfoByFactRyle<TFactRule>, NodeByFactRule<TFactRule>> finishedNodes, TWantAction wantAction, TFactContainer container)

            where TFactRule : FactRuleBase
            where TWantAction : WantActionBase
            where TFactContainer : FactContainerBase
        {
            foreach(var finishedNode in finishedNodes)
            {
                List<NodeByFactRule<TFactRule>> parentNodes = treeLevel
                    .Where(node => node.Info.Rule.EqualsWork(finishedNode.Key.Rule, wantAction, container))
                    .Select(node => node.Parent)
                    .Distinct()
                    .ToList();

                foreach(NodeByFactRule<TFactRule> parentNode in parentNodes)
                {
                    if (parentNode == null)
                        continue;

                    for(int i = parentNode.Childs.Count - 1; i >= 0; i--)
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
        public bool TrySyncTreeLevelsAndFinishedNodes<TFactRule, TWantAction, TFactContainer>(TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeByFactRule, int level, Dictionary<NodeInfoByFactRyle<TFactRule>, NodeByFactRule<TFactRule>> finishedNodes)
            where TFactRule : FactRuleBase
            where TWantAction : WantActionBase
            where TFactContainer : FactContainerBase
        {
            if (level < 0)
                return true;

            List<NodeByFactRule<TFactRule>> currentLevel = treeByFactRule.Levels[level];
            var finishedNodesInCurrentLevel = new Dictionary<NodeInfoByFactRyle<TFactRule>, NodeByFactRule<TFactRule>>();
            WantActionInfo<TWantAction, TFactContainer> wantActionInfo = treeByFactRule.WantActionInfo;

            foreach (var node in currentLevel)
            {
                var rule = node.Info.Rule;
                var copabilitiesFinishedRules = finishedNodes
                    .Where(finishedNode => rule.СompatibilityWithRule(finishedNode.Key.Rule, wantActionInfo.WantAction, wantActionInfo.Container))
                    .Select(finishedNode => finishedNode.Key.Rule)
                    .ToList();

                if (rule.InputFactTypes.Count > 0 && rule.InputFactTypes.All(f => copabilitiesFinishedRules.Any(r => r.OutputFactType.EqualsFactType(f))))
                    finishedNodesInCurrentLevel.Add(node.Info, node);
                else if (copabilitiesFinishedRules.Any(r => r.EqualsWork(rule, wantActionInfo.WantAction, wantActionInfo.Container)))
                    finishedNodesInCurrentLevel.Add(node.Info, node);
            }

            if (finishedNodesInCurrentLevel.IsNullOrEmpty())
                return false;

            SyncTreeLevelAndFinishedNodes(currentLevel, finishedNodesInCurrentLevel, wantActionInfo.WantAction, wantActionInfo.Container);

            foreach(var finishedNode in finishedNodesInCurrentLevel)
            {
                if (finishedNodes.Keys.Any(nodeInfo => nodeInfo.Rule.EqualsWork(finishedNode.Key.Rule, wantActionInfo.WantAction, wantActionInfo.Container)))
                    continue;
                finishedNodes.Add(finishedNode.Key, finishedNode.Value);
            }
            return TrySyncTreeLevelsAndFinishedNodes(treeByFactRule, level - 1, finishedNodes);
        }

        /// <summary>
        /// Whether the <paramref name="rule"/> is contained in a branch with <paramref name="node"/>.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <param name="node"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public bool RuleContainBranch<TFactRule>(NodeByFactRule<TFactRule> node, TFactRule rule)
            where TFactRule : FactRuleBase
        {
            if (rule == null && node.Info.Rule == null)
                return true;
            else if (rule == null || node.Info.Rule == null)
                return false;
            else if (rule.Equals(node.Info.Rule))
                return true;

            else if (node.Parent != null)
                return RuleContainBranch(node.Parent, rule);

            return false;
        }

        /// <summary>
        /// Get nodes by rules.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="rules"></param>
        /// <param name="treeByFactRule"></param>
        /// <param name="parentNode"></param>
        /// <param name="allRulesForWantAction"></param>
        /// <returns></returns>
        public List<NodeByFactRule<TFactRule>> GetNodesByRules<TFactRule, TWantAction, TFactContainer>(List<TFactRule> rules, TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeByFactRule, NodeByFactRule<TFactRule> parentNode, List<TFactRule> allRulesForWantAction)
            where TFactRule : FactRuleBase
            where TWantAction : WantActionBase
            where TFactContainer : FactContainerBase
        {
            var result = new List<NodeByFactRule<TFactRule>>();
            WantActionInfo<TWantAction, TFactContainer> wantActionInfo = treeByFactRule.WantActionInfo;

            foreach (var rule in rules)
            {
                NodeInfoByFactRyle<TFactRule> nodeInfo = treeByFactRule.NodeInfos.FirstOrDefault(nInfo => nInfo.Rule == rule);

                if (nodeInfo == null)
                    nodeInfo = new NodeInfoByFactRyle<TFactRule>
                    {
                        Rule = rule,
                        SuccessConditions = new List<IConditionFact>(),
                        FailedConditions = new List<IConditionFact>(),
                        FactRules = allRulesForWantAction.FindAll(r => rule.СompatibilityWithRule(r, wantActionInfo.WantAction, wantActionInfo.Container)),
                    };

                result.Add(new NodeByFactRule<TFactRule>
                {
                    Childs = new List<NodeByFactRule<TFactRule>>(),
                    Info = nodeInfo,
                    Parent = parentNode,
                });
            }

            return result;
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
        public bool TryRemoveRootNode<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeByFactRule, int level)
            where TFactRule : FactRuleBase
            where TWantAction : WantActionBase
            where TFactContainer : FactContainerBase
        {
            if (level == 0)
            {
                treeByFactRule.Levels[level].Remove(node);
                return true;
            }

            treeByFactRule.Levels[level].Remove(node);
            NodeByFactRule<TFactRule> parent = node.Parent;
            parent.Childs.Remove(node);

            // If the node has a child node that can calculate this fact
            if (parent.Childs.Any(n => n.Info.Rule.OutputFactType.EqualsFactType(node.Info.Rule.OutputFactType)))
                return false;
            else
                return TryRemoveRootNode(parent, treeByFactRule, level - 1);
        }

        /// <summary>
        /// Get unique rules from tree.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="treeByFactRule"></param>
        /// <returns></returns>
        public HashSet<TFactRule> GetUniqueRulesFromTree<TFactRule, TWantAction, TFactContainer>(TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeByFactRule)
            where TFactRule : FactRuleBase
            where TWantAction : WantActionBase
            where TFactContainer : FactContainerBase
        {
            var result = new HashSet<TFactRule>();
            FillUniqueRulesFromTree(treeByFactRule.Root, result);
            return result;
        }

        /// <summary>
        /// Get independent rule groups.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="treeByFactRule"></param>
        public List<IndependentRulesGroup<TFactRule>> GetIndependentRulesGroups<TFactRule, TWantAction, TFactContainer>(TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeByFactRule)

            where TFactRule : FactRuleBase

            where TWantAction : WantActionBase
            where TFactContainer : FactContainerBase
        {
            var allNodes = new List<NodeByFactRule<TFactRule>>();
            FillNodeRulesFromTree(treeByFactRule.Root, allNodes);

            var group = new IndependentRulesGroup<TFactRule>();
            var result = new List<IndependentRulesGroup<TFactRule>> { group };

            foreach (NodeByFactRule<TFactRule> node in allNodes)
            {
                bool needIcludeGroup = false;
                var rule = node.Info.Rule;

                if (rule.InputFactTypes.IsNullOrEmpty())
                {
                    needIcludeGroup = !group.Exists(nodeGroup => rule.OutputFactType.EqualsFactType(nodeGroup.Info.Rule.OutputFactType));
                }
                else
                {
                    var notConditionInputFacts = rule.InputFactTypes.Where(factType => !factType.IsFactType<IConditionFact>());
                    needIcludeGroup = !notConditionInputFacts.Any(factType => group.Any(nodeGroup => factType.EqualsFactType(nodeGroup.Info.Rule.OutputFactType)));
                }

                if (needIcludeGroup)
                    group.Add(node);
                else
                {
                    group = new IndependentRulesGroup<TFactRule> { node };
                    result.Add(group);
                }
            }

            return result;
        }
    }
}
