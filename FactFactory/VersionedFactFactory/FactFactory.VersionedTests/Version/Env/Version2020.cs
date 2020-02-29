using GetcuReone.FactFactory.Versioned.Facts.Versions;
using System;

namespace FactFactory.VersionedTests.Version.Env
{
    public sealed class Version2020 : DateTimeVersionBase
    {
        public Version2020() : base(new DateTime(2020, 1, 1))
        {
        }
    }
}
