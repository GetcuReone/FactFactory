﻿using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Linq;

namespace GetcuReone.FactFactory.SpecialFacts
{
    internal static class ConditionHelper
    {
        internal static bool CanDeriveFact<TFactWork, TFactRule, TWantAction>(
            IBuildConditionFact conditionFact,
            IFactType searchFactType,
            TFactWork factWork,
            IFactRuleCollection<TFactRule> compatibleRules,
            IWantActionContext<TWantAction> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
        {
            if (context.SingleEntity.CanExtractFact(searchFactType, factWork, context))
                return true;

            var rulesWithoutConditionFact = compatibleRules
                .FindAll(rule => rule.InputFactTypes
                    .All(factType => !factType.EqualsFactType(context.Cache.GetFactType(conditionFact))));

            var request = new BuildTreeForFactInfoRequest<TFactRule, TWantAction>
            {
                WantFactType = searchFactType,
                Context = new FactRulesContext<TFactRule, TWantAction>
                {
                    Cache = context.Cache,
                    Container = context.Container,
                    FactRules = rulesWithoutConditionFact,
                    SingleEntity = context.SingleEntity,
                    TreeBuilding = context.TreeBuilding,
                    WantAction = context.WantAction,
                    Engine = context.Engine,
                },
            };

            try
            {
                return context.TreeBuilding.TryBuildTreeForFactInfo(request, out var _, out var _);
            }
            catch (InvalidDeriveOperationException ex)
            {
                if (ex.Details != null && ex.Details.Count == 1)
                {
                    DeriveErrorDetail detail = ex.Details.First();

                    if (detail.Code == ErrorCode.RuleNotFound || detail.Code == ErrorCode.EmptyRuleCollection)
                        return false;
                }

                throw;
            }
        }
        
        internal static bool CanDeriveFact<TFactWork, TFactRule, TWantAction>(
            IRuntimeConditionFact conditionFact,
            IFactType searchFactType,
            TFactWork factWork,
            IFactRulesContext<TFactRule, TWantAction> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
        {
            if (context.SingleEntity.CanExtractFact(searchFactType, factWork, context))
                return true;

            var rulesWithoutConditionFact = context.FactRules
                .FindAll(rule => rule.InputFactTypes
                    .All(factType => !factType.EqualsFactType(context.Cache.GetFactType(conditionFact))));

            var request = new BuildTreeForFactInfoRequest<TFactRule, TWantAction>
            {
                WantFactType = searchFactType,
                Context = new FactRulesContext<TFactRule, TWantAction>
                {
                    Cache = context.Cache,
                    Container = context.Container,
                    FactRules = rulesWithoutConditionFact,
                    SingleEntity = context.SingleEntity,
                    TreeBuilding = context.TreeBuilding,
                    WantAction = context.WantAction,
                    Engine = context.Engine,
                },
            };

            try
            {
                return context.TreeBuilding.TryBuildTreeForFactInfo(request, out var _, out var _);
            }
            catch (InvalidDeriveOperationException ex)
            {
                if (ex.Details != null && ex.Details.Count == 1)
                {
                    DeriveErrorDetail detail = ex.Details.First();

                    if (detail.Code == ErrorCode.RuleNotFound || detail.Code == ErrorCode.EmptyRuleCollection)
                        return false;
                }

                throw;
            }
        }
    }
}
