using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations;

namespace GetcuReone.FactFactory.Priority
{
    /// <summary>
    /// Base class for the fact factory working with priority rules
    /// </summary>
    /// <inheritdoc/>
    public abstract class BasePriorityFactFactory : BaseFactFactory
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
