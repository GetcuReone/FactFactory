using FactFactory.PriorityTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FactFactory.PriorityTests.PriorityFactFactory.Env
{
    [TestClass]
    public abstract class PriorityFactFactoryTestBase : PriorityTests.PriorityFactFactoryTestBase
    {
        protected GivenBlock<GetcuReone.FactFactory.Priority.PriorityFactFactory> GivenCreateFactFactory()
        {
            return Given("Create PriorityFactFactory.", () => 
                new GetcuReone.FactFactory.Priority.PriorityFactFactory(GetPriorityFacts));
        }

        protected IEnumerable<IFact> GetPriorityFacts()
        {
            return new List<IFact>
            {
                new Priority1(),
                new Priority2(),
            };
        }
    }
}
