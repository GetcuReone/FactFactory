using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Helpers
{
    /// <summary>
    /// Helper for <see cref="FactFactoryBase{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
    /// </summary>
    public static class FactFactoryHelper
    {
        internal static IgnoreReadOnlySpace CreateIgnoreReadOnlySpace(this FactContainerBase container)
        {
            return new IgnoreReadOnlySpace(container);
        }

        internal static FactFactoryContext ToFactFactoryContext<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>(this IFactFactory<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> factory)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return new FactFactoryContext
            {
                Cache = factory.GetFactTypeCache(),
                SingleEntity = factory.GetSingleEntityOperations(),
                TreeBuilding = factory.GetTreeBuildingOperations(),
            };
        }

        internal static void CopyFactFactoryContext(this FactFactoryContext toContext, IFactFactoryContext fromContext)
        {
            toContext.Cache = fromContext.Cache;
            toContext.SingleEntity = fromContext.SingleEntity;
            toContext.TreeBuilding = fromContext.TreeBuilding;
        }

        internal static WantActionContext<TWantAction, TFactContainer> ToWantActionContext<TWantAction, TFactContainer>(this IFactFactoryContext context, TWantAction wantAction, TFactContainer container)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var result = new WantActionContext<TWantAction, TFactContainer>
            {
                Container = container,
                WantAction = wantAction,
            };

            result.CopyFactFactoryContext(context);
            return result;
        }

        internal static FactRulesContext<TFactRule, TWantAction, TFactContainer> ToFactRulesContext<TFactRule, TWantAction, TFactContainer>(this IWantActionContext<TWantAction, TFactContainer> context, IEnumerable<TFactRule> factRules, bool deferredRequestRequired)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var compatibleRules = context.SingleEntity.GetCompatibleRules(context.WantAction, factRules, context);

            if (deferredRequestRequired)
                compatibleRules = compatibleRules.ToList();

            var result = new FactRulesContext<TFactRule, TWantAction, TFactContainer>
            {
                Container = context.Container,
                FactRules = compatibleRules,
                WantAction = context.WantAction,
            };

            result.CopyFactFactoryContext(context);
            return result;
        }
    }
}
