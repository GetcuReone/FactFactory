namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Fact info
    /// </summary>
    public interface IFactType
    {
        /// <summary>
        /// Compare <see cref="IFactType"/>
        /// </summary>
        /// <param name="factInfo"></param>
        bool Compare<TFactType>(TFactType factInfo) where TFactType : IFactType;

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

        /// <summary>
        /// Is it possible to convert a fact type to a <typeparamref name="TFact"/>
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        bool IsFactType<TFact>() where TFact : IFact;

        /// <summary>
        /// Return fact. The current fact is not contained in the container.
        /// </summary>
        /// <returns></returns>
        INotContainedFact GetNotContainedInstance();

        /// <summary>
        /// Return an instance of a type <see cref="INoDerivedFact"/> fact in for the current fact type
        /// </summary>
        /// <returns></returns>
        INoDerivedFact GetNoDerivedInstance();
    }
}
