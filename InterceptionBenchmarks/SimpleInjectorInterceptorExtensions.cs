using System;
using System.Linq.Expressions;

using Castle.DynamicProxy;

using SimpleInjector;

namespace InterceptionBenchmarks
{
    public static class SimpleInjectorInterceptorExtensions
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();

        private static readonly Func<Type, object, IInterceptor, object> _createProxy =
            (p, t, i) => _generator.CreateInterfaceProxyWithTarget(p, t, i);

        public static void InterceptWith<TInterceptor>(this Container c,
                                                       Predicate<Type> predicate)
            where TInterceptor : class, IInterceptor
        {
            c.ExpressionBuilt += (s, e) =>
            {
                if(predicate(e.Expression.Type))
                {
                    var interceptorExpression =
                        c.GetRegistration(typeof(TInterceptor), true).BuildExpression();

                    e.Expression = Expression.Convert(
                        Expression.Invoke(Expression.Constant(_createProxy),
                            Expression.Constant(e.RegisteredServiceType, typeof(Type)),
                            e.Expression,
                            interceptorExpression),
                        e.RegisteredServiceType);
                }
            };
        }

        public static void InterceptWithStaticMatch<TInterceptor>(this Container c)
            where TInterceptor : class, IInterceptor
        {
            c.ExpressionBuilt += (s, e) =>
            {
                if(e.Expression.Type == typeof(Something))
                {
                    var interceptorExpression =
                        c.GetRegistration(typeof(TInterceptor), true).BuildExpression();

                    e.Expression = Expression.Convert(
                        Expression.Invoke(Expression.Constant(_createProxy),
                            Expression.Constant(e.RegisteredServiceType, typeof(Type)),
                            e.Expression,
                            interceptorExpression),
                        e.RegisteredServiceType);
                }
            };
        }
    }
}