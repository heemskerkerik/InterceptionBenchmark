using Microsoft.Practices.Unity;

namespace InterceptionBenchmarks
{
    internal sealed class UnityBenchmark
    {
        private readonly UnityContainer _container;

        public UnityBenchmark()
        {
            _container = new UnityContainer();

            _container.RegisterType<ISomething, TimingSomething>(new InjectionConstructor(new Something()));
        }

        public void Run()
        {
            var something = _container.Resolve<ISomething>();

            something.Foo();
        }
    }
}