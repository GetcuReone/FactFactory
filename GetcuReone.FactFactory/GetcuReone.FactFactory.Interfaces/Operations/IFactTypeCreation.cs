namespace GetcuReone.FactFactory.Interfaces.Operations
{
    /// <summary>
    /// Interface for creating a fact type.
    /// </summary>
    public interface IFactTypeCreation
    {
        /// <summary>
        /// Returns fact type from <typeparamref name="TFact"/>.
        /// </summary>
        /// <typeparam name="TFact">Fact type.</typeparam>
        /// <returns>Instance <see cref="IFactType"/></returns>
        IFactType GetFactType<TFact>() where TFact : IFact;
    }
}
