using GetcuReone.FactFactory.Interfaces;
using JwtTestAdapter.Entities;

namespace FactFactoryTests.FactType
{
    public static class FactTypeTestHelper
    {
        public static GivenBlock<IFactType> AndCreateFactType(this GivenBlock<IFact> givenBlock)
        {
            return givenBlock.And("Create factInfo", fact => fact.GetFactType());
        }
    }
}
