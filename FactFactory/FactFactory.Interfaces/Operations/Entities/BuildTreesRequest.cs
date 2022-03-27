using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    /// <typeparam name="TWantAction">WantAction type.</typeparam>
    /// <typeparam name="TFactContainer">Fact container type.</typeparam>
    /// <typeparam name="TFactRuleCollection">Fact rule collection type.</typeparam>
    public class BuildTreesRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
        where TFactRule : IFactRule
        where TFactRuleCollection : IFactRuleCollection<TFactRule>
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <summary>
        /// The contexts within which to build trees.
        /// </summary>
        public List<IWantActionContext<TWantAction, TFactContainer>> WantActionContexts { get; set; }

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
