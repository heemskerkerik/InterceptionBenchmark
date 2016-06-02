using System;
using System.Collections.Generic;
using System.Reflection;

using Microsoft.Practices.Unity.InterceptionExtension;

namespace InterceptionBenchmarks
{
    internal class SingleMethodMatchingRule : IMatchingRule
    {
        private static readonly HashSet<MethodBase> _matchingMethods;

        static SingleMethodMatchingRule()
        {
            _matchingMethods = new HashSet<MethodBase>(new[] {GetMatchingMethod()});
        }

        public bool Matches(MethodBase method)
        {
            return _matchingMethods.Contains(method);
        }

        private static MethodBase GetMatchingMethod()
        {
            var type = typeof(Something);
            var interfaceMap = type.GetInterfaceMap(typeof(ISomething));

            int index = Array.FindIndex(interfaceMap.InterfaceMethods, method => method.Name == nameof(ISomething.Foo));

            return interfaceMap.TargetMethods[index];
        }
    }
}