using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GwtTestFramework.Entities;

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
