namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// interface for fact that cannot be calculated
    /// </summary>
    public interface INoDerivedFact : IFact
    {
        /// <summary>
        /// Information about a fact that cannot be calculated
        /// </summary>
        IFactType Value { get; }
    }
}
