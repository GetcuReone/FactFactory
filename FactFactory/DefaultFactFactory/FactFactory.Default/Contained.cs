using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Default
{
    /// <summary>
    /// Information about a fact that is contained in the container at the time of the function call <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public sealed class Contained<TFact> : FactBase<IFactType>, IContainedFact
        where TFact : IFact
    {
        /// <summary>
        /// Value fact.
        /// </summary>
        public override IFactType Value { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Contained() : base(null)
        {
            Value = GetFactType();
        }

        /// <summary>
        /// Get fact type.
        /// </summary>
        /// <returns>fact type</returns>
        public override IFactType GetFactType()
        {
            return new FactType<Contained<TFact>>();
        }

        /// <summary>
        /// Is the fact contained in the container.
        /// </summary>
        /// <typeparam name="TFact1"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public bool IsFactContained<TFact1>(IFactContainer<TFact1> container)
            where TFact1 : IFact
        {
            return Value.TryGetFact(container, out TFact1 _);
        }
    }
}
