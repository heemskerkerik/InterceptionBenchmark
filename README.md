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
UsingNew |     57.8832 ns |     0.6876 ns |     1.00 |     1 |
UsingSimpleInjector |    131.6701 ns |     4.4298 ns |     2.27 |     2 |
UsingSimpleInjectorWithFody |    485.0658 ns |     6.5156 ns |     8.38 |     3 |
UsingUnity |  1,104.6204 ns |    38.5160 ns |    19.08 |     4 |
UsingAutofac |  1,288.5287 ns |    20.2904 ns |    22.26 |     5 |
UsingDynamicProxyWithoutIoc |  4,417.7852 ns |   124.4113 ns |    76.32 |     6 |
UsingSimpleInjectorWithInterception |  4,865.6226 ns |   120.3728 ns |    84.06 |     7 |
UsingAutofacWithInterception | 16,533.7070 ns |   444.3598 ns |   285.64 |     8 |
UsingUnityWithInterception | 89,815.6019 ns | 1,188.6651 ns | 1,551.67 |     9 |

For reference:

* A nanosecond (ns) is a billionth of a second;
* A microsecond (us or µs) is 1,000 nanoseconds;
* A millisecond (ms) is 1,000 microseconds or 1,000,000 nanoseconds.

Benchmarking is done using the excellent [BenchmarkDotNet](https://github.com/PerfDotNet/BenchmarkDotNet) package.
