IContainer _container;

[Setup]
void Initialize()
{
    var builder = new ContainerBuilder();

    builder.RegisterType<Something>()
           .Named<ISomething>("inner");
    builder.RegisterDecorator<ISomething>(
        (c, inner) => new TimingSomething(inner), 
        fromKey:"inner");

    _container = builder.Build();
}

[Benchmark]
void UsingAutofacWithoutInterception()
{
    var something = container.Resolve<ISomething>();

    something.Bar();
}