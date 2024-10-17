using GetcuReone.FactFactory.Versioned.SpecialFacts;
using System;

namespace FactFactory.VersionedTests.Version.Env
{
    public sealed class Version2019 : BaseDateTimeVersion
    {
        public Version2019() : base(new DateTime(2019, 1, 1))
        {
        }
    }
}
