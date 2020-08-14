using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

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
    }
}
