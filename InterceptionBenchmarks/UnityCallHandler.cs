using System.Diagnostics;

using Microsoft.Practices.Unity.InterceptionExtension;

namespace InterceptionBenchmarks
{
    internal class UnityCallHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var stopwatch = Stopwatch.StartNew();

            var result = getNext()(input, getNext);

            stopwatch.Stop();

            return result;
        }

        public int Order { get; set; }
    }
}