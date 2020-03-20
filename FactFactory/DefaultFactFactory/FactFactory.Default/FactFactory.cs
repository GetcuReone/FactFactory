using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Factory default implementation.
    /// </summary>
    public class FactFactory : FactFactoryBase<FactBase, FactContainer, FactRule, FactRuleCollection, WantAction>
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
        protected override WantAction CreateWantAction(Action<IFactContainer<FactBase>> wantAction, IReadOnlyCollection<IFactType> factTypes)
        {
            return new WantAction(wantAction, factTypes);
        }

        /// <summary>
        /// Get fact type.
        /// </summary>
        /// <typeparam name="TGetFact"></typeparam>
        /// <returns>Fact type.</returns>
        protected override IFactType GetFactType<TGetFact>()
        {
            return new FactType<TGetFact>();
        }
    }
}
