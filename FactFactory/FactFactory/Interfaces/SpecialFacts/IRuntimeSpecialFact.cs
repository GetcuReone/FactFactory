namespace GetcuReone.FactFactory.Interfaces.SpecialFacts
{
    /// <summary>
    /// A special fact that is created using a factory when building a tree or calculating facts.
    /// </summary>
    public interface IRuntimeSpecialFact : ISpecialFact
    {
        /// <summary>
        /// Information about the type of fact the current runtime fact is working with.
        /// </summary>
        IFactType FactType { get; }
    }
}
