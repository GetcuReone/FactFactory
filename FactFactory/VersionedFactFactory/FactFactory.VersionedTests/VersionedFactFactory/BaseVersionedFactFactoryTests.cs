﻿using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using V_FactFactory = GetcuReone.FactFactory.Versioned.VersionedFactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory
{
    [TestClass]
    public abstract class BaseVersionedFactFactoryTests : CommonTestBase
    {
        protected GivenBlock<object, IFactFactory> GivenCreateVersionedFactFactory()
        {
            return Given("Create versioned fact factory.", () => (IFactFactory)new V_FactFactory(context => GetDefaultFacts()));
        }

        private List<IFact> GetDefaultFacts()
        {
            return new List<IFact>
            {
                new Version1(),
                new Version2(),
                new Priority1(),
            };
        }
    }
}
