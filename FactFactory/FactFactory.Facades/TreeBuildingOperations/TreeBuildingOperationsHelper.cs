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
        /// Get <see cref="TreeByFactRule{TFactRule, TWantAction}"/> by <paramref name="request"/>.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static List<TreeByFactRule<TFactRule, TWantAction>> GetTreesByRequest<TFactRule, TWantAction>(
            this BuildTreeForFactInfoRequest<TFactRule, TWantAction> request)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
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

            var nodeInfos = needRules.ConvertAll(rule => new NodeByFactRuleInfo<TFactRule>
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
                var node = new NodeByFactRule<TFactRule>
                {
                    Childs = new List<NodeByFactRule<TFactRule>>(),
                    Info = info,
                };

                var tree = new TreeByFactRule<TFactRule, TWantAction>
                {
                    Levels = new List<List<NodeByFactRule<TFactRule>>>
                    {
                        new List<NodeByFactRule<TFactRule>> { node },
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

        internal static Dictionary<NodeByFactRuleInfo<TFactRule>, NodeByFactRule<TFactRule>> GetCompatibleFinishedNodes<TFactRule, TWantAction>(
            this NodeByFactRuleInfo<TFactRule> nodeInfo,
            Dictionary<NodeByFactRuleInfo<TFactRule>,
            NodeByFactRule<TFactRule>> finishedNodes,
            IWantActionContext<TWantAction> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
        {
            return finishedNodes
                .Where(finishedNode => context.SingleEntity.CompatibleRule(nodeInfo.Rule, finishedNode.Key.Rule, context))
                .ToDictionary(finishedNode => finishedNode.Key, finishedNode => finishedNode.Value);
        }

        internal static IFactRuleCollection<TFactRule> GetCompatibleRulesEx<TFactWork, TFactRule, TWantAction>(
            this TFactWork target, IFactRuleCollection<TFactRule> rules, IWantActionContext<TWantAction> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
        {
            return context.SingleEntity.GetCompatibleRules(target, rules, context);
        }

        /// <summary>
        /// Whether the <paramref name="rule"/> is contained in a branch with <paramref name="nodeFromBranch"/>.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <param name="rule"></param>
        /// <param name="nodeFromBranch"></param>
        /// <returns></returns>
        internal static bool RuleContainBranch<TFactRule>(this TFactRule rule, NodeByFactRule<TFactRule> nodeFromBranch) 
            where TFactRule : IFactRule
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
        /// <typeparam name="TFactRule">FatcRule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <param name="rules">List of rule.</param>
        /// <param name="treeByFactRule">Rule tree.</param>
        /// <param name="parentNode">Parent node.</param>
        /// <returns>Node list.</returns>
        public static List<NodeByFactRule<TFactRule>> GetNodesByRules<TFactRule, TWantAction>(
            this IEnumerable<TFactRule> rules, NodeByFactRule<TFactRule> parentNode,
            TreeByFactRule<TFactRule, TWantAction> treeByFactRule)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
        {
            var context = treeByFactRule.Context;
            var result = new List<NodeByFactRule<TFactRule>>();

            foreach (var rule in rules)
            {
                NodeByFactRuleInfo<TFactRule> nodeInfo = treeByFactRule.NodeInfos.FirstOrDefault(nInfo => nInfo.Rule.EqualsWork(rule, context.WantAction, context.Container));

                if (nodeInfo == null)
                    nodeInfo = new NodeByFactRuleInfo<TFactRule>
                    {
                        Rule = rule,
                        BuildSuccessConditions = new List<IBuildConditionFact>(rule.InputFactTypes.Count(type => type.IsFactType<IBuildConditionFact>())),
                        BuildFailedConditions = new List<IBuildConditionFact>(),
                        RuntimeConditions = new List<IRuntimeConditionFact>(rule.InputFactTypes.Count(type => type.IsFactType<IRuntimeConditionFact>())),
                        RequiredFactTypes = context.SingleEntity.GetRequiredTypesOfFacts(rule, context).ToList(),
                        CompatibleRules = rule.GetCompatibleRulesEx(context.FactRules, context),
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

        private static void FillUniqueRulesFromTree<TFactRule>(NodeByFactRule<TFactRule> node, HashSet<TFactRule> eniqueRules)
            where TFactRule : IFactRule
        {
            foreach (var child in node.Childs)
                FillUniqueRulesFromTree(child, eniqueRules);

            if (!eniqueRules.Contains(node.Info.Rule))
                eniqueRules.Add(node.Info.Rule);
        }

        /// <summary>
        /// Get unique rules from tree.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <param name="treeByFactRule"></param>
        /// <returns></returns>
        internal static HashSet<TFactRule> GetUniqueRulesFromTree<TFactRule, TWantAction>(this TreeByFactRule<TFactRule, TWantAction> treeByFactRule)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
        {
            var result = new HashSet<TFactRule>();
            FillUniqueRulesFromTree(treeByFactRule.Root, result);
            return result;
        }

        internal static NodeByFactRule<TFactRule> Copy<TFactRule>(this NodeByFactRule<TFactRule> node, NodeByFactRule<TFactRule> newParent)
            where TFactRule : IFactRule
        {
            return new NodeByFactRule<TFactRule>
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
