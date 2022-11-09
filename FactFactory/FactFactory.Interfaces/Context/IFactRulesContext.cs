namespace GetcuReone.FactFactory.Interfaces.Context
{
    /// <inheritdoc/>
    public interface IFactRulesContext<TFactRule, TWantAction> : IWantActionContext<TWantAction>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
    {
        /// <summary>
        /// Fact rules in context.
        /// </summary>
        IFactRuleCollection<TFactRule> FactRules { get; }
    }
}
