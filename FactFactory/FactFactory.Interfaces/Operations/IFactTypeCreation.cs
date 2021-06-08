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
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        IFactType GetFactType<TFact>() where TFact : IFact;
    }
}
