using JwtTestAdapter;
using JwtTestAdapter.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InfrostructTests
{
    [TestClass]
    public class InfrostructTests : TestBase
    {
        [TestMethod]
        public void AllHaveTimeoutTestCase()
        {
            string mode = string.Empty;
#if DEBUG
            mode = "Debug";
#else
            mode = "Release";
#endif
            List<string> assemblyPaths = new List<string>
            {
                @"..\..\..\..\FactFactoryTests\bin\" + mode + @"\netcoreapp2.1\FactFactoryTests.dll",
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
    }
}
