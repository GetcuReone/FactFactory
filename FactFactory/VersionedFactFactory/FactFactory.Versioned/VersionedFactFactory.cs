using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Versioned.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Default implementation of versioned fact factory <see cref="VersionedFactFactoryBase{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>.
    /// </summary>
    public class VersionedFactFactory : VersionedFactFactoryBase<FactRule, FactRuleCollection, WantAction, FactContainer>
    {
        private readonly Func<IWantActionContext<WantAction, FactContainer>, IEnumerable<IFact>> _getDefaultFactsFunc;

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
        protected override WantAction CreateWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes, FactWorkOption option)
        {
            return new WantAction(wantAction, factTypes, option);
        }

        /// <inheritdoc/>
        protected override WantAction CreateWantAction(Func<IEnumerable<IFact>, ValueTask> wantAction, List<IFactType> factTypes, FactWorkOption option)
        {
            return new WantAction(wantAction, factTypes, option);
        }

        /// <inheritdoc/>
        protected override FactContainer GetDefaultContainer()
        {
            return new FactContainer();
        }
    }
}
