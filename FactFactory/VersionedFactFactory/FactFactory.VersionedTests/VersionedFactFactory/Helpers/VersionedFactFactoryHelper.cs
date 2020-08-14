﻿using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GwtTestFramework.Entities;
using Action = GetcuReone.FactFactory.Versioned.Entities.VersionedWantAction;
using Collection = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRuleCollection;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;

namespace FactFactory.VersionedTests.VersionedFactFactory.Helpers
{
    public static class VersionedFactFactoryHelper
    {
        public static GivenBlock<TFactory> AndAddRules<TFactory>(this GivenBlock<TFactory> givenBlock, FactRuleCollectionBase<Rule> factRules)
            where TFactory : VersionedFactFactoryBase<Rule, Collection, Action, Container>
        {
            return givenBlock.And("Add rules", factory => factory.Rules.AddRange(factRules));
        }
    }
}
