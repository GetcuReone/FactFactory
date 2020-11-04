using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GwtTestFramework.Entities;
using Action = GetcuReone.FactFactory.Entities.WantAction;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;

namespace FactFactory.VersionedTests.VersionedFactFactory.Helpers
{
    public static class VersionedFactFactoryHelper
    {
        public static GivenBlock<TFactory, TFactory> AndAddRules<TInput, TFactory>(this GivenBlock<TInput, TFactory> givenBlock, FactRuleCollectionBase<FactRule> factRules)
            where TFactory : VersionedFactFactoryBase<FactRule, Collection, Action, Container>
        {
            return givenBlock.And("Add rules", factory => factory.Rules.AddRange(factRules));
        }
    }
}
