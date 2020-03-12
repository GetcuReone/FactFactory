using GetcuReone.FactFactory.Interfaces;
using GivenWhenThen.TestAdapter.Entities;

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
