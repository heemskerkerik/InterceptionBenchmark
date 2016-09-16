using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

using LinFu.DynamicProxy;

namespace InterceptionBenchmarks
{
    internal class LinFuInterceptor : IInvokeWrapper
    {
        private static readonly HashSet<MethodBase> _matchingMethods;
        private readonly object _target;

        static LinFuInterceptor()
        {
            _matchingMethods = new HashSet<MethodBase>(new[] {GetMatchingMethod()});
        }

        public LinFuInterceptor(object target)
        {
            _target = target;
        }

        public void BeforeInvoke(InvocationInfo info)
        {
        }

        public object DoInvoke(InvocationInfo info)
        {
            if(!_matchingMethods.Contains(info.TargetMethod))
            {
                return info.TargetMethod.Invoke(_target, info.Arguments);
            }

            var stopwatch = Stopwatch.StartNew();

            info.TargetMethod.Invoke(_target, info.Arguments);

            stopwatch.Stop();

            return null;
        }

        public void AfterInvoke(InvocationInfo info, object returnValue)
        {
        }

        private static MethodBase GetMatchingMethod()
        {
            return typeof(ISomething).GetMethod(nameof(ISomething.Foo));
        }
    }
}