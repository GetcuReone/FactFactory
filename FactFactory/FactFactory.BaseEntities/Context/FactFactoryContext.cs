using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.BaseEntities.Context
{
    /// <summary>
    /// A context containing information within which current actions are taking place.
    /// </summary>
    public class FactFactoryContext : IFactFactoryContext
    {
        /// <inheritdoc/>
        public IFactTypeCache Cache { get; set; }

        /// <inheritdoc/>
        public ISingleEntityOperations SingleEntityOperations { get; set; }
    }
}
