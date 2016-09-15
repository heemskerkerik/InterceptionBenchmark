using LinFu.DynamicProxy;

namespace InterceptionBenchmarks
{
    internal sealed class NoDILinFuBenchmark
    {
        private static readonly ProxyFactory _factory = new ProxyFactory();

        public void Run()
        {
            var something = CreateProxy();

            something.Foo();
        }

        private ISomething CreateProxy()
        {
            var something = new Something();
            var interceptor = new LinFuInterceptor(something);

            return _factory.CreateProxy<ISomething>(interceptor);
        }
    }
}