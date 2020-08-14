namespace GetcuReone.FactFactory.Interfaces.SpecialFacts
{
    /// <summary>
    /// A special fact that is created using a factory when building a tree or calculating facts.
    /// </summary>
    public interface IConditionFact : ISpecialFact
    {
        /// <summary>
        /// Information about the type of fact the current runtime fact is working with.
        /// </summary>
        IFactType FactType { get; }

        /// <summary>
        /// A condition that determines whether the current fact can be added to the container when deriving.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="factWork">Work for which we learn about the possibility of using the fact.</param>
        /// <param name="wantAction">The action in the context of which we do this.</param>
        /// <param name="container">Container.</param>
        /// <returns></returns>
        /// <remarks>
        /// Using it, you can determine which rule and under what conditions can be used to build a rule tree.
        /// </remarks>
        bool Condition<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;
    }
}
