namespace GetcuReone.FactFactory.Interfaces.Context
{
    /// <inheritdoc/>
    public interface IFactRulesContext<TFactRule> : IWantActionContext
        where TFactRule : IFactRule
    {
        /// <summary>
        /// Fact rules in context.
        /// </summary>
        IFactRuleCollection<TFactRule> FactRules { get; }
    }
}
