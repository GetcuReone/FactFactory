using GetcuReone.FactFactory;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class OtherFact : BaseFact<DateTime>
    {
        public OtherFact(DateTime fact) : base(fact) { }
    }
}
