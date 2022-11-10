using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

namespace GetcuReone.FactFactory.Facades.TreeBuildingOperations
{
    internal static class TreeBuildingOperationsHelper
    {
        /// <summary>
        /// Get <see cref="TreeByFactRule"/> by <paramref name="request"/>.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static List<TreeByFactRule> GetTreesByRequest(this BuildTreeForFactInfoRequest request)
        {
            var context = request.Context;
            var factRules = request.Context.FactRules;
            if (factRules.IsNullOrEmpty())
                throw CommonHelper.CreateDeriveException(ErrorCode.EmptyRuleCollection, "Rules cannot be null.");

            var needRules = factRules
                .Where(rule => rule.OutputFactType.EqualsFactType(request.WantFactType))
                .ToList();

            if (needRules.IsNullOrEmpty())
                throw CommonHelper.CreateDeriveException(ErrorCode.RuleNotFound, $"No rules found able to calculate fact {request.WantFactType.FactName}.");

            var nodeInfos = needRules.ConvertAll(rule => new NodeByFactRuleInfo
            {
                BuildSuccessConditions = new List<IBuildConditionFact>(rule.InputFactTypes.Count(type => type.IsFactType<IBuildConditionFact>())),
                BuildFailedConditions = new List<IBuildConditionFact>(),
                RuntimeConditions = new List<IRuntimeConditionFact>(rule.InputFactTypes.Count(type => type.IsFactType<IRuntimeConditionFact>())),
                Rule = rule,
                RequiredFactTypes = context.SingleEntity.GetRequiredTypesOfFacts(rule, context).ToList(),
                CompatibleRules = rule.GetCompatibleRulesEx(context.FactRules, context),
            });

            return nodeInfos.ConvertAll(info =>
            {
                var node = new NodeByFactRule
                {
                    Childs = new List<NodeByFactRule>(),
                    Info = info,
                };

                var tree = new TreeByFactRule
                {
                    Levels = new List<List<NodeByFactRule>>
                    {
                        new List<NodeByFactRule> { node },
                    },
                    NodeInfos = nodeInfos,
                    Root = node,
                    Context = context,
                };

                if (info.RequiredFactTypes.Count == 0)
                    tree.Built();

                return tree;
            });
        }

        internal static Dictionary<NodeByFactRuleInfo, NodeByFactRule> GetCompatibleFinishedNodes(
            this NodeByFactRuleInfo nodeInfo,
            Dictionary<NodeByFactRuleInfo,
            NodeByFactRule> finishedNodes,
            IWantActionContext context)
        {
            return finishedNodes
                .Where(finishedNode => context.SingleEntity.CompatibleRule(nodeInfo.Rule, finishedNode.Key.Rule, context))
                .ToDictionary(finishedNode => finishedNode.Key, finishedNode => finishedNode.Value);
        }

        internal static IFactRuleCollection GetCompatibleRulesEx<TFactWork>(
            this TFactWork target,
            IFactRuleCollection rules,
            IWantActionContext context)
            where TFactWork : IFactWork
        {
            return context.SingleEntity.GetCompatibleRules(target, rules, context);
        }

        /// <summary>
        /// Whether the <paramref name="rule"/> is contained in a branch with <paramref name="nodeFromBranch"/>.
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="nodeFromBranch"></param>
        /// <returns></returns>
        internal static bool RuleContainBranch(this IFactRule rule, NodeByFactRule nodeFromBranch)
        {
            if (rule == null && nodeFromBranch.Info.Rule == null)
                return true;
            else if (rule == null || nodeFromBranch.Info.Rule == null)
                return false;
            else if (rule.Equals(nodeFromBranch.Info.Rule))
                return true;

            else if (nodeFromBranch.Parent != null)
                return rule.RuleContainBranch(nodeFromBranch.Parent);

            return false;
        }

        /// <summary>
        /// Returns nodes by rules.
        /// </summary>
        /// <param name="rules">List of rule.</param>
        /// <param name="treeByFactRule">Rule tree.</param>
        /// <param name="parentNode">Parent node.</param>
        /// <returns>Node list.</returns>
        public static List<NodeByFactRule> GetNodesByRules(
            this IEnumerable<IFactRule> rules,
            NodeByFactRule parentNode,
            TreeByFactRule treeByFactRule)
        {
            var context = treeByFactRule.Context;
            var result = new List<NodeByFactRule>();

            foreach (var rule in rules)
            {
                NodeByFactRuleInfo nodeInfo = treeByFactRule.NodeInfos.FirstOrDefault(nInfo => nInfo.Rule.EqualsWork(rule, context.WantAction, context.Container));

                if (nodeInfo == null)
                    nodeInfo = new NodeByFactRuleInfo
                    {
                        Rule = rule,
                        BuildSuccessConditions = new List<IBuildConditionFact>(rule.InputFactTypes.Count(type => type.IsFactType<IBuildConditionFact>())),
                        BuildFailedConditions = new List<IBuildConditionFact>(),
                        RuntimeConditions = new List<IRuntimeConditionFact>(rule.InputFactTypes.Count(type => type.IsFactType<IRuntimeConditionFact>())),
                        RequiredFactTypes = context.SingleEntity.GetRequiredTypesOfFacts(rule, context).ToList(),
                        CompatibleRules = rule.GetCompatibleRulesEx(context.FactRules, context),
                    };

                result.Add(new NodeByFactRule
                {
                    Childs = new List<NodeByFactRule>(),
                    Info = nodeInfo,
                    Parent = parentNode,
                });
            }

            return result;
        }

        private static void FillUniqueRulesFromTree(NodeByFactRule node, HashSet<IFactRule> eniqueRules)
        {
            foreach (var child in node.Childs)
                FillUniqueRulesFromTree(child, eniqueRules);

            if (!eniqueRules.Contains(node.Info.Rule))
                eniqueRules.Add(node.Info.Rule);
        }

        /// <summary>
        /// Get unique rules from tree.
        /// </summary>
        /// <param name="treeByFactRule"></param>
        /// <returns></returns>
        internal static HashSet<IFactRule> GetUniqueRulesFromTree(this TreeByFactRule treeByFactRule)
        {
            var result = new HashSet<IFactRule>();

            FillUniqueRulesFromTree(treeByFactRule.Root, result);

            return result;
        }

        internal static NodeByFactRule Copy(this NodeByFactRule node, NodeByFactRule newParent)
        {
            return new NodeByFactRule
            {
                Childs = node.Childs,
                Info = node.Info,
                Parent = newParent,
            };
        }

        internal static async ValueTask<IReadOnlyCollection<TResult>> WhenAll<TResult>(this IEnumerable<ValueTask<TResult>> tasks)
        {
            var result = new List<TResult>(tasks.Count());
            var toAwait = new List<Task<TResult>>();

            foreach (var valueTask in tasks)
            {
                if (valueTask.IsCompletedSuccessfully)
                    result.Add(valueTask.Result);
                else
                    toAwait.Add(valueTask.AsTask());
            }

            result.AddRange(await Task.WhenAll(toAwait).ConfigureAwait(false));

            return result;
        }
    }
}
