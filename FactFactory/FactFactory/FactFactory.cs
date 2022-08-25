﻿using System;
using System.Collections.Generic;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Factory default implementation.
    /// </summary>
    public class FactFactory : BaseFactFactory<FactRule, FactRuleCollection, WantAction, FactContainer>
    {
        private readonly Func<IWantActionContext<WantAction, FactContainer>, IEnumerable<IFact>> _getDefaultFactsFunc;

        /// <inheritdoc/>
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
    }
}
