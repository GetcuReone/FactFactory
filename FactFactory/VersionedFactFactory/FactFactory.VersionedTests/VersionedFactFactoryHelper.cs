using GetcuReone.FactFactory.Versioned;
using GetcuReone.GwtTestFramework.Entities;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests
{
    public static class VersionedFactFactoryHelper
    {
        public static ThenBlock<TFact> ThenFactEquals<TExpectedValue, TFact>(this WhenBlock<TFact> whenBlock, TExpectedValue expectedValue)
            where TFact : VersionedFactBase<TExpectedValue>
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
