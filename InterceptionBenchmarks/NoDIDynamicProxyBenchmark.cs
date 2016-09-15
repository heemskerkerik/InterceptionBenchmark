using Castle.DynamicProxy;

namespace InterceptionBenchmarks
{
    internal sealed class NoDIDynamicProxyBenchmark
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();

        public void Run()
        {
            var something = CreateProxy();

            something.Foo();
        }

        private ISomething CreateProxy()
        {
            var something = new Something();

            return _generator.CreateInterfaceProxyWithTarget<ISomething>(something, new DynamicProxyInterceptor());
        }
    }
}