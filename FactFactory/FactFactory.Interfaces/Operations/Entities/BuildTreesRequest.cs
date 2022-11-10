using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    /// <typeparam name="TFactRuleCollection">Fact rule collection type.</typeparam>
    public class BuildTreesRequest<TFactRule, TFactRuleCollection>
        where TFactRule : IFactRule
        where TFactRuleCollection : IFactRuleCollection<TFactRule>
    {
        /// <summary>
        /// The contexts within which to build trees.
        /// </summary>
        public List<IWantActionContext> WantActionContexts { get; set; }

        /// <summary>
        /// List of rules that take part in the construction of trees.
        /// </summary>
        public TFactRuleCollection FactRules { get; set; }

        /// <summary>
        /// Filter for WantAction and FactRule.
        /// </summary>
        public List<FactWorkOption> Filters { get; set; }
    }
}
