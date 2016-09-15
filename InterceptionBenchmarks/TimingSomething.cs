using System.Diagnostics;

namespace InterceptionBenchmarks
{
    internal class TimingSomething: ISomething
    {
        private readonly ISomething _base;

        public TimingSomething(ISomething @base)
        {
            _base = @base;
        }

        public void Foo()
        {
            var stopwatch = Stopwatch.StartNew();

            _base.Foo();

            stopwatch.Stop();
        }

        public void Bar()
        {
        }

        public void Blue()
        {
        }
    }
}