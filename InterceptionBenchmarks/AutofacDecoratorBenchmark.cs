using Autofac;

namespace InterceptionBenchmarks
{
    internal sealed class AutofacDecoratorBenchmark
    {
        private readonly IContainer _container;

        public AutofacDecoratorBenchmark()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Something>().Named<ISomething>("inner");
            builder.RegisterDecorator<ISomething>((c, inner) => new TimingSomething(inner), fromKey:"inner");

            _container = builder.Build();
        }

        public void Run()
        {
            var something = _container.Resolve<ISomething>();

            something.Foo();
        }
    }
}