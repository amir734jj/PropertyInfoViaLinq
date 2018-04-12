using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GetPropertyInfoViaLinq.Interfaces
{
    public interface IGetPropertyInfoViaLinq<T>
    {
        string GetPropertyName(Expression<Func<T, object>> expression);
        
        MemberExpression ToMemeberExpression(Expression<Func<T, object>> expression);
        
        PropertyInfo GetPropertyInfo(Expression<Func<T, object>> expression);
        
        Attribute GetAttribute(Expression<Func<T, object>> expression, Type attributeType);
    }
}