using GetcuReone.FactFactory.Versioned;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class CryptKey : VersionedFactBase<string>
    {
        public CryptKey(string value) : base(value)
        {
        }
    }
}
