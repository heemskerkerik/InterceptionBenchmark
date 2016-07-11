using Autofac;
using Autofac.Extras.DynamicProxy;

namespace InterceptionBenchmarks
{
    internal sealed class AutofacWithInterceptionBenchmark
    {
        private readonly IContainer _container;

        public AutofacWithInterceptionBenchmark()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Something>().As<ISomething>().EnableInterfaceInterceptors();
            builder.Register(c => new DynamicProxyInterceptor());

            _container = builder.Build();
        }

        public void Run()
        {
            var something = _container.Resolve<ISomething>();

            something.Foo();
        }
    }
}