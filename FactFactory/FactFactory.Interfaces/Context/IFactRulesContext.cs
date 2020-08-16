using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Context
{
    /// <inheritdoc/>
    public interface IFactRulesContext : IWantActionContext
    {
        /// <summary>
        /// Fact rules in context.
        /// </summary>
        IEnumerable<IFactRule> FactRules { get; }
    }
}
