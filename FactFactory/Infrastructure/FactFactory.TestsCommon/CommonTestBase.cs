using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GivenWhenThen.TestAdapter;

namespace FactFactory.TestsCommon
{
    public abstract class CommonTestBase : TestBase
    {
        protected virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }
    }
}
