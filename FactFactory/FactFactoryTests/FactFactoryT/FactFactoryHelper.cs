using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Facts;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Factory = GetcuReone.FactFactory.FactFactory;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

namespace FactFactoryTests.FactFactoryT
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

        public static GivenBlock<Factory> AndAddRules(this GivenBlock<Factory> givenBlock, FactRuleCollectionBase<FactBase, Rule> factRules)

        {
            return givenBlock.And("Add rules", factory => factory.Rules.AddRange(factRules));
        }
    }
}
