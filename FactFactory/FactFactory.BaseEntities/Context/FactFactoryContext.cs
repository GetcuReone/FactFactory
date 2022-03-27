using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;

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
        public ISingleEntityOperations SingleEntity { get; set; }

        /// <inheritdoc/>
        public ITreeBuildingOperations TreeBuilding { get; set; }

        /// <inheritdoc/>
        public IFactEngine Engine { get; set; }
    }
}
