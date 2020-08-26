namespace GetcuReone.FactFactory.Interfaces.Context
{
    /// <inheritdoc/>
    public interface IWantActionContext<TWantAction, TFactContainer> : IFactFactoryContext
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <summary>
        /// WantAction.
        /// </summary>
        TWantAction WantAction { get; }

        /// <summary>
        /// Fact container.
        /// </summary>
        TFactContainer Container { get; }
    }
}
