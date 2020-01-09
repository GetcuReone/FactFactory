namespace FactFactory.Interfaces
{
    /// <summary>
    /// Fact info
    /// </summary>
    public interface IFactInfo
    {
        /// <summary>
        /// Compare <see cref="IFactInfo"/>
        /// </summary>
        /// <param name="factInfo"></param>
        bool Compare<TFactInfo>(TFactInfo factInfo) where TFactInfo : IFactInfo;

        /// <summary>
        /// Fact name
        /// </summary>
        string FactName { get; }

        /// <summary>
        /// Is in the container
        /// </summary>
        /// <typeparam name="TFactContainer">type container</typeparam>
        /// <param name="container">container</param>
        /// <returns></returns>
        bool ContainsContainer<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;
    }
}
