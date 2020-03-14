using GetcuReone.FactFactory.Default.Entities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Default
{
    /// <summary>
    /// Factory default implementation
    /// </summary>
    public class FactFactory : FactFactoryBase<FactBase, FactContainer, FactRule, FactRuleCollection, WantAction>
    {
        /// <summary>
        /// Fact container
        /// </summary>
        public override FactContainer Container { get; } = new FactContainer();

        /// <summary>
        /// Collection of rules for derive facts
        /// </summary>
        public override FactRuleCollection Rules { get; } = new FactRuleCollection();

        /// <summary>
        /// creation method <see cref="WantAction"/>
        /// </summary>
        /// <param name="wantAction">action taken after deriving a fact</param>
        /// <param name="factTypes">facts required to launch an action</param>
        /// <returns></returns>
        protected override WantAction CreateWantAction(Action<IFactContainer<FactBase>> wantAction, IList<IFactType> factTypes)
        {
            return new WantAction(wantAction, factTypes);
        }

        /// <summary>
        /// Get fact type
        /// </summary>
        /// <typeparam name="TGetFact"></typeparam>
        /// <returns></returns>
        protected override IFactType GetFactType<TGetFact>()
        {
            return new FactType<TGetFact>();
        }
    }
}
