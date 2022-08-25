using System;
using GetcuReone.FactFactory.BaseEntities;

namespace GetcuReone.FactFactory.Versioned
{
    /// <inheritdoc/>
    [Obsolete("Use BaseVersionedFactFactory (deprecated in 4.0.2)")]
    public abstract class VersionedFactFactoryBase<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> : BaseVersionedFactFactory<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
        where TFactContainer : BaseFactContainer
        where TFactRule : BaseFactRule
        where TFactRuleCollection : BaseFactRuleCollection<TFactRule>
        where TWantAction : BaseWantAction
    {
    }
}
