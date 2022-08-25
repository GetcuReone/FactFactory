using System;
using System.Collections.Generic;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Default implementation of versioned fact factory <see cref="BaseVersionedFactFactory{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>.
    /// </summary>
    public class VersionedFactFactory : BaseVersionedFactFactory<FactRule, FactRuleCollection, WantAction, FactContainer>
    {
        private readonly Func<IWantActionContext<WantAction, FactContainer>, IEnumerable<IFact>> _getDefaultFactsFunc;

        /// <inheritdoc/>
        public override FactRuleCollection Rules { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public VersionedFactFactory() : this(null) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="getDefaultFactsFunc">Function that returns default facts.</param>
        public VersionedFactFactory(Func<IWantActionContext<WantAction, FactContainer>, IEnumerable<IFact>> getDefaultFactsFunc)
        {
            _getDefaultFactsFunc = getDefaultFactsFunc;
            Rules = new FactRuleCollection();
        }

        /// <inheritdoc/>
        protected override IEnumerable<IFact> GetDefaultFacts(IWantActionContext<WantAction, FactContainer> context)
        {
            return _getDefaultFactsFunc?.Invoke(context) ?? base.GetDefaultFacts(context);
        }

        /// <inheritdoc/>
        protected override FactContainer GetDefaultContainer()
        {
            return new FactContainer();
        }
    }
}
