namespace GetcuReone.FactFactory.Interfaces.Context
{
    /// <inheritdoc/>
    public interface IFactWorkContext<TFactWork, TFactRule, TWantAction, TFactContainer> : IFactRulesContext<TFactRule, TWantAction, TFactContainer>
        where TFactWork : IFactWork
        where TFactRule : IFactRule
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <summary>
        /// FactWork in context.
        /// </summary>
        TFactWork FactWork { get; }
    }
}
