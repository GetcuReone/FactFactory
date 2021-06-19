namespace GetcuReone.FactFactory.Interfaces.Operations
{
    /// <summary>
    /// Fact type cache.
    /// </summary>
    public interface IFactTypeCache
    {
        /// <summary>
        /// Returns fact type from cache or new.
        /// </summary>
        /// <typeparam name="TFact">Fact type.</typeparam>
        /// <param name="fact">Fact.</param>
        /// <returns>Fact type info.</returns>
        IFactType GetFactType<TFact>(TFact fact) where TFact : IFact;
    }
}
