using MethodTimer;

namespace InterceptionBenchmarks
{
    internal class FodySomething : ISomething
    {
        private int _x;

        [Time]
        public void Foo()
        {
            _x++;
        }

        public void Blue()
        {
        }
    }
}