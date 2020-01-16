using JwtTestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    internal static class FactFactoryHelper
    {
        internal static GivenBlock<FactFactory.FactFactory> AndRulesNotNul(this GivenBlock<FactFactory.FactFactory> givenBlock)
        {
            return givenBlock.And("Rules not null", factory =>
            {
                Assert.IsNotNull(factory.Rules, "Rules cannot be null");
                return factory;
            });
        }
    }
}
