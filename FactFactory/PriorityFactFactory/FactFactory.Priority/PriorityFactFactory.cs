﻿using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Priority
{
    /// <summary>
    /// Default priority fact factory.
    /// </summary>
    public class PriorityFactFactory : BasePriorityFactFactory<FactRule, FactRuleCollection, WantAction>
    {
        private readonly Func<IWantActionContext<WantAction>, IEnumerable<IFact>> _getDefaultFactsFunc;

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
        public PriorityFactFactory(Func<IWantActionContext<WantAction>, IEnumerable<IFact>> getDefaultFactsFunc)
        {
            _getDefaultFactsFunc = getDefaultFactsFunc;
            Rules = new FactRuleCollection();
        }

        /// <inheritdoc/>
        protected override IEnumerable<IFact> GetDefaultFacts(IWantActionContext<WantAction> context)
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
