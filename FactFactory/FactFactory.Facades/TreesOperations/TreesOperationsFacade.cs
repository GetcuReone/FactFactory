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
        private void FillNodeRulesFromTree<TFactBase, TFactRule>(NodeByFactRule<TFactBase, TFactRule> node, List<NodeByFactRule<TFactBase, TFactRule>> rules)
            where TFactBase : IFact
            where TFactRule : FactRuleBase<TFactBase>
        {
            foreach (var child in node.Childs)
                FillNodeRulesFromTree(child, rules);

            rules.Add(node);
        }

        private void FillUniqueRulesFromTree<TFactBase, TFactRule>(NodeByFactRule<TFactBase, TFactRule> node, HashSet<TFactRule> eniqueRules)
            where TFactBase : IFact
            where TFactRule : FactRuleBase<TFactBase>
        {
            foreach (var child in node.Childs)
                FillUniqueRulesFromTree(child, eniqueRules);

            if (!eniqueRules.Contains(node.Info.Rule))
                eniqueRules.Add(node.Info.Rule);
        }

        /// <summary>
        /// Get <see cref="TreeByFactRule{TFactBase, TFactRule}"/> by <paramref name="request"/>.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<TreeByFactRule<TFactBase, TFactRule, TWantAction, TFactContainer>> GetTreesByBuildTreeRequest<TFactBase, TFactRule, TWantAction, TFactContainer>(BuildTreeForFactTypeRequest<TFactBase, TFactRule, TWantAction, TFactContainer> request)
            where TFactBase : IFact
            where TFactRule : FactRuleBase<TFactBase>
            where TWantAction : WantActionBase<TFactBase>
            where TFactContainer : FactContainerBase<TFactBase>
        {
            if (request.FactRules.IsNullOrEmpty())
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.EmptyRuleCollection, "Rules cannot be null.");

            var needRules = request.FactRules.FindAll(rule => rule.OutputFactType.EqualsFactType(request.WantFactType));

            if (needRules.IsNullOrEmpty())
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.RuleNotFound, $"No rules found able to calculate fact {request.WantFactType.FactName}.");

            var nodeInfos = needRules.ConvertAll(rule => new NodeInfoByFactRyle<TFactBase, TFactRule>
            {
                SuccessConditions = new List<IConditionFact>(),
                FailedConditions = new List<IConditionFact>(),
                FactRules = request.FactRules.FindAll(r => rule.СompatibilityWithRule(r, request.WantAction, request.Container)),
                Rule = rule,
            });

            return nodeInfos.ConvertAll(info => 
            {
                var node = new NodeByFactRule<TFactBase, TFactRule>
                {
                    Childs = new List<NodeByFactRule<TFactBase, TFactRule>>(),
                    Info = info,
                };

                var tree = new TreeByFactRule<TFactBase, TFactRule, TWantAction, TFactContainer>
                {
                    Levels = new List<List<NodeByFactRule<TFactBase, TFactRule>>>
                    {
                        new List<NodeByFactRule<TFactBase, TFactRule>> { node },
                    },
                    NodeInfos = nodeInfos,
                    Root = node,
                    Container = request.Container,
                    WantAction = request.WantAction,
                };

                if (info.Rule.CanCalculate(request.Container, request.WantAction))
                    tree.Built();

                return tree;
            });
        }

        /// <summary>
        /// Synchronize the tree level with years ready for calculation.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="treeLevel">Tree level.</param>
        /// <param name="finishedNodes">Nodes by which the rule can already be calculated. Key - node info, value - node</param>
        /// <param name="wantAction">Action within which synchronization occurs.</param>
        /// <param name="container">Fact container.</param>
        public void SyncTreeLevelAndFinishedNodes<TFactBase, TFactRule, TWantAction, TFactContainer>(List<NodeByFactRule<TFactBase, TFactRule>> treeLevel, Dictionary<NodeInfoByFactRyle<TFactBase, TFactRule>, NodeByFactRule<TFactBase, TFactRule>> finishedNodes, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactRule : FactRuleBase<TFactBase>
            where TWantAction : WantActionBase<TFactBase>
            where TFactContainer : FactContainerBase<TFactBase>
        {
            foreach(var finishedNode in finishedNodes)
            {
                List<NodeByFactRule<TFactBase, TFactRule>> parentNodes = treeLevel
                    .Where(node => node.Info.Rule.EqualsWork(finishedNode.Key.Rule, wantAction, container))
                    .Select(node => node.Parent)
                    .Distinct()
                    .ToList();

                foreach(NodeByFactRule<TFactBase, TFactRule> parentNode in parentNodes)
                {
                    if (parentNode == null)
                        continue;

                    for(int i = parentNode.Childs.Count - 1; i >= 0; i--)
                    {
                        NodeByFactRule<TFactBase, TFactRule> childNode = parentNode.Childs[i];
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
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="treeByFactRule">Tree whose levels you want to synchronize.</param>
        /// <param name="level">The level at which to start synchronization.</param>
        /// <param name="finishedNodes"></param>
        /// <returns>True - managed to sync root level</returns>
        public bool TrySyncTreeLevelsAndFinishedNodes<TFactBase, TFactRule, TWantAction, TFactContainer>(TreeByFactRule<TFactBase, TFactRule, TWantAction, TFactContainer> treeByFactRule, int level, Dictionary<NodeInfoByFactRyle<TFactBase, TFactRule>, NodeByFactRule<TFactBase, TFactRule>> finishedNodes)
            where TFactBase : IFact
            where TFactRule : FactRuleBase<TFactBase>
            where TWantAction : WantActionBase<TFactBase>
            where TFactContainer : FactContainerBase<TFactBase>
        {
            if (level < 0)
                return true;

            List<NodeByFactRule<TFactBase, TFactRule>> currentLevel = treeByFactRule.Levels[level];
            var finishedNodesInCurrentLevel = new Dictionary<NodeInfoByFactRyle<TFactBase, TFactRule>, NodeByFactRule<TFactBase, TFactRule>>();

            foreach(var node in currentLevel)
            {
                var rule = node.Info.Rule;
                var copabilitiesFinishedRules = finishedNodes
                    .Where(finishedNode => rule.СompatibilityWithRule(finishedNode.Key.Rule, treeByFactRule.WantAction, treeByFactRule.Container))
                    .Select(finishedNode => finishedNode.Key.Rule)
                    .ToList();

                if (rule.InputFactTypes.Count > 0 && rule.InputFactTypes.All(f => copabilitiesFinishedRules.Any(r => r.OutputFactType.EqualsFactType(f))))
                    finishedNodesInCurrentLevel.Add(node.Info, node);
                else if (copabilitiesFinishedRules.Any(r => r.EqualsWork(rule, treeByFactRule.WantAction, treeByFactRule.Container)))
                    finishedNodesInCurrentLevel.Add(node.Info, node);
            }

            if (finishedNodesInCurrentLevel.IsNullOrEmpty())
                return false;

            SyncTreeLevelAndFinishedNodes(currentLevel, finishedNodesInCurrentLevel, treeByFactRule.WantAction, treeByFactRule.Container);

            foreach(var finishedNode in finishedNodesInCurrentLevel)
            {
                if (finishedNodes.Keys.Any(nodeInfo => nodeInfo.Rule.EqualsWork(finishedNode.Key.Rule, treeByFactRule.WantAction, treeByFactRule.Container)))
                    continue;
                finishedNodes.Add(finishedNode.Key, finishedNode.Value);
            }
            return TrySyncTreeLevelsAndFinishedNodes(treeByFactRule, level - 1, finishedNodes);
        }

        /// <summary>
        /// Whether the <paramref name="rule"/> is contained in a branch with <paramref name="node"/>.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactRule"></typeparam>
        /// <param name="node"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public bool RuleContainBranch<TFactBase, TFactRule>(NodeByFactRule<TFactBase, TFactRule> node, TFactRule rule)
            where TFactBase : IFact
            where TFactRule : FactRuleBase<TFactBase>
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
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="rules"></param>
        /// <param name="treeByFactRule"></param>
        /// <param name="parentNode"></param>
        /// <param name="allRulesForWantAction"></param>
        /// <returns></returns>
        public List<NodeByFactRule<TFactBase, TFactRule>> GetNodesByRules<TFactBase, TFactRule, TWantAction, TFactContainer>(List<TFactRule> rules, TreeByFactRule<TFactBase, TFactRule, TWantAction, TFactContainer> treeByFactRule, NodeByFactRule<TFactBase, TFactRule> parentNode, List<TFactRule> allRulesForWantAction)
            where TFactBase : IFact
            where TFactRule : FactRuleBase<TFactBase>
            where TWantAction : WantActionBase<TFactBase>
            where TFactContainer : FactContainerBase<TFactBase>
        {
            var result = new List<NodeByFactRule<TFactBase, TFactRule>>();

            foreach(var rule in rules)
            {
                NodeInfoByFactRyle<TFactBase, TFactRule> nodeInfo = treeByFactRule.NodeInfos.FirstOrDefault(nInfo => nInfo.Rule == rule);

                if (nodeInfo == null)
                    nodeInfo = new NodeInfoByFactRyle<TFactBase, TFactRule>
                    {
                        Rule = rule,
                        SuccessConditions = new List<IConditionFact>(),
                        FailedConditions = new List<IConditionFact>(),
                        FactRules = allRulesForWantAction.FindAll(r => rule.СompatibilityWithRule(r, treeByFactRule.WantAction, treeByFactRule.Container)),
                    };

                result.Add(new NodeByFactRule<TFactBase, TFactRule>
                {
                    Childs = new List<NodeByFactRule<TFactBase, TFactRule>>(),
                    Info = nodeInfo,
                    Parent = parentNode,
                });
            }

            return result;
        }

        /// <summary>
        /// Delete current node. Recursively delete parent nodes if they do not have other nodes calculating the fact from the child node.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="node"></param>
        /// <param name="treeByFactRule"></param>
        /// <param name="level"></param>
        /// <returns>True - remove root node.</returns>
        public bool TryRemoveRootNode<TFactBase, TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactBase, TFactRule> node, TreeByFactRule<TFactBase, TFactRule, TWantAction, TFactContainer> treeByFactRule, int level)
            where TFactBase : IFact
            where TFactRule : FactRuleBase<TFactBase>
            where TWantAction : WantActionBase<TFactBase>
            where TFactContainer : FactContainerBase<TFactBase>
        {
            if (level == 0)
            {
                treeByFactRule.Levels[level].Remove(node);
                return true;
            }

            treeByFactRule.Levels[level].Remove(node);
            NodeByFactRule<TFactBase, TFactRule> parent = node.Parent;
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
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="treeByFactRule"></param>
        /// <returns></returns>
        public HashSet<TFactRule> GetUniqueRulesFromTree<TFactBase, TFactRule, TWantAction, TFactContainer>(TreeByFactRule<TFactBase, TFactRule, TWantAction, TFactContainer> treeByFactRule)
            where TFactBase : IFact
            where TFactRule : FactRuleBase<TFactBase>
            where TWantAction : WantActionBase<TFactBase>
            where TFactContainer : FactContainerBase<TFactBase>
        {
            var result = new HashSet<TFactRule>();
            FillUniqueRulesFromTree(treeByFactRule.Root, result);
            return result;
        }

        /// <summary>
        /// Get independent rule groups.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="treeByFactRule"></param>
        public List<IndependentRulesGroup<TFactBase, TFactRule>> GetIndependentRulesGroups<TFactBase, TFactRule, TWantAction, TFactContainer>(TreeByFactRule<TFactBase, TFactRule, TWantAction, TFactContainer> treeByFactRule)
            where TFactBase : IFact
            where TFactRule : FactRuleBase<TFactBase>

            where TWantAction : WantActionBase<TFactBase>
            where TFactContainer : FactContainerBase<TFactBase>
        {
            var allNodes = new List<NodeByFactRule<TFactBase, TFactRule>>();
            FillNodeRulesFromTree(treeByFactRule.Root, allNodes);

            var group = new IndependentRulesGroup<TFactBase, TFactRule>();
            var result = new List<IndependentRulesGroup<TFactBase, TFactRule>> { group };

            foreach (NodeByFactRule<TFactBase, TFactRule> node in allNodes)
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
                    group = new IndependentRulesGroup<TFactBase, TFactRule> { node };
                    result.Add(group);
                }
            }

            return result;
        }
    }
}
