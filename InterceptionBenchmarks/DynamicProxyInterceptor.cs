using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

using Castle.DynamicProxy;

namespace InterceptionBenchmarks
{
    internal class DynamicProxyInterceptor : IInterceptor
    {
        private static readonly HashSet<MethodBase> _matchingMethods;

        static DynamicProxyInterceptor()
        {
            _matchingMethods = new HashSet<MethodBase>(new[] {GetMatchingMethod()});
        }

        public void Intercept(IInvocation invocation)
        {
            if(!_matchingMethods.Contains(invocation.MethodInvocationTarget))
            {
                invocation.Proceed();
                return;
            }

            var stopwatch = Stopwatch.StartNew();

            invocation.Proceed();

            stopwatch.Stop();
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