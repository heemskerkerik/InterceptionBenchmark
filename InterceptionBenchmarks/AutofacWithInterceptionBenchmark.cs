using Autofac;
using Autofac.Extras.DynamicProxy2;

namespace InterceptionBenchmarks
{
    internal sealed class AutofacWithInterceptionBenchmark
    {
        private readonly IContainer _container;

        public AutofacWithInterceptionBenchmark()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Something>()
                   .As<ISomething>()
                   .InterceptedBy(typeof(DynamicProxyInterceptor));
            builder.RegisterType<DynamicProxyInterceptor>();

            _container = builder.Build();
        }

        public void Run()
        {
            var something = _container.Resolve<ISomething>();

            something.Foo();
        }
    }
}