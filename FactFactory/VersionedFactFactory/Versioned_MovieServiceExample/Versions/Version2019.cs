using GetcuReone.FactFactory.Versioned.Versions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Versioned_MovieServiceExample.Versions
{
    public sealed class Version2019 : DateTimeVersionBase
    {
        public Version2019() : base(new DateTime(2019, 1, 1))
        {
        }
    }
}
