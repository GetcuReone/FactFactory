namespace GetcuReone.FactFactory.Interfaces.SpecialFacts
{
    /// <summary>
    /// Basic interface for special facts.
    /// </summary>
    public interface ISpecialFact : IFact
    {
        /// <summary>
        /// Is the fact contained in the container
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        bool IsFactContained<TFact>(IFactContainer<TFact> container) where TFact : IFact;
    }
}
