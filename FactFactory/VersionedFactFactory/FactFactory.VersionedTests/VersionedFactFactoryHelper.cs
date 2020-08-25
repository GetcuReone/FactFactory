using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
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

        public static ThenBlock<IFactType> ThenGetVersionType<TFactWork>(this WhenBlock<TFactWork> whenBlock)
            where TFactWork : IFactWork
        {
            return whenBlock.ThenIsNotNull().And("Get type of version.", work => work.InputFactTypes?.GetVersionFactType());
        }

        public static ThenBlock<TFactWork> ThenNotContainVersionType<TFactWork>(this WhenBlock<TFactWork> whenBlock)
            where TFactWork : IFactWork
        {
            return whenBlock
                .ThenIsNotNull()
                .And("Get type of version.", work => Assert.IsNull(work.InputFactTypes?.GetVersionFactType()));
        }

        public static TFact SetVersionParam<TFact>(this TFact fact, IVersionFact version)
            where TFact : IFact
        {
            fact.AddParameter(new FactParameter(VersionedFactParametersCodes.Version, version));
            return fact;
        }
    }
}
