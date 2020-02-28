using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Information about a fact that is not contained in the container at the time of the function call <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public sealed class NotContained<TFact> : FactBase<IFactType>, INotContainedFact
        where TFact : IFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NotContained() : base(FactFactoryHelper.GetFactType<TFact>())
        {
        }

        /// <summary>
        /// Is the fact contained in the container.
        /// </summary>
        /// <typeparam name="TFact1"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public bool IsFactContained<TFact1, TFactContainer>(TFactContainer container)
            where TFact1 : IFact
            where TFactContainer : IFactContainer<TFact1>
        {
            return Value.ContainsContainer<TFact1, TFactContainer>(container);
        }
    }
}
