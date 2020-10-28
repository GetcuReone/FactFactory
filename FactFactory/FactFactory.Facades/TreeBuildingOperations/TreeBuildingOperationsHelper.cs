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
        /// Get <see cref="TreeByFactRule{TFactRule, TWantAction, TFactContainer}"/> by <paramref name="request"/>.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> GetTreesByRequest<TFactRule, TWantAction, TFactContainer>(this BuildTreeForFactInfoRequest<TFactRule, TWantAction, TFactContainer> request)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
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
                SuccessConditions = new List<IConditionFact>(),
                FailedConditions = new List<IConditionFact>(),
                Rule = rule,
                RequiredFactTypes = context.SingleEntity.GetRequiredTypesOfFacts(rule, context).ToList()
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
                    Context = context,
                };

                if (info.RequiredFactTypes.Count == 0)
                    tree.Built();

                return tree;
            });
        }

        internal static Dictionary<NodeByFactRuleInfo<TFactRule>, NodeByFactRule<TFactRule>> GetCompatibleFinishedNodes<TFactRule, TWantAction, TFactContainer>(this NodeByFactRuleInfo<TFactRule> nodeInfo, Dictionary<NodeByFactRuleInfo<TFactRule>, NodeByFactRule<TFactRule>> finishedNodes, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return finishedNodes
                .Where(finishedNode => context.SingleEntity.CompatibleRule(nodeInfo.Rule, finishedNode.Key.Rule, context))
                .ToDictionary(finishedNode => finishedNode.Key, finishedNode => finishedNode.Value);
        }

        internal static IEnumerable<TFactRule> GetCompatibleRulesEx<TFactWork, TFactRule, TWantAction, TFactContainer>(this TFactWork target, IEnumerable<TFactRule> rules, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
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
        /// Get nodes by rules.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="rules"></param>
        /// <param name="treeByFactRule"></param>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        public static List<NodeByFactRule<TFactRule>> GetNodesByRules<TFactRule, TWantAction, TFactContainer>(this List<TFactRule> rules, NodeByFactRule<TFactRule> parentNode, TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeByFactRule)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
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
                        SuccessConditions = new List<IConditionFact>(),
                        FailedConditions = new List<IConditionFact>(),
                        RequiredFactTypes = context.SingleEntity.GetRequiredTypesOfFacts(rule, context).ToList(),
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
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="treeByFactRule"></param>
        /// <returns></returns>
        internal static HashSet<TFactRule> GetUniqueRulesFromTree<TFactRule, TWantAction, TFactContainer>(this TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeByFactRule)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
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
