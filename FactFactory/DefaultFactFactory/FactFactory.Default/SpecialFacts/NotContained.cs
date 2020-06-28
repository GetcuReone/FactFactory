﻿using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;

namespace GetcuReone.FactFactory.SpecialFacts
{
    /// <summary>
    /// Information about a fact that is not contained in the container at the time of the function call <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public sealed class NotContained<TFact> : FactBase<IFactType>, INotContainedFact
        where TFact : IFact
    {
        /// <summary>
        /// Value fact.
        /// </summary>
        public override IFactType Value { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public NotContained() : base(null)
        {
            Value = DefaultFactFactoryHelper.GetFactType<TFact>();
        }

        /// <summary>
        /// Get fact type.
        /// </summary>
        /// <returns>Fact type.</returns>
        public override IFactType GetFactType()
        {
            return DefaultFactFactoryHelper.GetFactType<NotContained<TFact>>();
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
