using FactFactory.PriorityTests.CommonFacts;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FactFactory.PriorityTests.PriorityFactFactory.Env
{
    [TestClass]
    public abstract class PriorityFactFactoryTestBase : PriorityTests.PriorityFactFactoryTestBase
    {
        protected GivenBlock<object, GetcuReone.FactFactory.Priority.PriorityFactFactory> GivenCreateFactFactory()
        {
            return Given("Create PriorityFactFactory.", () => 
                new GetcuReone.FactFactory.Priority.PriorityFactFactory(GetPriorityFacts));
        }

        protected IEnumerable<IFact> GetPriorityFacts(IWantActionContext<WantAction, FactContainer> context)
        {
            return new List<IFact>
            {
                new Priority1(),
                new Priority2(),
            };
        }
    }
}
