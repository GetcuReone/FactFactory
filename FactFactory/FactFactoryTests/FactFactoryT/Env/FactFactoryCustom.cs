using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using Action = GetcuReone.FactFactory.Entities.WantAction;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryCustom : FactFactoryBase<FactBase, Container, Rule, Collection, Action>
    {
        public override Container Container => container;
        internal Container container = new Container();
        public override Collection Rules => collection;
        internal Collection collection = new Collection();

        protected override GetcuReone.FactFactory.Entities.WantAction CreateWantAction(Action<IFactContainer<FactBase>> wantAction, IList<IFactType> factTypes)
        {
            return new Action(wantAction, factTypes);
        }

        protected override IFactType GetFactType<TGetFact>()
        {
            return new FactType<TGetFact>();
        }
    }
}
