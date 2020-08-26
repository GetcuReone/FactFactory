using GetcuReone.FactFactory.Interfaces.Operations;

namespace GetcuReone.FactFactory.Interfaces.Context
{
    /// <summary>
    /// A context containing information within which current actions are taking place.
    /// </summary>
    public interface IFactFactoryContext
    {
        /// <summary>
        /// Fact type cache.
        /// </summary>
        IFactTypeCache Cache { get; }

        /// <summary>
        /// Single operations on entities of the FactFactory.
        /// </summary>
        ISingleEntityOperations SingleEntity { get; }

        /// <summary>
        /// Tree building operations.
        /// </summary>
        ITreeBuildingOperations TreeBuilding { get; }
    }
}
