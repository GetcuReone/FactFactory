namespace GetcuReone.FactFactory.Interfaces.Context
{
    /// <inheritdoc/>
    public interface IWantActionContext : IFactFactoryContext
    {
        /// <summary>
        /// WantAction.
        /// </summary>
        IWantAction WantAction { get; }

        /// <summary>
        /// Fact container.
        /// </summary>
        IFactContainer Container { get; }
    }
}
