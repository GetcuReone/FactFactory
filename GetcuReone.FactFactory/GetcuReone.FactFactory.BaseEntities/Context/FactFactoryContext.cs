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
        public IFactTypeCache Cache { get; }

        /// <inheritdoc/>
        public ISingleEntityOperations SingleEntity { get; }

        /// <inheritdoc/>
        public ITreeBuildingOperations TreeBuilding { get; }

        /// <inheritdoc/>
        public IFactEngine Engine { get; }

        /// <inheritdoc/>
        public IFactParameterCache ParameterCache { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cache">Fact type cache</param>
        /// <param name="singleEntity">Single operations on entities of the FactFactory</param>
        /// <param name="treeBuilding">Tree building operations</param>
        /// <param name="engine">Engine for calculating facts</param>
        /// <param name="parameterCache">Fact parameter cache</param>
        public FactFactoryContext(
            IFactTypeCache cache,
            ISingleEntityOperations singleEntity,
            ITreeBuildingOperations treeBuilding,
            IFactEngine engine,
            IFactParameterCache parameterCache)
        {
            Cache = cache;
            SingleEntity = singleEntity;
            TreeBuilding = treeBuilding;
            Engine = engine;
            ParameterCache = parameterCache;
        }
    }
}
