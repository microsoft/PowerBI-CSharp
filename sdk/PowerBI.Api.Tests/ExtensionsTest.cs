using Microsoft.PowerBI.Api.V2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PowerBI.Api.Tests
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void VerifyAllInGroupFunctionsHasMatchingOverrideWithoutInGroup()
        {
            Type[] expectedTypeWithInGroupVersions = { typeof(ReportsExtensions), typeof(DatasetsExtensions), typeof(DashboardsExtensions), typeof(TilesExtensions), typeof(ImportsExtensions) };
            string[] notOverridenMethods = { "DeleteUserInGroup", "DeleteUserInGroupAsync" };
            
            var allExtensionTypes = typeof(PowerBIClient).Assembly.GetTypes().Where(t => t.Name.EndsWith("Extensions"));
            foreach (var type in allExtensionTypes)
            {
                if (expectedTypeWithInGroupVersions.Contains(type))
                {
                    TestInGroupOverrides(type);
                }
                else
                {
                    var typeMethods = type.GetMethods().Where(mi => !notOverridenMethods.Contains(mi.Name));
                    Assert.IsTrue(typeMethods.All(mi => !mi.Name.Contains("InGroup")), "Types which were not added the override without InGroup, shouldn't have InGroup methods");
                }
            }
        }

        private void TestInGroupOverrides(Type type)
        {
            var allMethods = type.GetMethods();
            var inGroupMethods = allMethods.Where(mi => mi.Name.Contains("InGroup"));
            var parameterInfoComparer = new ParameterInfoComparer();

            foreach (var inGroupMethod in inGroupMethods)
            {
                // Search method with the same name without InGroup, and with the same parameter list
                var nameWithoutInGroup = inGroupMethod.Name.Replace("InGroup", "");
                
                var overrideMethods = allMethods
                    .Where(mi => mi.Name.Equals(nameWithoutInGroup) && 
                           mi.GetParameters().SequenceEqual(inGroupMethod.GetParameters(), parameterInfoComparer));
                
                if (overrideMethods.Count() == 0)
                {
                    var methodParams = string.Join(", ", inGroupMethod.GetParameters().Select(pi => pi.ParameterType));
                    Assert.Fail("Expecting to find method {0}, in class {1} with parameters ({2}) (copy of {0}InGroup) - To Resolve - copy {0}InGroup from {1}.cs to Extensions\\V2\\{1}.cs and rename to {0}", nameWithoutInGroup, type.Name, methodParams);
                }

                Assert.AreEqual(1, overrideMethods.Count(), "Expecting exactly one instance of mathcing method without InGroup suffix");
            }
        }

        private class ParameterInfoComparer : IEqualityComparer<ParameterInfo>
        {
            public bool Equals(ParameterInfo x, ParameterInfo y)
            {
                return x.ParameterType == y.ParameterType && x.Name == y.Name;
            }

            public int GetHashCode(ParameterInfo obj)
            {
                return obj.ParameterType.GetHashCode() ^ obj.Name.GetHashCode();
            }
        }

    }
}
