using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GwtTestFramework.Entities;

namespace FactFactoryTests.FactType
{
    public static class FactTypeTestHelper
    {
        public static GivenBlock<IFact, IFactType> AndCreateFactType<TInput>(this GivenBlock<TInput, IFact> givenBlock)
        {
            return givenBlock.And("Create factInfo", fact => fact.GetFactType());
        }
    }
}
