using GetcuReone.FactFactory.Interfaces;
using JwtTestAdapter.Entities;

namespace FactFactoryTests.FactInfo
{
    public static class FactInfoTestHelper
    {
        public static GivenBlock<IFactType> AndCreateFactType(this GivenBlock<IFact> givenBlock)
        {
            return givenBlock.And("Create factInfo", fact => fact.GetFactType());
        }
    }
}
