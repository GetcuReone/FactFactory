using FactFactory.PriorityTests.CommonFacts;
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
        protected GivenBlock<object, IFactFactory> GivenCreateFactFactory()
        {
            return Given("Create PriorityFactFactory.", () => 
                (IFactFactory)new GetcuReone.FactFactory.Priority.PriorityFactFactory(GetPriorityFacts));
        }

        protected IEnumerable<IFact> GetPriorityFacts(IWantActionContext context)
        {
            return new List<IFact>
            {
                new Priority1(),
                new Priority2(),
            };
        }
    }
}
