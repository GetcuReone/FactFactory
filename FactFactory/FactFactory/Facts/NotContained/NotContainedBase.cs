using FactFactory.Interfaces;

namespace FactFactory.Facts
{
    /// <summary>
    /// Information about a fact that is not contained in the container at the time of the function call <see cref="IFactFactory{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public abstract class NotContainedBase : FactBase<IFactInfo>, INotContainedFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fact"></param>
        protected NotContainedBase(IFactInfo fact) : base(fact)
        {
        }

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
    }
}
