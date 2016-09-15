[Benchmark]
void UsingAutofacWithoutInterception()
{
    var builder = new ContainerBuilder();

    builder.RegisterType<Something>()
           .Named<ISomething>("inner");
    builder.RegisterDecorator<ISomething>(
        (c, inner) => new TimingSomething(inner), 
        fromKey:"inner");

    using (var container = builder.Build())
    {
        var something = container.Resolve<ISomething>();

        something.Bar();
    }
}