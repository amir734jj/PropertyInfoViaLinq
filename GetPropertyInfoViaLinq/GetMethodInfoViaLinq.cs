using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GetPropertyInfoViaLinq
{
    public static class GetMethodInfoViaLinq<T>
    {
        public static string ActionName(Expression<Func<T, Action>> expression)
        {
            return MethodName(expression);
        }

        public static string ActionName<TParam>(Expression<Func<T, Action<TParam>>> expression)
        {
            return MethodName(expression);
        }

        public static string FuncName<TResult>(Expression<Func<T, Func<TResult>>> expression)
        {
            return MethodName(expression);
        }

        public static string FuncName<TParam, TResult>(Expression<Func<T, Func<TParam, TResult>>> expression)
        {
            return MethodName(expression);
        }

        private static readonly bool IsNet45 = Type.GetType("System.Reflection.ReflectionContext", false) != null;


        public static MethodInfo GetMethodInfo(LambdaExpression expression)
        {
            var unaryExpression = (UnaryExpression) expression.Body;
            var methodCallExpression = (MethodCallExpression) unaryExpression.Operand;

            if (IsNet45)
            {
                var methodCallObject = (ConstantExpression) methodCallExpression.Object;
                var methodInfo = (MethodInfo) methodCallObject.Value;
                return methodInfo;
            }
            else
            {
                var methodInfoExpression = (ConstantExpression) methodCallExpression.Arguments.Last();
                var methodInfo = (MemberInfo) methodInfoExpression.Value;
                return (MethodInfo) methodInfo;
            }
        }

        public static string MethodName(LambdaExpression expression) => GetMethodInfo(expression)?.Name;
    }
}