using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Collection = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRuleCollection;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;

namespace FactFactory.VersionedTests.VersionedFactRuleCollection.Env
{
    [TestClass]
    public abstract class VersionedFactRuleCollectionTestBase : CommonTestBase<VersionedFactBase>
    {
        protected GivenBlock<Collection> GivenCreateCollection(bool isReadOnly = false)
        {
            return Given("Create collection", () => new Collection(Enumerable.Empty<Rule>(), isReadOnly));
        }
    }
}
