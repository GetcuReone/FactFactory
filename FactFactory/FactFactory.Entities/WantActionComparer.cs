using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Comparer for <see cref="WantActionBase{TFactBase}"/>.
    /// </summary>
    public class WantActionComparer<TFactBase, TWantAction, TFactContainer> : WantActionComparerBase<TFactBase, TWantAction, TFactContainer>
        where TFactBase : IFact
        where TWantAction : WantActionBase<TFactBase>
        where TFactContainer : FactContainerBase<TFactBase>
    {
        /// <inheritdoc/>
        public WantActionComparer(TFactContainer container) : base(container)
        {
        }
    }
}
