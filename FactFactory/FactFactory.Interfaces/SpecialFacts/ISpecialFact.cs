namespace GetcuReone.FactFactory.Interfaces.SpecialFacts
{
    /// <summary>
    /// Basic interface for special facts.
    /// </summary>
    public interface ISpecialFact : IFact
    {
        /// <summary>
        /// Is the fact contained in the container.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="factWork">Work for which we learn about the possibility of using the fact.</param>
        /// <param name="wantAction">The action in the context of which we do this.</param>
        /// <param name="container">Container.</param>
        /// <returns></returns>
        bool IsFactContained<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;
    }
}
