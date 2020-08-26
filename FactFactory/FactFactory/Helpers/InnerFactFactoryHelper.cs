using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;

namespace GetcuReone.FactFactory.Helpers
{
    /// <summary>
    /// Helper for <see cref="FactFactoryBase{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
    /// </summary>
    internal static class InnerFactFactoryHelper
    {
        internal static IgnoreReadOnlySpace CreateIgnoreReadOnlySpace(this FactContainerBase container)
        {
            return new IgnoreReadOnlySpace(container);
        }

        internal static IWantActionContext<TWantAction, TFactContainer> ConvertWantActionContext<TWantAction, TFactContainer>(this TWantAction wantAction, TFactContainer container, IFactTypeCache cache, ISingleEntityOperations singleEntityOperations, ITreeBuildingOperations treeBuildingOperations)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return new WantActionContext<TWantAction, TFactContainer>
            {
                Cache = cache,
                Container = container,
                SingleEntity = singleEntityOperations,
                TreeBuilding = treeBuildingOperations,
                WantAction = wantAction,
            };
        }
    }
}
