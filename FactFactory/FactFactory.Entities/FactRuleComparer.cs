using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Entities
{
    /// <inheritdoc/>
    public class FactRuleComparer<TFactBase, TFactRule, TWantAction, TFactContainer> : FactRuleComparerBase<TFactBase, TFactRule, TWantAction, TFactContainer>
        where TFactBase : IFact
        where TFactRule : FactRuleBase<TFactBase>
        where TWantAction : WantActionBase<TFactBase>
        where TFactContainer : FactContainerBase<TFactBase>
    {
        /// <inheritdoc/>
        public FactRuleComparer(TWantAction wantAction, TFactContainer container) : base(wantAction, container)
        {
        }
    }
}
