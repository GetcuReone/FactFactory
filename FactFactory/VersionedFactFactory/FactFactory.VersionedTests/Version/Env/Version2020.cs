using GetcuReone.FactFactory.Versioned.SpecialFacts;
using System;

namespace FactFactory.VersionedTests.Version.Env
{
    public sealed class Version2020 : BaseDateTimeVersion
    {
        public Version2020() : base(new DateTime(2020, 1, 1))
        {
        }
    }
}
