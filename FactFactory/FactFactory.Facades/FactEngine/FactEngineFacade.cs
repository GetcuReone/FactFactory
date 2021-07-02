using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetcuReone.ComboPatterns.Facade;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Resources;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

namespace GetcuReone.FactFactory.Facades.FactEngine
{
    /// <inheritdoc cref="IFactEngine"/>
    public class FactEngineFacade : FacadeBase, IFactEngine
    {
        /// <inheritdoc/>
        public virtual void DeriveWantAction<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>(List<DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>> requests)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            Validate(requests);

            var treesByActions = new Dictionary<WantActionInfo<TWantAction, TFactContainer>, List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>>>();
            var deriveErrorDetails = new List<DeriveErrorDetail>();


            foreach(DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> request in requests)
            {
                var context = request.Context;

                if (!context.WantAction.Option.HasFlag(FactWorkOption.CanExecuteSync))
                {
                    deriveErrorDetails.Add(new DeriveErrorDetail(
                        ErrorCode.InvalidOperation,
                        ErrorResources.OnWantActionCannotBePerformedSynchronously(context.WantAction),
                        context.WantAction,
                        context.Container,
                        null));
                    continue;
                }

                var requestForAction = new BuildTreesForWantActionRequest<TFactRule, TWantAction, TFactContainer>
                {
                    Context = context,
                    FactRules = request
                        .Rules
                        .Where(factRule => factRule.Option.HasFlag(FactWorkOption.CanExecuteSync))
                        .OrderByDescending(r => r, context.SingleEntity.GetRuleComparer<TFactRule, TWantAction, TFactContainer>(context))
                        .ToList(),
                };

                if (context.TreeBuilding.TryBuildTreesForWantAction(requestForAction, out var resultForAction))
                    treesByActions.Add(resultForAction.WantActionInfo, resultForAction.TreesResult);
                else
                    deriveErrorDetails.Add(resultForAction.DeriveErrorDetail);
            }

            // Check that we were able to adequately build the tree.
            if (deriveErrorDetails.Count != 0)
                throw CommonHelper.CreateDeriveException(deriveErrorDetails);

            foreach (var item in treesByActions)
                item.Key.Context.TreeBuilding.CalculateTreeAndDeriveWantFacts(item.Key, item.Value);
        }

        /// <inheritdoc/>
        public virtual async ValueTask DeriveWantActionAsync<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>(List<DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>> requests)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            Validate(requests);

            var treesByActions = new Dictionary<WantActionInfo<TWantAction, TFactContainer>, List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>>>();
            var deriveErrorDetails = new List<DeriveErrorDetail>();


            foreach (DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> request in requests)
            {
                var context = request.Context;

                var requestForAction = new BuildTreesForWantActionRequest<TFactRule, TWantAction, TFactContainer>
                {
                    Context = context,
                    FactRules = request
                        .Rules
                        .OrderByDescending(r => r, context.SingleEntity.GetRuleComparer<TFactRule, TWantAction, TFactContainer>(context))
                        .ToList(),
                };

                if (context.TreeBuilding.TryBuildTreesForWantAction(requestForAction, out var resultForAction))
                    treesByActions.Add(resultForAction.WantActionInfo, resultForAction.TreesResult);
                else
                    deriveErrorDetails.Add(resultForAction.DeriveErrorDetail);
            }

            // Check that we were able to adequately build the tree.
            if (deriveErrorDetails.Count != 0)
                throw CommonHelper.CreateDeriveException(deriveErrorDetails);

            foreach (var item in treesByActions)
                await item.Key.Context.TreeBuilding.CalculateTreeAndDeriveWantFactsAsync(item.Key, item.Value);
        }

        /// <summary>
        /// Validates <paramref name="requests"/>.
        /// </summary>
        /// <param name="requests">Requests.</param>
        protected virtual void Validate<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>(List<DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>> requests)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var verifiedContainers = new List<TFactContainer>();
            var verifiedRules = new List<TFactRuleCollection>();

            foreach(DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> request in requests)
            {
                var singleOperations = request.Context.SingleEntity;

                if (!verifiedContainers.Contains(request.Context.Container))
                {
                    singleOperations.ValidateContainer(request.Context.Container);
                    verifiedContainers.Add(request.Context.Container);
                }

                if (!verifiedRules.Contains(request.Rules))
                {
                    singleOperations.ValidateAndGetRules<TFactRule, TFactRuleCollection>(request.Rules);
                    verifiedRules.Add(request.Rules);
                }
            }
        }
    }
}
