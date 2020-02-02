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
        IFactType GeTFactType();
    }
}
