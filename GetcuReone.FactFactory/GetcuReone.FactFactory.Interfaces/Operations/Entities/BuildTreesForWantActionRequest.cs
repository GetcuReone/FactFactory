using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request
    /// </summary>
    public class BuildTreesForWantActionRequest
    {
        /// <summary>
        /// Context
        /// </summary>
        public IWantActionContext Context { get; }

        /// <summary>
        /// Fact rules
        /// </summary>
        public IFactRuleCollection FactRules { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="factRules">Fact rules</param>
        public BuildTreesForWantActionRequest(IWantActionContext context, IFactRuleCollection factRules)
        {
            Context = context;
            FactRules = factRules;
        }
    }
}
