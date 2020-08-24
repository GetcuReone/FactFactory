using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Factory default implementation.
    /// </summary>
    public class FactFactory : FactFactoryBase<FactRule, FactRuleCollection, WantAction, FactContainer>
    {
        /// <summary>
        /// Fact container.
        /// </summary>
        public override FactContainer Container { get; } = new FactContainer();

        /// <summary>
        /// Collection of rules for derive facts
        /// </summary>
        public override FactRuleCollection Rules { get; } = new FactRuleCollection();

        /// <summary>
        /// creation method <see cref="WantAction"/>
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        /// <returns></returns>
        protected override WantAction CreateWantAction(Action<IFactContainer> wantAction, List<IFactType> factTypes)
        {
            return new WantAction(wantAction, factTypes);
        }

        /// <inheritdoc/>
        protected override WantAction CreateWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes)
        {
            return new WantAction(wantAction, factTypes);
        }
    }
}
