using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;

namespace GetcuReone.FactFactory.BaseEntities.Context
{
    /// <inheritdoc/>
    public class FactRulesContext : WantActionContext, IFactRulesContext
    {
        /// <inheritdoc/>
        public IFactRuleCollection? FactRules { get; set; }

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
        public FactRulesContext(
            IFactTypeCache cache,
            ISingleEntityOperations singleEntity,
            ITreeBuildingOperations treeBuilding,
            IFactEngine engine,
            IFactParameterCache parameterCache,
            IWantAction wantAction,
            IFactContainer container)
            : base(cache, singleEntity, treeBuilding, engine, parameterCache, wantAction, container) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wantActionContext">A context containing information within which current actions are taking place</param>
        public FactRulesContext(IWantActionContext wantActionContext)
            : base(
                  wantActionContext.Cache,
                  wantActionContext.SingleEntity,
                  wantActionContext.TreeBuilding,
                  wantActionContext.Engine,
                  wantActionContext.ParameterCache,
                  wantActionContext.WantAction,
                  wantActionContext.Container) { }
    }
}
