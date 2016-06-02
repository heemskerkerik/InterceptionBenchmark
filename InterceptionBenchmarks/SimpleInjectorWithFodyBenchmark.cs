using SimpleInjector;

namespace InterceptionBenchmarks
{
    internal sealed class SimpleInjectorWithFodyBenchmark
    {
        private readonly Container _container;

        public SimpleInjectorWithFodyBenchmark()
        {
            _container = new Container();

            _container.Register<ISomething, FodySomething>();
        }

        public void Run()
        {
            var something = _container.GetInstance<ISomething>();

            something.Foo();
        }
    }
}