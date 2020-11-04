using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.FactRule
{
    [TestClass]
    public abstract class FactRuleTestBase : CommonTestBase
    {
        protected Container Container { get; private set; }
        protected WAction WantAction { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            Container = new Container();
            WantAction = GetWantAction((ResultFact _) => { });
        }
    }
}
