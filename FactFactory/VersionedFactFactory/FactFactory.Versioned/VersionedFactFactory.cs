using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Versioned.Entities;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Default implementation of versioned fact factory <see cref="VersionedFactFactoryBase{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>.
    /// </summary>
    public class VersionedFactFactory : VersionedFactFactoryBase<FactRule, FactRuleCollection, WantAction, VersionedFactContainer>
    {
        private readonly Func<IWantActionContext<WantAction, VersionedFactContainer>, IEnumerable<IFact>> _getDefaultFactsFunc;

        /// <summary>
        /// Rule collection.
        /// </summary>
        public override FactRuleCollection Rules { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public VersionedFactFactory() : this(null)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="getDefaultFactsFunc">Function that returns default facts.</param>
        public VersionedFactFactory(Func<IWantActionContext<WantAction, VersionedFactContainer>, IEnumerable<IFact>> getDefaultFactsFunc)
        {
            _getDefaultFactsFunc = getDefaultFactsFunc;
            Rules = new FactRuleCollection();
        }

        /// <inheritdoc/>
        protected override IEnumerable<IFact> GetDefaultFacts(IWantActionContext<WantAction, VersionedFactContainer> context)
        {
            return _getDefaultFactsFunc?.Invoke(context) ?? base.GetDefaultFacts(context);
        }

        /// <inheritdoc/>
        protected override WantAction CreateWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes)
        {
            return new WantAction(wantAction, factTypes);
        }

        /// <inheritdoc/>
        protected override VersionedFactContainer GetDefaultContainer()
        {
            return new VersionedFactContainer();
        }
    }
}
