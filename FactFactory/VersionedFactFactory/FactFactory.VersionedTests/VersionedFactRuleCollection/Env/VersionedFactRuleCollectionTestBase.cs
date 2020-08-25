using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Entities;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Collection = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRuleCollection;

namespace FactFactory.VersionedTests.VersionedFactRuleCollection.Env
{
    [TestClass]
    public abstract class VersionedFactRuleCollectionTestBase : CommonTestBase
    {
        protected GivenBlock<Collection> GivenCreateCollection(bool isReadOnly = false)
        {
            return Given("Create collection", () => new Collection(Enumerable.Empty<FactRule>(), isReadOnly));
        }
    }
}
