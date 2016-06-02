using Autofac;

namespace InterceptionBenchmarks
{
    internal sealed class AutofacBenchmark
    {
        private readonly IContainer _container;

        public AutofacBenchmark()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Something>()
                   .As<ISomething>();

            _container = builder.Build();
        }

        public void Run()
        {
            var something = _container.Resolve<ISomething>();

            something.Foo();
        }
    }
}