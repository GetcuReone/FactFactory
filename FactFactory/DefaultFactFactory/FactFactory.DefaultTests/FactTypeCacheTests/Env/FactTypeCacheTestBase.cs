using FactFactory.TestsCommon;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.DefaultTests.FactTypeCacheTests.Env
{
    [TestClass]
    public abstract class FactTypeCacheTestBase : CommonTestBase
    {
        protected virtual GivenBlock<IFactTypeCache> GivenCreateCahce()
        {
            return Given("Create fact type cache.", () => (IFactTypeCache)new FactTypeCache());
        }
    }
}
