using GetcuReone.FactFactory.Versioned.Facts;

namespace FactFactory.VersionedTests.CommonFacts
{
    /// <summary>
    /// Version 1
    /// </summary>
    public sealed class V1 : GetcuReone.FactFactory.Versioned.Facts.UintVersion
    {
        public V1() : base(1) { }
    }
}
