using JwtTestAdapter;
using JwtTestAdapter.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        [Description("[infrastructure] Checking the presence of all the necessary files in the nugget package")]
        public void NugetHaveNeedFilesTestCase()
        {
            Given("Get folder with .nupkg", () =>
            {
                var currenFolder = new DirectoryInfo(System.Environment.CurrentDirectory);
                string nugetFolderPath = Path.Combine(
                    currenFolder.Parent.Parent.Parent.Parent.Parent.FullName,
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

        [Timeout(Timeouts.Minute.One)]
        [TestMethod]
        [Description("[infrastructure] Check for all attribute Timeout tests")]
#if (!LOCALDEVBUILD)
        [Ignore]
#endif
        public void AllHaveTimeoutTestCase()
        {
            string partNameAssemblies = "FactFactory";

            Given("Get all file", () => InfrastructureHelper.GetAllFiles(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.Parent.Parent))
                .And("Get all assemblies", files => files.Where(file => file.Name.Contains(".dll")))
                .And($"Includ only {partNameAssemblies} assemblies", files => files.Where(file => file.Name.Contains(partNameAssemblies)))
                .And($"Include only tests assemlies", 
                    files => files
                        .Where(file => file.Name.Contains("Tests.dll") 
                            && !file.FullName.Contains("TestAdapter.dll")
                            && !file.FullName.Contains("obj")
                            && file.FullName.Contains(buildMode))
                        .ToList())
                .And("Get assembly infos", files => 
                    files.Select(file => 
                    {
                        LoggingHelper.Info($"test assembly {file.FullName}");
                        return Assembly.LoadFrom(file.FullName);
                    }).ToList())
                .And("Get types", assemblies => assemblies.SelectMany(assembly => assembly.GetTypes()))
                .And("Get test classes", types => types.Where(type => type.GetCustomAttribute(typeof(TestClassAttribute)) != null))
                .When("Get test methods", typeClasses =>
                {
                    var result = new List<MemberInfo>();

                    foreach (var cl in typeClasses)
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
                    List<MemberInfo> invalidMethods = methods.Where(method => method.GetCustomAttribute(typeof(TestMethodAttribute)) == null).ToList();

                    if (invalidMethods.Count != 0)
                    {
                        Assert.Fail("Methods dont have TestMethodAttribute:\n" + string.Join("\n", invalidMethods.Select(method => $"{method.DeclaringType.FullName}.{method.Name}")));
                    }
                });
        }

        [Timeout(Timeouts.Minute.One)]
        [TestMethod]
        [Description("[infrastructure] all namespaces start with GetcuReone.ComboPatterns")]
#if (!LOCALDEVBUILD)
        [Ignore]
#endif
        public void AllNamespacesStartWithGetcuReoneTestCase()
        {
            string beginNamespace = "GetcuReone";
            string partNameAssemblies = "FactFactory";

            Given("Get all file", () => InfrastructureHelper.GetAllFiles(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.Parent.Parent))
                .And("Get all assemblies", files => files.Where(file => file.Name.Contains(".dll")))
                .And($"Includ only {partNameAssemblies} assemblies", files => files.Where(file => file.Name.Contains(partNameAssemblies)))
                .And($"Include only library assemlies",
                    files => files
                        .Where(file => !file.Name.Contains("Tests.dll")
                            && !file.FullName.Contains("TestAdapter.dll")
                            && !file.FullName.Contains("obj")
                            && file.FullName.Contains(buildMode)))
                .And($"Exclude duplicate",
                    files => files
                    .DistinctByFunc((x, y) => x.Name == y.Name)
                    .ToList())
                .And("Get assembly infos",
                    files =>
                        files.Select(file =>
                        {
                            LoggingHelper.Info($"test assembly {file.FullName}");
                            return Assembly.LoadFrom(file.FullName);
                        }).ToList())

                .When("Get types", assemblies => assemblies.SelectMany(assembly => assembly.GetTypes()))
                .Then("Check types", types =>
                {
                    var invalidTypes = new List<Type>();

                    foreach (Type type in types)
                    {
                        if (type.FullName.Length <= beginNamespace.Length)
                            invalidTypes.Add(type);
                        else if (!type.FullName.Substring(0, beginNamespace.Length).Equals(beginNamespace, StringComparison.Ordinal))
                            invalidTypes.Add(type);
                    }

                    if (invalidTypes.Count != 0)
                    {
                        Assert.Fail($"Invalid types: \n{string.Join("\n", invalidTypes.ConvertAll(type => type.FullName))}");
                    }
                });
        }

        [Timeout(Timeouts.Minute.One)]
        [TestMethod]
        [Description("[infrastructure] assemblies have major version")]
        public void AssembliesHaveMajorVersionTestCase()
        {
            string[] includeAssemblies = new string[]
            {
                Path.Combine("NugetProject", "bin", buildMode, "netstandard2.0", "NugetProject.dll"),
                Path.Combine("JwtTestAdapter", "bin", buildMode, "netstandard2.0", "JwtTestAdapter.dll"),
            };
            string majorVersion = Environment.GetEnvironmentVariable("majorVersion");
            string excpectedAssemblyVersion = majorVersion != null
                ? $"{majorVersion}.0.0.0"
                : "1.0.0.0";

            string partNameAssemblies = "FactFactory";

            Given("Get all file", () => InfrastructureHelper.GetAllFiles(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.Parent.Parent))
                .And("Get all assemblies", files => files.Where(file => file.Name.Contains(".dll")))
                .And($"Includ only {partNameAssemblies} assemblies", files => files.Where(file => file.Name.Contains(partNameAssemblies) || includeAssemblies.Any(inAss => file.FullName.Contains(inAss))))
                .And($"Include only library assemlies",
                    files => files
                        .Where(file => !file.FullName.Contains("TestAdapter.dll")
                            && !file.FullName.Contains("obj")
                            && file.FullName.Contains(buildMode)))
                .And($"Exclude duplicate",
                    files => files
                    .DistinctByFunc((x, y) => x.Name == y.Name)
                    .ToList())
                .When("Get assembly infos",
                    files =>
                        files.Select(file =>
                        {
                            LoggingHelper.Info($"test assembly {file.FullName}");
                            return Assembly.LoadFrom(file.FullName);
                        }).ToList())
                .Then("Checke assembly version", assemblies =>
                {
                    var invalidAssemblies = new List<Assembly>();

                    foreach (Assembly assembly in assemblies)
                    {
                        if (!assembly.FullName.Contains($"Version={excpectedAssemblyVersion}"))
                            invalidAssemblies.Add(assembly);

                        CustomAttributeData attr = assembly.CustomAttributes.SingleOrDefault(attr => attr.AttributeType.Name.Equals(nameof(AssemblyFileVersionAttribute), StringComparison.Ordinal));

                        if (attr == null || attr.ConstructorArguments.Count == 0 || attr.ConstructorArguments[0].Value == null)
                            invalidAssemblies.Add(assembly);
                        else if (!(attr.ConstructorArguments[0].Value is string attrStr))
                            invalidAssemblies.Add(assembly);
                        else if (!attrStr.Equals(excpectedAssemblyVersion, StringComparison.Ordinal))
                            invalidAssemblies.Add(assembly);
                    }

                    if (invalidAssemblies.Count != 0)
                    {
                        Assert.Fail($"Invalid assemblies: \n{string.Join("\n", invalidAssemblies.ConvertAll(type => type.FullName))}");
                    }
                });
        }
    }
}
