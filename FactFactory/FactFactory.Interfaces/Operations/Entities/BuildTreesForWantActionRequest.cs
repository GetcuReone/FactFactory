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
    public class BuildTreesForWantActionRequest<TFactRule, TWantAction, TFactContainer>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <summary>
        /// Context.
        /// </summary>
        public IWantActionContext<TWantAction, TFactContainer> Context { get; set; }

        /// <summary>
        /// Fact rules.
        /// </summary>
        public IEnumerable<TFactRule> FactRules { get; set; }
    }
}
