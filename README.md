# InterceptionBenchmark
A benchmark between different IoC and interception methods.

This small research project benchmarks between different IoC frameworks and their preferred method of interception. Currently the following frameworks are benchmarked:
* Unity with Unity.Interception
* SimpleInjector with Castle.DynamicProxy
* Castle.DynamicProxy stand-alone
* SimpleInjector with MethodTimer.Fody
* Autofac with Castle.DynamicProxy

What is being benchmarked is as follows:
* Creating or resolving `ISomething`;
* Calling `ISomething.Foo` on the resulting object;
* Timing the duration of the original method using a `Stopwatch`, either via interception or encapsulation (in a `TimingSomething`).

A benchmark on my machine (i7 6700HQ, 16 GB) results in the following, YMMV:

Method |         Median |        StdDev |   Scaled | Place |
------------------------------------ |--------------: |-------------: |--------: |-----: |
UsingNew |     53,0475 ns |     1,2048 ns |     1,00 |     1 |
UsingSimpleInjector |    119,8636 ns |     2,9011 ns |     2,26 |     2 |
UsingSimpleInjectorWithFody |    456,7976 ns |    16,0940 ns |     8,61 |     3 |
UsingUnity |    995,3501 ns |    53,7859 ns |    18,76 |     4 |
UsingAutofac |  1 192,0763 ns |    72,7590 ns |    22,47 |     5 |
UsingDynamicProxyWithoutIoc |  4 219,4526 ns |    44,2089 ns |    79,54 |     6 |
UsingSimpleInjectorWithInterception |  4 605,1258 ns |   329,7238 ns |    86,81 |     7 |
UsingNinjectWithLinFuMethodInterception | 10 071,2066 ns |   573,8851 ns |   189,85 |     8 |
UsingNinjectWithDynamicProxyMethodInterception | 10 239,9290 ns |   334,3963 ns |   193,03 |     8 |
UsingNinject | 14 638,0324 ns | 1 104,9395 ns |   275,94 |     9 |
UsingAutofacWithInterception | 15 580,4160 ns |   800,6822 ns |   293,71 |     9 |
UsingNinjectWithLinFuInterceptorInterception | 16 633,1512 ns |   835,7362 ns |   313,55 |     9 |
UsingNinjectWithDynamicProxyInterceptorInterception | 20 548,4465 ns | 1 030,3296 ns |   387,36 |    10 |
UsingUnityWithInterception | 82 962,1605 ns | 3 280,7292 ns | 1 563,92 |    11 |

For reference:

* A nanosecond (ns) is a billionth of a second;
* A microsecond (us or µs) is 1 000 nanoseconds;
* A millisecond (ms) is 1 000 microseconds or 1 000 000 nanoseconds.

Benchmarking is done using the excellent [BenchmarkDotNet](https://github.com/PerfDotNet/BenchmarkDotNet) package.
