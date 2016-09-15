using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;

namespace InterceptionBenchmarks
{
    internal sealed class NinjectLinFuBenchmark
    {
        private readonly IKernel _kernel;

        public NinjectLinFuBenchmark()
        {
            _kernel = new StandardKernel(new NinjectSettings {LoadExtensions = false}, new LinFuModule());

            _kernel.Bind<ISomething>().To<Something>().Intercept().With<NinjectInterceptor>();
        }

        public void Run()
        {
            var something = _kernel.Get<ISomething>();

            something.Foo();
        }
    }
}