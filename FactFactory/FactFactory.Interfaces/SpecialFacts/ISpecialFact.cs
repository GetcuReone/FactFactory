namespace GetcuReone.FactFactory.Interfaces.SpecialFacts
{
    /// <summary>
    /// Basic interface for special facts.
    /// </summary>
    public interface ISpecialFact : IFact
    {
        /// <summary>
        /// Comparison of information about a special fact.
        /// </summary>
        /// <param name="specialFact"></param>
        /// <returns></returns>
        bool EqualsInfo(ISpecialFact specialFact);
    }
}
