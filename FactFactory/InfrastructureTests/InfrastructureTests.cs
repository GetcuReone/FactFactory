using JwtTestAdapter;
using JwtTestAdapter.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;

namespace InfrastructureTests
{
    [TestClass]
    public class InfrastructureTests : TestBase
    {
#if DEBUG
        private readonly string buildMode = "Debug";
#else
        private readonly string buildMode = "Release";
#endif

        [Timeout(Timeouts.Minute.One)]
        [TestMethod]
        [Description("[infrastructure] Check for all attribute Timeout tests")]
        public void AllHaveTimeoutTestCase()
        {
            List<string> assemblyPaths = new List<string>
            {
                @"..\..\..\..\FactFactoryTests\bin\" + buildMode + @"\netcoreapp3.0\FactFactoryTests.dll",
                @"..\..\..\..\InfrastructureTests\bin\" + buildMode + @"\netcoreapp3.0\InfrastructureTests.dll",
            };

            Given("We get all the test builds", () => assemblyPaths.ConvertAll(name => Assembly.LoadFrom(name)))
                .And("We get all types", assemblies => assemblies.SelectMany(assembly => assembly.GetTypes()).ToList())
                .And("Get all classes with tests", types => types.Where(type => type.GetCustomAttribute(typeof(TestClassAttribute)) != null).ToList())
                .When("Return all test methods", classes =>
                {
                    List<MemberInfo> result = new List<MemberInfo>();

                    foreach (var cl in classes)
                    {
                        foreach (var method in cl.GetMethods().Where(method => method.GetCustomAttribute(typeof(TestMethodAttribute)) != null))
                        {
                            result.Add(method);
                            LoggingHelper.Info($"test method {cl.FullName}.{method.Name}()");
                        }
                    }

                    return result;
                })
                .Then("Check timeouts", methods =>
                {
                    foreach (var method in methods)
                    {
                        if (method.GetCustomAttribute(typeof(TimeoutAttribute)) == null)
                            Assert.Fail($"method {method.DeclaringType.FullName}.{method.Name} does not have an TimeoutAttribute");
                    }
                });
        }

        [Timeout(Timeouts.Minute.One)]
        [TestMethod]
        [Description("[infrastructure] Checking the presence of all the necessary files in the nugget package")]
        public void NugetHaveNeedFilesTestCase()
        {
            Given("Get folder with .nupkg", () =>
            {
                var currenFolder = new DirectoryInfo(System.Environment.CurrentDirectory);
                string nugetFolderPath = Path.Combine(
                    currenFolder.Parent.Parent.Parent.Parent.FullName,
                    "NugetProject",
                    "bin",
                    buildMode);
                return new DirectoryInfo(nugetFolderPath);
            })
                .And("Get file .nupkg", nugetFolder => 
                {
                    return nugetFolder.GetFiles()
                        .Where(file => file.Name.Contains(".nupkg"))
                        .OrderBy(file => file.CreationTime)
                        .Last();
                })
                .When("Extract the contents of the package", nugetFileInfo => 
                {
                    using (FileStream nupkgStream = nugetFileInfo.OpenRead())
                    {
                        using (var archive = new ZipArchive(nupkgStream, ZipArchiveMode.Read))
                        {
                            return archive.Entries.Select(entry => entry.FullName).ToArray();
                        }
                    }
                })
                .Then("Check archive .nupkg", fileNames => 
                {
                    var files = new string[]
                            {
                                "lib/netstandard2.0/FactFactory.dll",
                                "lib/netstandard2.0/FactFactory.xml",
                                "LICENSE-2.0.txt"
                            };

                    foreach (string file in files)
                        Assert.IsTrue(fileNames.Any(fileFullName => fileFullName == file), $"The archive does not contain a file {file}");
                });
        }
    }
}
