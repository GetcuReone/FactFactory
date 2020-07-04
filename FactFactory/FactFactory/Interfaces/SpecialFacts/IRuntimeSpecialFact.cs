namespace GetcuReone.FactFactory.Interfaces.SpecialFacts
{
    /// <summary>
    /// A special fact that is created using a factory when building a tree or calculating facts.
    /// </summary>
    public interface IRuntimeSpecialFact : ISpecialFact
    {
        /// <summary>
        /// Information about the type of fact the current runtime fact is working with.
        /// </summary>
        IFactType FactType { get; }

        /// <summary>
        /// Is it possible to use the current fact and add it to the container.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="factWork">Work for which we learn about the possibility of using the fact.</param>
        /// <param name="wantAction">The action in the context of which we do this.</param>
        /// <param name="container">Container.</param>
        /// <returns></returns>
        bool CanUse<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>;
    }
}
