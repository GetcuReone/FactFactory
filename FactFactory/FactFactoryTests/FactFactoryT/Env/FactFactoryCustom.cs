﻿using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using Action = GetcuReone.FactFactory.Entities.WantAction;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryCustom : FactFactoryBase<Rule, Collection, Action, Container>
    {
        public List<Action> W_Actions => WantActions;
        public override Container Container => container;
        internal Container container = new Container();
        public override Collection Rules => collection;
        internal Collection collection = new Collection();

        internal List<FactBase> DefaultFacts { get; } = new List<FactBase>();

        protected override IEnumerable<IFact> GetDefaultFacts(Container container)
        {
            return DefaultFacts;
        }

        protected override GetcuReone.FactFactory.Entities.WantAction CreateWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes)
        {
            return new Action(wantAction, factTypes);
        }
    }
}