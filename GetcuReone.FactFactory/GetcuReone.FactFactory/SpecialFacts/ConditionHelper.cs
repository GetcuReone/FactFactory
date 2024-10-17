using GetcuReone.FactFactory.BaseEntities.Context;
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
        internal static bool CanDeriveFact(
            IBuildConditionFact conditionFact,
            IFactType searchFactType,
            IFactWork factWork,
            IFactRuleCollection compatibleRules,
            IWantActionContext context)
        {
            if (context.SingleEntity.CanExtractFact(searchFactType, factWork, context))
                return true;

            IFactRuleCollection rulesWithoutConditionFact = compatibleRules
                .FindAll(rule => rule.InputFactTypes
                    .All(factType => !factType.EqualsFactType(context.Cache.GetFactType(conditionFact))));

            var newContext = new FactRulesContext(context)
            {
                FactRules = rulesWithoutConditionFact
            };
            var request = new BuildTreeForFactInfoRequest(searchFactType, newContext);

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
        
        internal static bool CanDeriveFact(
            IRuntimeConditionFact conditionFact,
            IFactType searchFactType,
            IFactWork factWork,
            IFactRulesContext context)
        {
            if (context.SingleEntity.CanExtractFact(searchFactType, factWork, context))
                return true;

            IFactRuleCollection rulesWithoutConditionFact = context.FactRules!
                .FindAll(rule => rule.InputFactTypes
                    .All(factType => !factType.EqualsFactType(context.Cache.GetFactType(conditionFact))));

            var newContext = new FactRulesContext(context)
            {
                FactRules = rulesWithoutConditionFact,
            };
            var request = new BuildTreeForFactInfoRequest(searchFactType, newContext);

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
