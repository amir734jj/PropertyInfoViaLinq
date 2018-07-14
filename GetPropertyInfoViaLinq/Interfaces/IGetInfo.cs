using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GetPropertyInfoViaLinq.Interfaces
{
    /// <summary>
    /// Returns the info
    /// </summary>
    public interface IGetInfo<T>
    {
        MemberExpression MemberExpresion { get; }
        
        string GetPropertyName();

        PropertyInfo GetPropertyInfo();

        TAttributeType GetAttribute<TAttributeType>() where TAttributeType : Attribute;
    }
}