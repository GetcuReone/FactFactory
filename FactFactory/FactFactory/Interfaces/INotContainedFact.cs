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
        /// <typeparam name="TFactContainer"></typeparam>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        bool IsFactContained<TFact, TFactContainer>(TFactContainer container)
            where TFact : IFact
            where TFactContainer : IFactContainer<TFact>;
    }
}
