namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Information about a fact that is not contained in the container at the time of the function call <see cref="IFactFactory{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public interface INotContainedFact : IFact
    {
        /// <summary>
        /// Is the fact contained in the container
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        bool IsFactContained<TFact>(IFactContainer<TFact> container) where TFact : IFact;
    }
}
