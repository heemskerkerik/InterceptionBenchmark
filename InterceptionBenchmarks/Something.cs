namespace InterceptionBenchmarks
{
    internal class Something : ISomething
    {
        private int _x;

        void ISomething.Foo()
        {
            _x++;
        }

        public void Bar()
        {
        }

        public void Blue()
        {
        }

        public void Foo()
        {
        }
    }
}