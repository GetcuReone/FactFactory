﻿using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Versioned.Facts;
using GetcuReone.FactFactory.Versioned.Interfaces;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using V_FactFactory = GetcuReone.FactFactory.Versioned.VersionedFactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory
{
    [TestClass]
    public abstract class VersionedFactFactoryTestBase : CommonTestBase<VersionedFactBase>
    {
        protected GivenBlock<V_FactFactory> GivenCreateVersionedFactFactory(List<IVersionFact> versions)
        {
            List<IVersionFact> versionsCopy = new List<IVersionFact>(versions);
            return Given("Create versioned fact factory", () => new V_FactFactory(() => versionsCopy));
        }
    }
}