using FactFactory.Entities;
using FactFactory.Interfaces;

namespace FactFactory.Facts
{
    /// <summary>
    /// Information about a fact that is not contained in the container at the time of the function call <see cref="IFactFactory{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public sealed class NotContainedFact<TFact> : NotContainedFactBase
        where TFact : IFact
    {
        /// <inheritdoc />
        public override IFactInfo Value { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public NotContainedFact() : base(null)
        {
            Value = GetFactInfoNotContained<TFact>();
        }

        /// <inheritdoc />
        protected override IFactInfo GetFactInfoNotContained<TFact1>()
        {
            return new FactInfo<TFact1>();
        }
    }
}
