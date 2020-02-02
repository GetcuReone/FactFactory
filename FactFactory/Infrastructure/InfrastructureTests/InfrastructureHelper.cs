using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InfrastructureTests
{
    public static class InfrastructureHelper
    {
        public static List<FileInfo> GetAllFiles(DirectoryInfo folder)
        {
            List<FileInfo> result = folder.GetFiles().ToList();

            foreach (DirectoryInfo f in folder.GetDirectories())
                result.AddRange(GetAllFiles(f));

            return result;
        }
    }
}
