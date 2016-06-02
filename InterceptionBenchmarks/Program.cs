using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using Castle.DynamicProxy;

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
        private SimpleInjectorBenchmark _simpleInjector;
        private SimpleInjectorWithInterceptionBenchmark _simpleInjectorWithInterception;
        private UnityBenchmark _unity;
        private UnityWithInterceptionBenchmark _unityWithInterception;
        private DynamicProxyWithoutIocBenchmark _dynamicProxyWithoutIoc;

        public Benchmark()
        {
        }

        [Setup]
        public void Initialize()
        {
            _unity = new UnityBenchmark();
            _unityWithInterception = new UnityWithInterceptionBenchmark();
            _simpleInjector = new SimpleInjectorBenchmark();
            _simpleInjectorWithInterception = new SimpleInjectorWithInterceptionBenchmark();
            _dynamicProxyWithoutIoc = new DynamicProxyWithoutIocBenchmark();
        }

        [Benchmark]
        public void UsingUnity()
        {
            _unity.Run();
        }

        [Benchmark]
        public void UsingUnityWithInterception()
        {
            _unityWithInterception.Run();
        }

        [Benchmark(Baseline = true)]
        public void UsingNew()
        {
            var something = new Something();

            something.Foo();
        }

        [Benchmark]
        public void UsingSimpleInjector()
        {
            _simpleInjector.Run();
        }

        [Benchmark]
        public void UsingSimpleInjectorWithInterception()
        {
            _simpleInjectorWithInterception.Run();
        }

        [Benchmark]
        public void UsingDynamicProxyWithoutIoc()
        {
            _dynamicProxyWithoutIoc.Run();
        }
    }

    internal sealed class DynamicProxyWithoutIocBenchmark
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();

        public void Run()
        {
            var something = CreateProxy();

            something.Foo();
        }

        private ISomething CreateProxy()
        {
            var something = new Something();

            return _generator.CreateInterfaceProxyWithTarget<ISomething>(something, new DynamicProxyInterceptor());
        }
    }
}