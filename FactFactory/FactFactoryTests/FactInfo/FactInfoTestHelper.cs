using FactFactory.Interfaces;
using JwtTestAdapter.Entities;

namespace FactFactoryTests.FactInfo
{
    public static class FactInfoTestHelper
    {
        public static GivenBlock<IFactInfo> AndCreateFactInfo(this GivenBlock<IFact> givenBlock)
        {
            return givenBlock.And("Create factInfo", fact => fact.GetFactInfo());
        }
    }
}
