﻿using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;
using Action = GetcuReone.FactFactory.Entities.WantAction;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal class FactFactoryAddRule : GetcuReone.FactFactory.FactFactory
    {
        internal Rule NewRule { get; } = new Rule(ct => default, new List<IFactType>(), new FactType<Input1Fact>());
        protected override IList<Rule> GetRulesForWantAction(Action wantAction, FactContainerBase<FactBase> container, FactRuleCollectionBase<FactBase, Rule> rules)
        {
            rules.Add(NewRule);
            return rules;
        }
    }
}
