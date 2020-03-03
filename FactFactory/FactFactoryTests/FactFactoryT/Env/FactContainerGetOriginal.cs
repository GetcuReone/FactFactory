﻿using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Facts;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal class FactContainerGetOriginal : Container
    {
        public override FactContainerBase<FactBase> Copy()
        {
            return this;
        }
    }
}