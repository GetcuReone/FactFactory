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
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="factWork">Work for which we learn about the possibility of using the fact.</param>
        /// <param name="wantAction">The action in the context of which we do this.</param>
        /// <param name="container">Container.</param>
        /// <returns></returns>
        bool IsFactContained<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>;
    }
}
