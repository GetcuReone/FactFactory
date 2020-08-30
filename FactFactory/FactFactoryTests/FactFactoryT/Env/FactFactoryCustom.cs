﻿using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
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
        public List<WantFactsInfo<Action, Container>> W_FactsInfos => WantFactsInfos;

        public override Collection Rules => collection;
        internal Collection collection = new Collection();

        internal List<FactBase> DefaultFacts { get; } = new List<FactBase>();

        protected override IEnumerable<IFact> GetDefaultFacts(IWantActionContext<GetcuReone.FactFactory.Entities.WantAction, Container> context)
        {
            return DefaultFacts;
        }

        protected override Action CreateWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes)
        {
            return new Action(wantAction, factTypes);
        }

        protected override Container GetDefaultContainer()
        {
            return new Container();
        }
    }
}
