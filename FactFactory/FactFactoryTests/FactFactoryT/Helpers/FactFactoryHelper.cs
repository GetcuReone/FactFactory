using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT.Helpers
{
    internal static class FactFactoryHelper
    {
        internal static GivenBlock<IFactFactory, IFactFactory> AndRulesNotNul<TInput>(this GivenBlock<TInput, IFactFactory> givenBlock)
        {
            return givenBlock.And("Rules not null", factory =>
            {
                Assert.IsNotNull(factory.Rules, "Rules cannot be null");
                return factory;
            });
        }
    }
}
