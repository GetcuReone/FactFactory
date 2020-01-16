using FactFactory.Entities;
using FactFactory.Interfaces;

namespace FactFactory.Facts
{
    /// <summary>
    /// Information about a fact that is not contained in the container at the time of the function call <see cref="IFactFactory{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public sealed class NotContained<TFact> : NotContainedBase
        where TFact : IFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NotContained() : base(GetFactInfoNotContained<TFact>())
        {
        }

        /// <summary>
        /// Return information about a fact not contained in the container
        /// </summary>
        /// <typeparam name="TFact1"></typeparam>
        /// <returns></returns>
        private static IFactInfo GetFactInfoNotContained<TFact1>() where TFact1 : IFact
        {
            return new FactInfo<TFact1>();
        }
    }
}
