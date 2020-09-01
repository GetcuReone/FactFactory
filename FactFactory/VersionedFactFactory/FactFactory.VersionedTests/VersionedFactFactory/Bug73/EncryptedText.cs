using GetcuReone.FactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class EncryptedText : FactBase<string>
    {
        public EncryptedText(string value) : base(value)
        {
        }
    }
}
