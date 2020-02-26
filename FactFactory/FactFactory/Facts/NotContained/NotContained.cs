using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Information about a fact that is not contained in the container at the time of the function call <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public sealed class NotContained<TFact> : NotContainedBase
        where TFact : IFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NotContained() : base(FactFactoryHelper.GetFactType<TFact>())
        {
        }
    }
}
