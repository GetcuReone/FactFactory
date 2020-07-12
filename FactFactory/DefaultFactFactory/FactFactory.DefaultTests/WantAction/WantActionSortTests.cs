using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactory.DefaultTests.WantAction
{
    [TestClass]
    public sealed class WantActionSortTests : CommonTestBase<FactBase>
    {
        private Container Container { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Container = new Container();
        }

        private WAction GetWantAction<TFact>(Action<TFact> action)
            where TFact : FactBase
        {
            return new WAction(
                container => action(container.GetFact<TFact>()),
                new List<IFactType> { GetFactType<TFact>() });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(GetcuReoneTC.Unit)]
        [Description("Sort wantActions.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void SortWantActionsTestCase()
        {
            WAction firstWantAction = GetWantAction((ResultFact _) => { });
            WAction secondWantAction = GetWantAction((OtherFact _) => { });
            WAction thirdWantAction = GetWantAction((CannotDerived<ResultFact> _) => { });

            Given("Create list.", () => new List<WAction> { firstWantAction, secondWantAction, thirdWantAction })
                .When("Sort list.", list =>
                    list.Sort(new WantActionComparer<FactBase, WAction, Container>(Container)))
                .Then("Check list.", list =>
                {
                    Assert.AreEqual(firstWantAction, list[0]);
                    Assert.AreEqual(secondWantAction, list[1]);
                    Assert.AreEqual(thirdWantAction, list[2]);
                });
        }
    }
}
