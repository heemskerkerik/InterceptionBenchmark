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
        public void UnityDecorator()
        {
            _unityWithDecorator.Run();
        }

        [Benchmark]
        public void UnityUnityInterception()
        {
            _unityWithUnityInterception.Run();
        }

        [Benchmark(Baseline = true)]
        public void NoDIDecorator()
        {
            var something = new TimingSomething(new Something());

            something.Foo();
        }

        [Benchmark]
        public void SimpleInjectorDecorator()
        {
            _simpleInjectorWithDecorator.Run();
        }

        [Benchmark]
        public void SimpleInjectorDynamicProxy()
        {
            _simpleInjectorWithDynamicProxy.Run();
        }

        [Benchmark]
        public void NoDIDynamicProxy()
        {
            _noDIWithDynamicProxy.Run();
        }

        [Benchmark]
        public void NoDILinFu()
        {
            _noDIWithLinFu.Run();
        }

        [Benchmark]
        public void AutofacDecorator()
        {
            _autofacWithDecorator.Run();
        }

        [Benchmark]
        public void AutofacDynamicProxy()
        {
            _autofacWithDynamicProxy.Run();
        }

        [Benchmark]
        public void NinjectDecorator()
        {
            _ninjectWithDecorator.Run();
        }

        [Benchmark]
        public void NinjectDynamicProxy()
        {
            _ninjectWithDynamicProxy.Run();
        }

        [Benchmark]
        public void NinjectLinFu()
        {
            _ninjectWithLinFu.Run();
        }
    }
}