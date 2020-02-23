using GetcuReone.FactFactory.Versioned.Facts;

namespace FactFactory.VersionedTests.CommonFacts
{
    /// <summary>
    /// Version 1
    /// </summary>
    public sealed class Version1 : GetcuReone.FactFactory.Versioned.Facts.UintVersion
    {
        public Version1() : base(1) { }
    }
}
