using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Priority
{
    /// <summary>
    /// Default priority fact factory.
    /// </summary>
    public class PriorityFactFactory : PriorityFactFactoryBase<FactRule, FactRuleCollection, WantAction, FactContainer>
    {
        private readonly Func<IWantActionContext<WantAction, FactContainer>, IEnumerable<IFact>> _getDefaultFactsFunc;

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
        public PriorityFactFactory(Func<IWantActionContext<WantAction, FactContainer>, IEnumerable<IFact>> getDefaultFactsFunc)
        {
            _getDefaultFactsFunc = getDefaultFactsFunc;
            Rules = new FactRuleCollection();
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
