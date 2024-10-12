using GetcuReone.FactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class CertFilePath : BaseFact<string>
    {
        public CertFilePath(string value) : base(value) { }
    }
}
