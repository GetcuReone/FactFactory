using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Default;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Action = GetcuReone.FactFactory.Default.Entities.WantAction;
using Collection = GetcuReone.FactFactory.Default.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Default.Entities.FactContainer;
using Factory = GetcuReone.FactFactory.Default.FactFactory;
using Rule = GetcuReone.FactFactory.Default.Entities.FactRule;

namespace FactFactoryTests.FactFactoryT.Helpers
{
    internal static class FactFactoryHelper
    {
        internal static GivenBlock<Factory> AndRulesNotNul(this GivenBlock<Factory> givenBlock)
        {
            return givenBlock.And("Rules not null", factory =>
            {
                Assert.IsNotNull(factory.Rules, "Rules cannot be null");
                return factory;
            });
        }

        public static GivenBlock<TFactory> AndAddRules<TFactory>(this GivenBlock<TFactory> givenBlock, FactRuleCollectionBase<FactBase, Rule> factRules)
            where TFactory : FactFactoryBase<FactBase, Container, Rule, Collection, Action>
        {
            return givenBlock.And("Add rules", factory => factory.Rules.AddRange(factRules));
        }

        public static GivenBlock<TFactory> AndAddFact<TFactory>(this GivenBlock<TFactory> givenBlock, FactBase fact)
            where TFactory : FactFactoryBase<FactBase, Container, Rule, Collection, Action>
        {
            return givenBlock.And("Add fact", factory => factory.Container.Add(fact));
        }
    }
}
