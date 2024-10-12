using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Base class for versioned fact factory.
    /// </summary>
    /// <inheritdoc/>
    public abstract class BaseVersionedFactFactory : BaseFactFactory
    {
        /// <summary>
        /// Returns the <see cref="VersionedSingleEntityOperationsFacade"/>.
        /// </summary>
        /// <returns>Instance <see cref="VersionedSingleEntityOperationsFacade"/>.</returns>
        protected override ISingleEntityOperations GetSingleEntityOperations()
        {
            return new VersionedSingleEntityOperationsFacade();
        }
    }
}
