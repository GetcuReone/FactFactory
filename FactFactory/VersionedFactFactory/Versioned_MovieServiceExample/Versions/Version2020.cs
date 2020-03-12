using GetcuReone.FactFactory.Versioned.Versions;
using System;

namespace Versioned_MovieServiceExample.Versions
{
    public sealed class Version2020 : DateTimeVersionBase
    {
        public Version2020() : base(new DateTime(2020, 1, 1))
        {
        }
    }
}
