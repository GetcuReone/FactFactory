using System;
using GetcuReone.ComboPatterns.Interfaces;
using GetcuReone.FactFactory.BaseEntities;

namespace GetcuReone.FactFactory
{
    /// <inheritdoc/>
    [Obsolete("Use BaseFactFactory (deprecated in 4.0.2)")]
    public abstract class FactFactoryBase<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> : BaseFactFactory<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>, IFacadeCreation
        where TFactContainer : BaseFactContainer
        where TFactRule : BaseFactRule
        where TFactRuleCollection : BaseFactRuleCollection<TFactRule>
        where TWantAction : BaseWantAction
    {
    }
}
