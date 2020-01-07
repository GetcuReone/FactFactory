namespace FactFactory.Interfaces
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
        IFactInfo GetFactInfo();
    }

    /// <summary>
    /// Typed Fact Interface
    /// </summary>
    public interface IFact<TFact> : IFact
    {
        /// <summary>
        /// Value fact
        /// </summary>
        TFact Value { get; }
    }
}
