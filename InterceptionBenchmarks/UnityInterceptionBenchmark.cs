using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace InterceptionBenchmarks
{
    internal sealed class UnityInterceptionBenchmark
    {
        private readonly UnityContainer _container;

        public UnityInterceptionBenchmark()
        {
            _container = new UnityContainer();

            _container.AddNewExtension<Interception>();

            _container.Configure<Interception>()
                      .AddPolicy("Metering")
                      .AddMatchingRule(new SingleMethodMatchingRule())
                      .AddCallHandler(new UnityCallHandler());

            _container.RegisterType<ISomething, Something>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<PolicyInjectionBehavior>());
        }

        public void Run()
        {
            var something = _container.Resolve<ISomething>();

            something.Foo();
        }
    }
}