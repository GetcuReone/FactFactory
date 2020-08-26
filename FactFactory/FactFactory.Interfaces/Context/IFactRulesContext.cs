using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Context
{
    /// <inheritdoc/>
    public interface IFactRulesContext<TFactRule, TWantAction, TFactContainer> : IWantActionContext<TWantAction, TFactContainer>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <summary>
        /// Fact rules in context.
        /// </summary>
        IEnumerable<TFactRule> FactRules { get; }
    }
}
