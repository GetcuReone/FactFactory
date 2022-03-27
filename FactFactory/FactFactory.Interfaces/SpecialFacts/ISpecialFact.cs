namespace GetcuReone.FactFactory.Interfaces.SpecialFacts
{
    /// <summary>
    /// Basic interface for special facts.
    /// </summary>
    public interface ISpecialFact : IFact
    {
        /// <summary>
        /// Checks equality with <paramref name="specialFact"/>.
        /// </summary>
        /// <param name="specialFact">Special fact.</param>
        /// <returns>Are the facts equal?</returns>
        bool EqualsInfo(ISpecialFact specialFact);
    }
}
