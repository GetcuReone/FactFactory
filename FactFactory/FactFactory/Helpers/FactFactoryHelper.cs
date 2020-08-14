using GetcuReone.FactFactory.BaseEntities;

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
    }
}
