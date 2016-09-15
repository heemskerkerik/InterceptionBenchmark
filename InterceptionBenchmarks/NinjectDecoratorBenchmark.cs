using Ninject;

namespace InterceptionBenchmarks
{
    internal sealed class NinjectDecoratorBenchmark
    {
        private readonly IKernel _kernel;

        public NinjectDecoratorBenchmark()
        {
            _kernel = new StandardKernel();

            _kernel.Bind<ISomething>().ToConstructor(_ => new TimingSomething(new Something()));
        }

        public void Run()
        {
            var something = _kernel.Get<ISomething>();

            something.Foo();
        }
    }
}