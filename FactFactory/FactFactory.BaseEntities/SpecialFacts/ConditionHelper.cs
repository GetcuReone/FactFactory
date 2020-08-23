using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities.SpecialFacts
{
    internal static class ConditionHelper
    {
        internal static bool CanDeriveFact<TFactWork, TFactRule, TWantAction, TFactContainer>(IFactType searchFactType, TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            if (context.SingleEntity.CanExtractFact(searchFactType, factWork, context))
                return true;

            var rulesWithoutCurrentFact = compatibleRules
                .Where(rule => rule.InputFactTypes.All(factType => !factType.EqualsFactType(searchFactType)))
                .ToList();

            var request = new BuildTreeForFactInfoRequest<TFactRule, TWantAction, TFactContainer>
            {
                WantFactType = searchFactType,
                Context = new FactRulesContext<TFactRule, TWantAction, TFactContainer>
                {
                    Cache = context.Cache,
                    Container = context.Container,
                    FactRules = compatibleRules
                        .Where(rule => rule.InputFactTypes.All(factType => !factType.EqualsFactType(searchFactType)))
                        .ToList(),
                    SingleEntity  =context.SingleEntity,
                    TreeBuilding = context.TreeBuilding,
                    WantAction = context.WantAction,
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
