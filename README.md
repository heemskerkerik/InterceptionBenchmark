# InterceptionBenchmark
A benchmark between different IoC and interception methods.

This small research project benchmarks between different IoC frameworks and their preferred method of interception. Currently the following frameworks are benchmarked:
* Unity with Unity.Interception
* SimpleInjector with Castle.DynamicProxy
* Castle.DynamicProxy stand-alone
* SimpleInjector with MethodTimer.Fody

What is being benchmarked is as follows:
* Creating or resolving `ISomething`;
* Calling `ISomething.Foo` on the resulting object;
* Timing the duration of the original method using a `Stopwatch`, either via interception or encapsulation (in a `TimingSomething`).

A benchmark on my machine (i7 6700HQ, 16 GB) results in the following, YMMV:

Method |         Median |        StdDev |   Scaled | Place |
------------------------------------ |--------------: |-------------: |--------: |-----: |
UsingUnity |  1,142.6636 ns |    35.9375 ns |    18.70 |     4 |
UsingUnityWithInterception | 89,725.4661 ns | 2,300.6833 ns | 1,468.33 |     6 |
UsingNew |     61.1070 ns |     4.6672 ns |     1.00 |     1 |
UsingSimpleInjector |    126.9396 ns |     2.2056 ns |     2.08 |     2 |
UsingSimpleInjectorWithInterception |  4,573.0595 ns |    94.7079 ns |    74.84 |     5 |
UsingDynamicProxyWithoutIoc |  4,406.1171 ns |    65.0494 ns |    72.10 |     5 |
UsingSimpleInjectorWithFody |    499.8958 ns |    31.3847 ns |     8.18 |     3 |

Benchmarking is done using the excellent [BenchmarkDotNet](https://github.com/PerfDotNet/BenchmarkDotNet) package.
