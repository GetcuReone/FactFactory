using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Priority
{
    /// <summary>
    /// Default priority fact factory.
    /// </summary>
    public class PriorityFactFactory : PriorityFactFactoryBase<FactRule, FactRuleCollection, WantAction, FactContainer>
    {
        private readonly Func<IEnumerable<IFact>> _getDefaultFactsFunc;

        /// <inheritdoc/>
        public override FactContainer Container { get; }

        /// <inheritdoc/>
        public override FactRuleCollection Rules { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public PriorityFactFactory() : this(null)
        {
        }

        /// <summary>
        /// Constructot.
        /// </summary>
        /// <param name="getDefaultFactsFunc">Function that returns default facts.</param>
        public PriorityFactFactory(Func<IEnumerable<IFact>> getDefaultFactsFunc)
        {
            _getDefaultFactsFunc = getDefaultFactsFunc;
            Container = new FactContainer();
            Rules = new FactRuleCollection();
        }

        /// <inheritdoc/>
        protected override WantAction CreateWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes)
        {
            return new WantAction(wantAction, factTypes);
        }

        /// <inheritdoc/>
        protected override IEnumerable<IFact> GetDefaultFacts(FactContainer container)
        {
            return _getDefaultFactsFunc?.Invoke() ?? base.GetDefaultFacts(container);
        }
    }
}
