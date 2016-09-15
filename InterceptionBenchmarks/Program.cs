using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace InterceptionBenchmarks
{
    class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }

    [Config("columns=Place")]
    public class Benchmark
    {
        private AutofacDecoratorBenchmark _autofacWithDecorator;
        private AutofacDynamicProxyBenchmark _autofacWithDynamicProxy;
        private NoDIDynamicProxyBenchmark _noDIWithDynamicProxy;
        private NoDILinFuBenchmark _noDIWithLinFu;
        private NinjectDecoratorBenchmark _ninjectWithDecorator;
        private NinjectDynamicProxyBenchmark _ninjectWithDynamicProxy;
        private NinjectLinFuBenchmark _ninjectWithLinFu;
        private SimpleInjectorDecoratorBenchmark _simpleInjectorWithDecorator;
        private SimpleInjectorDynamicProxyBenchmark _simpleInjectorWithDynamicProxy;
        private UnityDecoratorBenchmark _unityWithDecorator;
        private UnityInterceptionBenchmark _unityWithUnityInterception;

        [Setup]
        public void Initialize()
        {
            _unityWithDecorator = new UnityDecoratorBenchmark();
            _unityWithUnityInterception = new UnityInterceptionBenchmark();
            _simpleInjectorWithDecorator = new SimpleInjectorDecoratorBenchmark();
            _simpleInjectorWithDynamicProxy = new SimpleInjectorDynamicProxyBenchmark();
            _noDIWithDynamicProxy = new NoDIDynamicProxyBenchmark();
            _noDIWithLinFu = new NoDILinFuBenchmark();
            _autofacWithDecorator = new AutofacDecoratorBenchmark();
            _autofacWithDynamicProxy = new AutofacDynamicProxyBenchmark();
            _ninjectWithDecorator = new NinjectDecoratorBenchmark();
            _ninjectWithDynamicProxy = new NinjectDynamicProxyBenchmark();
            _ninjectWithLinFu = new NinjectLinFuBenchmark();
        }

        [Benchmark]
        public void UsingUnity()
        {
            _unityWithDecorator.Run();
        }

        [Benchmark]
        public void UsingUnityWithInterception()
        {
            _unityWithUnityInterception.Run();
        }

        [Benchmark(Baseline = true)]
        public void UsingNew()
        {
            var something = new TimingSomething(new Something());

            something.Foo();
        }

        [Benchmark]
        public void UsingSimpleInjector()
        {
            _simpleInjectorWithDecorator.Run();
        }

        [Benchmark]
        public void UsingSimpleInjectorWithInterception()
        {
            _simpleInjectorWithDynamicProxy.Run();
        }

        [Benchmark]
        public void UsingDynamicProxyWithoutIoc()
        {
            _noDIWithDynamicProxy.Run();
        }

        [Benchmark]
        public void UsingLinFuWithoutIoc()
        {
            _noDIWithLinFu.Run();
        }

        [Benchmark]
        public void UsingAutofac()
        {
            _autofacWithDecorator.Run();
        }

        [Benchmark]
        public void UsingAutofacWithInterception()
        {
            _autofacWithDynamicProxy.Run();
        }

        [Benchmark]
        public void UsingNinject()
        {
            _ninjectWithDecorator.Run();
        }

        [Benchmark]
        public void UsingNinjectWithDynamicProxyInterceptorInterception()
        {
            _ninjectWithDynamicProxy.Run();
        }

        [Benchmark]
        public void UsingNinjectWithLinFuInterceptorInterception()
        {
            _ninjectWithLinFu.Run();
        }
    }
}