namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Fact type cache.
    /// </summary>
    public interface IFactTypeCache
    {
        /// <summary>
        /// Get fact type from cache or new.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        IFactType GetFactType<TFact>(TFact fact) where TFact : IFact;
    }
}
