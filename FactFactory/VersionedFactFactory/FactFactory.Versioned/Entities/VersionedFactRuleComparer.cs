using GetcuReone.FactFactory.Versioned.BaseEntities;
using GetcuReone.FactFactory.Versioned.Interfaces;

namespace GetcuReone.FactFactory.Versioned.Entities
{
    /// <inheritdoc/>
    public class VersionedFactRuleComparer<TFactBase, TFactRule, TWantAction, TFactContainer> : VersionedFactRuleComparerBase<TFactBase, TFactRule, TWantAction, TFactContainer>
        where TFactBase : class, IVersionedFact
        where TFactRule : VersionedFactRuleBase<TFactBase>
        where TWantAction : VersionedWantActionBase<TFactBase>
        where TFactContainer : VersionedFactContainerBase<TFactBase>
    {
        /// <inheritdoc/>
        public VersionedFactRuleComparer(TWantAction wantAction, TFactContainer container) : base(wantAction, container)
        {
        }
    }
}
