using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Versioned.Interfaces;
using GivenWhenThen.TestAdapter.Entities;
using System.Collections.Generic;
using V_FactFactory = GetcuReone.FactFactory.Versioned.VersionedFactFactory;
using WAction = GetcuReone.FactFactory.Versioned.Entities.VersionedWantAction;
using GetcuReone.FactFactory.Versioned.Facts;
using System;
using GetcuReone.FactFactory.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.VersionedTests.VersionedFactFactory
{
    [TestClass]
    public abstract class VersionedFactFactoryTestBase : CommonTestBase
    {
        protected GivenBlock<V_FactFactory> GivenCreateVersionedFactFactory(List<IVersionFact> versions)
        {
            List<IVersionFact> versionsCopy = new List<IVersionFact>(versions);
            return Given("Create versioned fact factory", () => new V_FactFactory(() => versionsCopy));
        }

        protected InvalidDeriveOperationException<VersionedFactBase, WAction> ExpectedDeriveException(Action action)
        {
            return ExpectedDeriveException<VersionedFactBase, WAction>(action);
        }
    }
}
