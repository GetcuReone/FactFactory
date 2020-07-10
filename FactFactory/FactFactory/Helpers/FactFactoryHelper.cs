using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Helpers
{
    /// <summary>
    /// Helper for <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
    /// </summary>
    public static class FactFactoryHelper
    {
        internal static IgnoreReadOnlySpace<TFact> CreateIgnoreReadOnlySpace<TFact>(this FactContainerBase<TFact> container)
            where TFact : IFact
        {
            return new IgnoreReadOnlySpace<TFact>(container);
        }
    }
}
