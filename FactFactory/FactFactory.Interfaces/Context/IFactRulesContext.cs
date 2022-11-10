namespace GetcuReone.FactFactory.Interfaces.Context
{
    /// <inheritdoc/>
    public interface IFactRulesContext : IWantActionContext
    {
        /// <summary>
        /// Fact rules in context.
        /// </summary>
        IFactRuleCollection FactRules { get; }
    }
}
