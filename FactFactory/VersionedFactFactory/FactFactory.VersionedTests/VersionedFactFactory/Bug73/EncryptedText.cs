﻿using GetcuReone.FactFactory.Versioned;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class EncryptedText : VersionedFactBase<string>
    {
        public EncryptedText(string value) : base(value)
        {
        }
    }
}
