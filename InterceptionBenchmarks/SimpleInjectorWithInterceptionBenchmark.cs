using SimpleInjector;

namespace InterceptionBenchmarks
{
    internal sealed class SimpleInjectorWithInterceptionBenchmark
    {
        private readonly Container _container;

        public SimpleInjectorWithInterceptionBenchmark()
        {
            _container = new Container();

            _container.InterceptWith<DynamicProxyInterceptor>(type => type == typeof(Something));
            _container.Register<ISomething, Something>(Lifestyle.Transient);
        }

        public void Run()
        {
            var something = _container.GetInstance<ISomething>();

            something.Foo();
        }
    }
}