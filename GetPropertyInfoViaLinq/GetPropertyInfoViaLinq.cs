using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GetPropertyInfoViaLinq.Interfaces;
using GetPropertyInfoViaLinq.Utilities;

namespace GetPropertyInfoViaLinq
{
    /// <summary>
    /// Utility to get property info via linq expression
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class GetPropertyInfoViaLinq<TSource> : BaseBuilder<GetPropertyInfoViaLinq<TSource>>, IGetPropertyInfoViaLinq<TSource>
    {
        /// <summary>
        /// Converts lambda expression to member expression
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public virtual MemberExpression ToMemeberExpression<TResult>(Expression<Func<TSource, TResult>> exp)
        {
            MemberExpression resultExp;
            var body = exp.Body;
            
            switch (body)
            {
                case MemberExpression memberExpression:
                    resultExp = memberExpression;
                    break;
                case UnaryExpression unaryExpression:
                    resultExp = unaryExpression.Operand as MemberExpression;
                    break;
                case LambdaExpression memberExpression:
                    throw new Exception("Lambda expressions cannot be decomposed!");
                default:
                    throw new Exception("Something is wrong with the type!");
            }
            
            return resultExp;
        }

        /// <summary>
        /// GetInfo given member expression
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public IGetInfo<TSource> Lambda(Expression<Func<TSource, object>> expr)
        {
            return new GetInfo<TSource>(ToMemeberExpression(expr));
        }

        /// <summary>
        /// Get info given member expression
        /// </summary>
        /// <param name="expr"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public IGetInfo<TSource> Lambda<TResult>(Expression<Func<TSource, TResult>> expr)
        {
            return new GetInfo<TSource>(ToMemeberExpression(expr));
        }
    }
}