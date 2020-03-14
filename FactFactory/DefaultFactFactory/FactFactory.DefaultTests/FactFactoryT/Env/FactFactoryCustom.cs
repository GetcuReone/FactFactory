using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Default;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using Action = GetcuReone.FactFactory.Default.Entities.WantAction;
using Collection = GetcuReone.FactFactory.Default.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Default.Entities.FactContainer;
using Rule = GetcuReone.FactFactory.Default.Entities.FactRule;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryCustom : FactFactoryBase<FactBase, Container, Rule, Collection, Action>
    {
        public override Container Container => container;
        internal Container container = new Container();
        public override Collection Rules => collection;
        internal Collection collection = new Collection();

        internal List<FactBase> DefaultFacts { get; } = new List<FactBase>();

        protected override Action CreateWantAction(Action<IFactContainer<FactBase>> wantAction, IList<IFactType> factTypes)
        {
            return new Action(wantAction, factTypes);
        }

        protected override IFactType GetFactType<TGetFact>()
        {
            return new FactType<TGetFact>();
        }
        protected override IEnumerable<FactBase> GetDefaultFacts(FactContainerBase<FactBase> container)
        {
            return DefaultFacts;
        }
    }
}
