using FactFactory.TestsCommon;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactTypeCacheTests.Env
{
    [TestClass]
    public abstract class FactTypeCacheTestBase : CommonTestBase
    {
        protected virtual GivenBlock<object, IFactTypeCache> GivenCreateCahce()
        {
            return Given("Create fact type cache.", () => (IFactTypeCache)new FactTypeCache());
        }
    }
}
