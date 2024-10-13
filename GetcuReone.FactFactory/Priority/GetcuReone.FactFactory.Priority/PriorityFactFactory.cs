using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Priority
{
    /// <summary>
    /// Default priority fact factory.
    /// </summary>
    public class PriorityFactFactory : BasePriorityFactFactory
    {
        private readonly Func<IWantActionContext, IEnumerable<IFact>>? _getDefaultFactsFunc;

        /// <inheritdoc/>
        public override IFactRuleCollection Rules { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public PriorityFactFactory() : this(null) { }

        /// <summary>
        /// Constructot.
        /// </summary>
        /// <param name="getDefaultFactsFunc">Function that returns default facts.</param>
        public PriorityFactFactory(Func<IWantActionContext, IEnumerable<IFact>>? getDefaultFactsFunc)
        {
            _getDefaultFactsFunc = getDefaultFactsFunc;
            Rules = new FactRuleCollection();
        }

        /// <inheritdoc/>
        protected override IEnumerable<IFact> GetDefaultFacts(IWantActionContext context)
        {
            return _getDefaultFactsFunc?.Invoke(context) ?? base.GetDefaultFacts(context);
        }

        /// <inheritdoc/>
        protected override IFactContainer GetDefaultContainer()
        {
            return new FactContainer();
        }
    }
}
