using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request.
    /// </summary>
    public class BuildTreesRequest
    {
        /// <summary>
        /// The contexts within which to build trees.
        /// </summary>
        public List<IWantActionContext> WantActionContexts { get; set; }

        /// <summary>
        /// List of rules that take part in the construction of trees.
        /// </summary>
        public IFactRuleCollection FactRules { get; set; }

        /// <summary>
        /// Filter for WantAction and FactRule.
        /// </summary>
        public List<FactWorkOption> Filters { get; set; }
    }
}
