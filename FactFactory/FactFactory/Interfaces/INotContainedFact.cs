namespace FactFactory.Interfaces
{
    /// <summary>
    /// Information about a fact that is not contained in the container at the time of the function call <see cref="IFactFactory{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public interface INotContainedFact : IFact
    {
        /// <summary>
        /// Is the fact contained in the container
        /// </summary>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        bool IsFactContained<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;
    }
}
