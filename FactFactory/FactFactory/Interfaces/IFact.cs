namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Fact interface
    /// </summary>
    public interface IFact
    {
        /// <summary>
        /// Return fact information as an output parameter
        /// </summary>
        /// <returns></returns>
        IFactType GetFactType();

        /// <summary>
        /// It was calculated using the rule.
        /// </summary>
        bool CalculatedByRule { get; set; }
    }
}
