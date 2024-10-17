using GetcuReone.FactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class CryptKey : BaseFact<string>
    {
        public CryptKey(string value) : base(value) { }
    }
}
