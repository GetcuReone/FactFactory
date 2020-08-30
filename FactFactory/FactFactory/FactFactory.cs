using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Factory default implementation.
    /// </summary>
    public class FactFactory : FactFactoryBase<FactRule, FactRuleCollection, WantAction, FactContainer>
    {
        private readonly Func<IWantActionContext<WantAction, FactContainer>, IEnumerable<IFact>> _getDefaultFactsFunc;

        /// <summary>
        /// Collection of rules for derive facts
        /// </summary>
        public override FactRuleCollection Rules { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public FactFactory() : this(null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="getDefaultFactsFunc">Function that returns a list of facts by default.</param>
        public FactFactory(Func<IWantActionContext<WantAction, FactContainer>, IEnumerable<IFact>> getDefaultFactsFunc)
        {
            _getDefaultFactsFunc = getDefaultFactsFunc;
            Rules = new FactRuleCollection();
        }

        /// <inheritdoc/>
        protected override FactContainer GetDefaultContainer()
        {
            return new FactContainer();
        }

        /// <inheritdoc/>
        protected override IEnumerable<IFact> GetDefaultFacts(IWantActionContext<WantAction, FactContainer> context)
        {
            return _getDefaultFactsFunc?.Invoke(context);
        }

        /// <inheritdoc/>
        protected override WantAction CreateWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes)
        {
            return new WantAction(wantAction, factTypes);
        }
    }
}
