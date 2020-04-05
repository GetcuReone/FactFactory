using GetcuReone.FactFactory.Versioned;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class DecryptedText : VersionedFactBase<string>
    {
        public DecryptedText(string value) : base(value)
        {
        }
    }
}
