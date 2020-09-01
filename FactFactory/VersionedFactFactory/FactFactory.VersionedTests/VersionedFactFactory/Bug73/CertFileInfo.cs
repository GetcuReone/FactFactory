using GetcuReone.FactFactory;
using System.IO;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class CertFileInfo : FactBase<FileInfo>
    {
        public CertFileInfo(FileInfo value) : base(value)
        {
        }
    }
}
