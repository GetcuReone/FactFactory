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
    public interface IFact<TFactValue> : IFact
    {
        /// <summary>
        /// Value fact
        /// </summary>
        TFactValue Value { get; }
    }
}
