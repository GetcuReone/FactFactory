﻿using GetcuReone.FactFactory;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class OtherFact : FactBase<DateTime>
    {
        public OtherFact(DateTime fact) : base(fact)
        {
        }
    }
}
