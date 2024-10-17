using GetcuReone.FactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class DecryptedText : BaseFact<string>
    {
        public DecryptedText(string value) : base(value) { }
    }
}
