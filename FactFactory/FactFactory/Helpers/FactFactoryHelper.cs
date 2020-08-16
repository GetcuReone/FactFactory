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
                SingleEntityOperations = factory.GetSingleEntityOperations(),
            };
        }

        internal static WantActionContext ToWantActionContext(this IFactFactoryContext context, IWantAction wantAction, IFactContainer container)
        {
            return new WantActionContext
            {
                Cache = context.Cache,
                Container = container,
                SingleEntityOperations = context.SingleEntityOperations,
                WantAction = wantAction,
            };
        }

        internal static FactRulesContext ToFactRulesContext(this IWantActionContext context, IEnumerable<IFactRule> factRules, bool deferredRequestRequired)
        {
            var compatibleRules = context.SingleEntityOperations.GetCompatibleRules(context.WantAction, factRules, context);

            if (deferredRequestRequired)
                compatibleRules = compatibleRules.ToList();

            return new FactRulesContext
            {
                Cache = context.Cache,
                Container = context.Container,
                FactRules = compatibleRules,
                SingleEntityOperations = context.SingleEntityOperations,
                WantAction = context.WantAction,
            };
        }
    }
}
