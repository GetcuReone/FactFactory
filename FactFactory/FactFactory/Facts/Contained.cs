﻿using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Information about a fact that is contained in the container at the time of the function call <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public sealed class Contained<TFact> : FactBase<IFactType>, IContainedFact
        where TFact : IFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Contained() : base(FactFactoryHelper.GetFactType<TFact>())
        {
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
            return Value.ContainsContainer(container);
        }
    }
}