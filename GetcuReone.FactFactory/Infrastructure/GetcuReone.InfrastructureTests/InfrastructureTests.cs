using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace InfrastructureTests
{
    [TestClass]
    public class InfrastructureTests : InfrastructureTestBase
    {
        private DirectoryInfo _solutionFolder;
        private string _projectName;

        [TestInitialize]
        public override void Initialize()
        {
            _solutionFolder = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.Parent.Parent;
            _projectName = "FactFactory";

            BuildConfiguration = Environment.GetEnvironmentVariable("buildConfiguration");
            if (string.IsNullOrEmpty(BuildConfiguration))
                BuildConfiguration = "Debug";

            TargetFramework = "netstandard2.0";
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Infra)]
        [Description("Checking the presence of all the necessary files in the nugget package.")]
        [Timeout(Timeouts.Minute.One)]
        public void NugetHaveNeedFilesTestCase()
        {
            string nugetId = $"GetcuReone.{_projectName}";
            List<string> targetFrameworks = [
                "netstandard2.0",
                "netcoreapp3.1",
                "net6.0",
                "net8.0"
                ];
            List<string> files = [
                "LICENSE",
                "README.md",
            ];

            foreach (string targetFramework in targetFrameworks)
            {
                string libPattern = $"lib/{targetFramework}/GetcuReone." + "{0}";
                files.AddRange([
                    string.Format(libPattern, $"{_projectName}.Main.dll"),
                    string.Format(libPattern, $"{_projectName}.Main.xml"),
                    string.Format(libPattern, $"{_projectName}.Common.dll"),
                    string.Format(libPattern, $"{_projectName}.Common.xml"),
                    string.Format(libPattern, $"{_projectName}.Interfaces.dll"),
                    string.Format(libPattern, $"{_projectName}.Interfaces.xml"),
                    string.Format(libPattern, $"{_projectName}.BaseEntities.dll"),
                    string.Format(libPattern, $"{_projectName}.BaseEntities.xml"),
                    string.Format(libPattern, $"{_projectName}.Entities.dll"),
                    string.Format(libPattern, $"{_projectName}.Entities.xml"),
                    string.Format(libPattern, $"{_projectName}.Facades.dll"),
                    string.Format(libPattern, $"{_projectName}.Facades.xml"),

                    string.Format(libPattern, $"{_projectName}.Priority.Interfaces.dll"),
                    string.Format(libPattern, $"{_projectName}.Priority.Interfaces.xml"),
                    string.Format(libPattern, $"{_projectName}.Priority.Common.dll"),
                    string.Format(libPattern, $"{_projectName}.Priority.Common.xml"),
                    string.Format(libPattern, $"{_projectName}.Priority.Facades.dll"),
                    string.Format(libPattern, $"{_projectName}.Priority.Facades.xml"),
                    string.Format(libPattern, $"{_projectName}.Priority.dll"),
                    string.Format(libPattern, $"{_projectName}.Priority.xml"),

                    string.Format(libPattern, $"{_projectName}.Versioned.Interfaces.dll"),
                    string.Format(libPattern, $"{_projectName}.Versioned.Interfaces.xml"),
                    string.Format(libPattern, $"{_projectName}.Versioned.Common.dll"),
                    string.Format(libPattern, $"{_projectName}.Versioned.Common.xml"),
                    string.Format(libPattern, $"{_projectName}.Versioned.Facades.dll"),
                    string.Format(libPattern, $"{_projectName}.Versioned.Facades.xml"),
                    string.Format(libPattern, $"{_projectName}.Versioned.BaseEntities.dll"),
                    string.Format(libPattern, $"{_projectName}.Versioned.BaseEntities.xml"),
                    string.Format(libPattern, $"{_projectName}.Versioned.Entities.dll"),
                    string.Format(libPattern, $"{_projectName}.Versioned.Entities.xml"),
                    string.Format(libPattern, $"{_projectName}.Versioned.dll"),
                    string.Format(libPattern, $"{_projectName}.Versioned.xml"),
                    ]);
            }

            VerifyNugetContainsFiles(_solutionFolder, nugetId, files.Count + 4, files);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Infra)]
        [Description("Check for all attribute Timeout tests.")]
        [Timeout(Timeouts.Minute.One)]
        public void AllHaveTimeoutTestCase()
        {
            CheckAllTestsContainTimeoutsInFolder(_solutionFolder);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Infra)]
        [Description("All namespaces start with GetcuReone.")]
        [Timeout(Timeouts.Minute.One)]
        public void AllNamespacesStartWithGetcuReoneTestCase()
        {
            string beginNamespace = "GetcuReone";
            string[] excludeAssemblies = new string[]
            {
                "FactFactory.TestsCommon.dll",
            };

            CheckBeginNamespacesInLibrary(_solutionFolder, _projectName, beginNamespace, excludeAssemblies);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Infra)]
        [Description("Assemblies have major version.")]
        [Timeout(Timeouts.Minute.One)]
        public void AssembliesHave3ersionTestCase()
        {
            string[] includeAssemblies = new string[] { };
            string excpectedAssemblyVersion = "3.0.0.0";

            CheckAssembliesVersion(_solutionFolder, _projectName, excpectedAssemblyVersion, includeAssemblies);
        }
    }
}
