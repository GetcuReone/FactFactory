using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations;

namespace GetcuReone.FactFactory.Priority
{
    /// <inheritdoc/>
    public abstract class PriorityFactFactoryBase<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> : FactFactoryBase<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
        where TFactRule : FactRuleBase
        where TFactRuleCollection : FactRuleCollectionBase<TFactRule>
        where TWantAction : WantActionBase
        where TFactContainer : FactContainerBase
    {
        /// <summary>
        /// Returns the <see cref="PrioritySingleEntityOperationsFacade"/>.
        /// </summary>
        /// <returns>Instance <see cref="PrioritySingleEntityOperationsFacade"/>.</returns>
        protected override ISingleEntityOperations GetSingleEntityOperations()
        {
            return GetFacade<PrioritySingleEntityOperationsFacade>();
        }
    }
}
