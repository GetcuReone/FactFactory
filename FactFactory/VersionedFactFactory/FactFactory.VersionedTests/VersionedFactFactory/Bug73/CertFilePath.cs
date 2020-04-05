using GetcuReone.FactFactory.Versioned;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class CertFilePath : VersionedFactBase<string>
    {
        public CertFilePath(string value) : base(value)
        {
        }
    }
}
