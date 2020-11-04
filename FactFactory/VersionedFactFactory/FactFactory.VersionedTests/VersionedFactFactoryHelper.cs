using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using GetcuReone.GwtTestFramework.Entities;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests
{
    public static class VersionedFactFactoryHelper
    {
        public static ThenBlock<TFactWork, IFactType> ThenGetVersionType<TInput, TFactWork>(this WhenBlock<TInput, TFactWork> whenBlock)
            where TFactWork : IFactWork
        {
            return whenBlock.ThenIsNotNull().And("Get type of version.", work => work.InputFactTypes?.GetVersionFactType());
        }

        public static ThenBlock<TFactWork, TFactWork> ThenNotContainVersionType<TInput, TFactWork>(this WhenBlock<TInput, TFactWork> whenBlock)
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
