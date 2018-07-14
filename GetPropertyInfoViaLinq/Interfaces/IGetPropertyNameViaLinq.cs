using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GetPropertyInfoViaLinq.Interfaces
{
    /// <summary>
    /// Initialized instance of Utility
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public interface IGetPropertyInfoViaLinq<TSource>
    {
        MemberExpression ToMemeberExpression<TResult>(Expression<Func<TSource, TResult>> exp);
        
        IGetInfo<TSource> Lambda(Expression<Func<TSource, object>> expr);
        
        IGetInfo<TSource> Lambda<TResult>(Expression<Func<TSource, TResult>> expr);
    }
}