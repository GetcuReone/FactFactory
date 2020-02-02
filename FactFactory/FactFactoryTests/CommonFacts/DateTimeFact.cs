using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
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
            return new GetcuReone.FactFactory.Entities.FactInfo<DateTimeFact>();
        }
    }
}
