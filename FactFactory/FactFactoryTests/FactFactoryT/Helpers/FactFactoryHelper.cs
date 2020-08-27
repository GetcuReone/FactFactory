using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.GwtTestFramework.Entities;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Action = GetcuReone.FactFactory.Entities.WantAction;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using Factory = GetcuReone.FactFactory.FactFactory;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

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

        public static ThenBlock<TFact> ThenFactEquals<TExpectedValue, TFact>(this WhenBlock<TFact> whenBlock, TExpectedValue expectedValue)
            where TFact : FactBase<TExpectedValue>
        {
            return whenBlock
                .ThenIsNotNull()
                .And($"Check assert {typeof(TFact).Name} fact.", fact =>
                {
                    Assert.AreEqual(expectedValue, fact, $"Expected another {fact.GetFactType().FactName} value.");
                });
        }
    }
}
