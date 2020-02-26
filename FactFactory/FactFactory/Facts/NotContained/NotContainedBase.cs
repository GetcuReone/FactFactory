using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Information about a fact that is not contained in the container at the time of the function call <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>.
    /// </summary>
    public abstract class NotContainedBase : FactBase<IFactType>, INotContainedFact
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fact"></param>
        protected NotContainedBase(IFactType fact) : base(fact)
        {
        }

        /// <summary>
        /// Is the fact contained in the container.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public bool IsFactContained<TFact, TFactContainer>(TFactContainer container)
            where TFact : IFact
            where TFactContainer : IFactContainer<TFact>
        {
            return Value.ContainsContainer<TFact, TFactContainer>(container);
        }
    }
}
