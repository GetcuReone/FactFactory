using GetcuReone.FactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class CertFilePath : FactBase<string>
    {
        public CertFilePath(string value) : base(value)
        {
        }
    }
}
