using GetcuReone.FactFactory.Default;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class DateTimeFact : FactBase<DateTime>
    {
        public DateTimeFact(DateTime fact) : base(fact)
        {
        }
    }
}
