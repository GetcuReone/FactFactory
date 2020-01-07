using FactFactory.Facts;
using FactFactory.Interfaces;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class DateTimeFact : FactBase<DateTime>
    {
        public DateTimeFact(DateTime fact) : base(fact)
        {
        }

        public override IFactInfo GetFactInfo()
        {
            return new FactFactory.Entities.FactInfo<DateTimeFact>();
        }
    }
}
