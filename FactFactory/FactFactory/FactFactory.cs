using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory
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
        /// Get copy container
        /// </summary>
        /// <returns></returns>
        protected override FactContainer GetContainerForDerive()
        {
            var container = new FactContainer(Container);

            if (container.TryGetFact<StartDateOfDerive>(out var fact))
                container.Remove(fact);
            if (container.TryGetFact<DerivingFacts>(out var fact1))
                container.Remove(fact1);

            container.Add(new StartDateOfDerive(DateTime.Now));
            container.Add(new DerivingFacts(WantActions.SelectMany(w => w.InputFactTypes).ToList()));

            return container;
        }

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
