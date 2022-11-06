using GetcuReone.FactFactory;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class DateTimeFact : BaseFact<DateTime>
    {
        public DateTimeFact(DateTime fact) : base(fact) { }
    }
}
