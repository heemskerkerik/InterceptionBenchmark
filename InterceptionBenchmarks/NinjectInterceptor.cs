using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

using Ninject.Extensions.Interception;

namespace InterceptionBenchmarks
{
    public class NinjectInterceptor : IInterceptor
    {
        private static readonly HashSet<MethodBase> _matchingMethods;

        static NinjectInterceptor()
        {
            _matchingMethods = new HashSet<MethodBase>(new[] {GetMatchingMethod()});
        }

        public void Intercept(IInvocation invocation)
        {
            if(!_matchingMethods.Contains(invocation.Request.Method))
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