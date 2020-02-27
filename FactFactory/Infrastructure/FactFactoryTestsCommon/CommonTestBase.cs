using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GivenWhenThen.TestAdapter;

namespace FactFactoryTestsCommon
{
    public abstract class CommonTestBase : TestBase
    {
        protected virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }
    }
}
