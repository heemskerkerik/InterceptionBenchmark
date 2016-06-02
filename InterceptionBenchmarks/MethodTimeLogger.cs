using System.Reflection;

namespace InterceptionBenchmarks
{
    public static class MethodTimeLogger
    {
        private static long _x;

        public static void Log(MethodBase methodBase, long milliseconds)
        {
            // do SOME work here
            _x += milliseconds;
        }
    }
}