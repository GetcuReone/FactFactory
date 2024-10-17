using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;

namespace GetcuReone.FactFactory.BaseEntities.Context
{
    /// <inheritdoc/>
    public class WantActionContext : FactFactoryContext, IWantActionContext
    {
        /// <inheritdoc/>
        public IWantAction WantAction { get; }

        /// <inheritdoc/>
        public IFactContainer Container { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cache">Fact type cache</param>
        /// <param name="singleEntity">Single operations on entities of the FactFactory</param>
        /// <param name="treeBuilding">Tree building operations</param>
        /// <param name="engine">Engine for calculating facts</param>
        /// <param name="parameterCache">Fact parameter cache</param>
        /// <param name="wantAction">Desired action information</param>
        /// <param name="container">Container interface with facts for deriving other facts</param>
        public WantActionContext(
            IFactTypeCache cache,
            ISingleEntityOperations singleEntity,
            ITreeBuildingOperations treeBuilding,
            IFactEngine engine,
            IFactParameterCache parameterCache,
            IWantAction wantAction,
            IFactContainer container)
            : base(cache, singleEntity, treeBuilding, engine, parameterCache)
        {
            WantAction = wantAction;
            Container = container;
        }
    }
}
