using FactFactory.Interfaces;

namespace FactFactory.Facts
{
    /// <summary>
    /// Information about a fact that is not contained in the container at the time of the function call <see cref="IFactFactory{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public abstract class NotContainedFactBase : FactBase<IFactInfo>, INotContainedFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fact"></param>
        protected NotContainedFactBase(IFactInfo fact) : base(fact)
        {
        }

        /// <summary>
        /// Return information about a fact not contained in the container
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        protected abstract IFactInfo GetFactInfoNotContained<TFact>() where TFact : IFact;

        /// <summary>
        /// Is the fact contained in the container
        /// </summary>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public virtual bool IsFactContained<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer
        {
            return Value.ContainsContainer(container);
        }

        /// <summary>
        /// Get instace
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        public static NotContainedFactBase GetInstance<TFact>() where TFact : IFact
        {
            return new NotContainedFact<TFact>();
        }
    }
}
