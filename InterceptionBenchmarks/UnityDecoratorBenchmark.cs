using Microsoft.Practices.Unity;

namespace InterceptionBenchmarks
{
    internal sealed class UnityDecoratorBenchmark
    {
        private readonly UnityContainer _container;

        public UnityDecoratorBenchmark()
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