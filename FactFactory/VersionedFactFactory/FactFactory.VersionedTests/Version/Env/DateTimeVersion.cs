using GetcuReone.FactFactory.Versioned.Facts.Versions;
using System;

namespace FactFactory.VersionedTests.Version.Env
{
    internal sealed class DateTimeVersion : DateTimeVersionBase
    {
        public DateTimeVersion(DateTime version) : base(version)
        {
        }
    }
}
