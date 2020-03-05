using GetcuReone.FactFactory.Versioned.Facts.Versions;
using System;

namespace FactFactory.VersionedTests.Version.Env
{
    public sealed class Version2019 : DateTimeVersionBase
    {
        public Version2019() : base(new DateTime(2019, 1, 1))
        {
        }
    }
}
