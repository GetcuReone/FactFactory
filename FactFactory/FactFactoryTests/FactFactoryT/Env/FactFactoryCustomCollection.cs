using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using Action = GetcuReone.FactFactory.Entities.WantAction;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryCustomCollection<TCollection> : FactFactoryBase<FactBase, Container, Rule, TCollection, Action>
        where TCollection : FactRuleCollectionBase<FactBase, Rule>, new()
    {
        public override Container Container { get; } = new Container();
        public override TCollection Rules { get; } = new TCollection();

        protected override GetcuReone.FactFactory.Entities.WantAction CreateWantAction(Action<IFactContainer<FactBase>> wantAction, IList<IFactType> factTypes)
        {
            return new Action(wantAction, factTypes);
        }

        protected override Container GetContainerForDerive()
        {
            return (Container)Container.Copy();
        }

        protected override IFactType GetFactType<TGetFact>()
        {
            return new FactType<TGetFact>();
        }
    }
}
