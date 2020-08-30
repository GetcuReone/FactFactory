using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Versioned.Interfaces;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using V_FactFactory = GetcuReone.FactFactory.Versioned.VersionedFactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory
{
    [TestClass]
    public abstract class VersionedFactFactoryTestBase : CommonTestBase
    {
        protected GivenBlock<V_FactFactory> GivenCreateVersionedFactFactory(List<IVersionFact> versions)
        {
            List<IVersionFact> versionsCopy = new List<IVersionFact>(versions);
            return Given("Create versioned fact factory.", () => new V_FactFactory(context => versionsCopy));
        }
    }
}
