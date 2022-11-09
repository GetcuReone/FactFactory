namespace GetcuReone.FactFactory.Interfaces.Context
{
    /// <inheritdoc/>
    public interface IWantActionContext<TWantAction> : IFactFactoryContext
        where TWantAction : IWantAction
    {
        /// <summary>
        /// WantAction.
        /// </summary>
        TWantAction WantAction { get; }

        /// <summary>
        /// Fact container.
        /// </summary>
        IFactContainer Container { get; }
    }
}
