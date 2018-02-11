using System;
using System.Linq.Expressions;

namespace GetPropertyInfoViaLinq.Interfaces
{
    public interface IGetPropertyInfoViaLinq<T>
    {
        string GetPropertyName(Expression<Func<T, object>> expression);
        MemberExpression ToMemeberExpression(Expression<Func<T, object>> exp);
        Attribute GetAttribute(Expression<Func<T, object>> expression, Type attributeType);
    }
}