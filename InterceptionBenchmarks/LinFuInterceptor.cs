using LinFu.DynamicProxy;
using System.Diagnostics;

namespace InterceptionBenchmarks
{
    internal class LinFuInterceptor: IInvokeWrapper
    {
        private readonly ISomething _target;

        public LinFuInterceptor(ISomething target)
        {
            _target = target;
        }

        public void BeforeInvoke(InvocationInfo info)
        {
        }

        public object DoInvoke(InvocationInfo info)
        {
            var stopwatch = Stopwatch.StartNew();

            info.TargetMethod.Invoke(_target, info.Arguments);

            stopwatch.Stop();

            return null;
        }

        public void AfterInvoke(InvocationInfo info, object returnValue)
        {
        }
    }
}