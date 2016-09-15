using SimpleInjector;

namespace InterceptionBenchmarks
{
    internal sealed class SimpleInjectorDecoratorBenchmark
    {
        private readonly Container _container;

        public SimpleInjectorDecoratorBenchmark()
        {
            _container = new Container();

            _container.Register<ISomething, Something>();
            _container.RegisterDecorator<ISomething, TimingSomething>(Lifestyle.Transient);
        }

        public void Run()
        {
            var something = _container.GetInstance<ISomething>();

            something.Foo();
        }
    }
}