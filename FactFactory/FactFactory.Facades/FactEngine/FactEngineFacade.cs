﻿using GetcuReone.ComboPatterns.Facade;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

namespace GetcuReone.FactFactory.Facades.FactEngine
{
    /// <inheritdoc cref="IFactEngine"/>
    public class FactEngineFacade : FacadeBase, IFactEngine
    {
        /// <inheritdoc/>
        public virtual void DeriveWantAction<TFactRule, TFactRuleCollection, TWantAction>(List<DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction>> requests)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>
            where TWantAction : IWantAction
        {
            Validate(requests);

            var treesByActions = new Dictionary<WantActionInfo<TWantAction>, List<TreeByFactRule<TFactRule, TWantAction>>>();
            var deriveErrorDetails = new List<DeriveErrorDetail>();


            foreach(DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction> request in requests)
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

                var requestForAction = new BuildTreesForWantActionRequest<TFactRule, TWantAction>
                {
                    Context = context,
                    FactRules = request
                        .Rules
                        .FindAll(factRule => factRule.Option.HasFlag(FactWorkOption.CanExecuteSync))
                        .SortByDescending(r => r, context.SingleEntity.GetRuleComparer<TFactRule, TWantAction>(context)),
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
        public virtual async ValueTask DeriveWantActionAsync<TFactRule, TFactRuleCollection, TWantAction>(List<DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction>> requests)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>
            where TWantAction : IWantAction
        {
            Validate(requests);

            var treesByActions = new Dictionary<WantActionInfo<TWantAction>, List<TreeByFactRule<TFactRule, TWantAction>>>();
            var deriveErrorDetails = new List<DeriveErrorDetail>();


            foreach (DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction> request in requests)
            {
                var context = request.Context;

                var requestForAction = new BuildTreesForWantActionRequest<TFactRule, TWantAction>
                {
                    Context = context,
                    FactRules = request
                        .Rules
                        .SortByDescending(r => r, context.SingleEntity.GetRuleComparer<TFactRule, TWantAction>(context)),
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
        protected virtual void Validate<TFactRule, TFactRuleCollection, TWantAction>(List<DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction>> requests)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>
            where TWantAction : IWantAction
        {
            var verifiedContainers = new List<IFactContainer>();
            var verifiedRules = new List<TFactRuleCollection>();

            foreach(DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction> request in requests)
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
