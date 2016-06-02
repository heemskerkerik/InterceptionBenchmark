# InterceptionBenchmark
A benchmark between different IoC and interception methods.

This small research project benchmarks between different IoC frameworks and their preferred method of interception. Currently the following frameworks are benchmarked:
* Unity with Unity.Interception
* SimpleInjector with Castle.DynamicProxy
* Castle.DynamicProxy stand-alone

What is being benchmarked is as follows:
* Creating or resolving `ISomething`;
* Calling `ISomething.Foo` on the resulting object.

A benchmark on my machine (i7 6700HQ, 16 GB) results in the following, YMMV:

|                              Method |         Median |        StdDev |    Scaled | Place |
|------------------------------------ |---------------: |--------------: |----------: |------: |
|                          UsingUnity |    937.0814 ns |    29.9302 ns |    404.69 |     3 |
|          UsingUnityWithInterception | 87,300.8914 ns | 4,284.5019 ns | 37,701.92 |     5 |
|                            UsingNew |      2.3156 ns |     0.1674 ns |      1.00 |     1 |
|                 UsingSimpleInjector |     51.0103 ns |     0.8151 ns |     22.03 |     2 |
| UsingSimpleInjectorWithInterception |  3,935.7593 ns |    48.7990 ns |  1,699.70 |     4 |
|         UsingDynamicProxyWithoutIoc |  3,839.2032 ns |    69.0370 ns |  1,658.01 |     4 |

Benchmarking is done using the excellent [BenchmarkDotNet](https://github.com/PerfDotNet/BenchmarkDotNet) package.
