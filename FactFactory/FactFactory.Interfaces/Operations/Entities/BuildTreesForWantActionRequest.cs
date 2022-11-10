using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request.
    /// </summary>
    public class BuildTreesForWantActionRequest
    {
        /// <summary>
        /// Context.
        /// </summary>
        public IWantActionContext Context { get; set; }

        /// <summary>
        /// Fact rules.
        /// </summary>
        public IFactRuleCollection FactRules { get; set; }
    }
}
