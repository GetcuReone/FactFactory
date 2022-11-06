using GetcuReone.FactFactory;
using System.IO;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class CertFileInfo : BaseFact<FileInfo>
    {
        public CertFileInfo(FileInfo value) : base(value) { }
    }
}
