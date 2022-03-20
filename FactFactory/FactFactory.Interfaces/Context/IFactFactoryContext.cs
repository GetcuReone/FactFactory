using GetcuReone.FactFactory.Interfaces.Operations;

namespace GetcuReone.FactFactory.Interfaces.Context
{
    /// <summary>
    /// A context containing information within which current actions are taking place.
    /// </summary>
    public interface IFactFactoryContext
    {
        /// <inheritdoc cref="IFactTypeCache"/>
        IFactTypeCache Cache { get; }

        /// <inheritdoc cref="ISingleEntityOperations"/>
        ISingleEntityOperations SingleEntity { get; }

        /// <inheritdoc cref="ITreeBuildingOperations"/>
        ITreeBuildingOperations TreeBuilding { get; }

        /// <inheritdoc cref="IFactEngine"/>
        IFactEngine Engine { get; }
    }
}
