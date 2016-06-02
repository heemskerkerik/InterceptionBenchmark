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
        private SimpleInjectorBenchmark _simpleInjector;
        private SimpleInjectorWithInterceptionBenchmark _simpleInjectorWithInterception;
        private UnityBenchmark _unity;
        private UnityWithInterceptionBenchmark _unityWithInterception;
        private DynamicProxyWithoutIocBenchmark _dynamicProxyWithoutIoc;
        private SimpleInjectorWithFodyBenchmark _simpleInjectorWithFody;
        private AutofacBenchmark _autofac;
        private AutofacWithInterceptionBenchmark _autofacWithInterception;

        [Setup]
        public void Initialize()
        {
            _unity = new UnityBenchmark();
            _unityWithInterception = new UnityWithInterceptionBenchmark();
            _simpleInjector = new SimpleInjectorBenchmark();
            _simpleInjectorWithInterception = new SimpleInjectorWithInterceptionBenchmark();
            _dynamicProxyWithoutIoc = new DynamicProxyWithoutIocBenchmark();
            _simpleInjectorWithFody = new SimpleInjectorWithFodyBenchmark();
            _autofac = new AutofacBenchmark();
            _autofacWithInterception = new AutofacWithInterceptionBenchmark();
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

        [Benchmark]
        public void UsingSimpleInjectorWithFody()
        {
            _simpleInjectorWithFody.Run();
        }

        [Benchmark]
        public void UsingAutofac()
        {
            _autofac.Run();
        }

        [Benchmark]
        public void UsingAutofacWithInterception()
        {
            _autofacWithInterception.Run();
        }
    }
}