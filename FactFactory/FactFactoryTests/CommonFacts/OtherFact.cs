using FactFactory.Facts;
using FactFactory.Interfaces;
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
